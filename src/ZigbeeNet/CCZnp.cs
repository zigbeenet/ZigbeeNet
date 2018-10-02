﻿using System;
using System.Collections.Generic;
using System.IO;
using ZigbeeNet;
using UnpiNet;
using System.Diagnostics;
using ZigbeeNet.Commands;

namespace ZigbeeNet
{
    public class CCZnp
    {
        //TODO: get and set to data destination e.g. database or textfile
        public Dictionary<ulong, Device> Devices { get; set; }

        public bool Enabled { get; set; }
        public Unpi Unpi { get; set; }

        public event EventHandler Ready;
        public event EventHandler Closed;
        public event EventHandler<ZpiObject> AsyncResponse;
        public event EventHandler<ZpiObject> SyncResponse;

        private List<byte[]> _txQueue;
        private bool _spinLock;

        private bool _reset;
        private bool _resetting {
            get
            {
                return _reset;
            }
            set
            {
                if(_resetTimer == null)
                {
                    _resetTimer = new Stopwatch();
                }
                if (value == true)
                {
                    _resetTimer.Restart();
                } else
                {
                    _resetTimer.Stop();
                }
                _reset = value;
            }
        }
        private Stopwatch _resetTimer;

        public CCZnp()
        {
            _txQueue = new List<byte[]>();
        }

        public void Init(string port, int baudrate = 115200, Action callback = null)
        {
            Unpi = new Unpi(port, baudrate, 1);
            Unpi.DataReceived += Unpi_DataReceived;
            Unpi.Opened += Unpi_Opened;
            Unpi.Closed += Unpi_Closed;

            Unpi.Open();
        }

        private void Unpi_Closed(object sender, EventArgs e)
        {
            Stop();
        }

        private void Unpi_Opened(object sender, EventArgs e)
        {
            Ready?.Invoke(this, EventArgs.Empty);
        }

        private void Unpi_DataReceived(object sender, Packet e)
        {
            if((byte)e.Type == (byte)MessageType.SRSP)
            {
                _spinLock = false;

                //TODO: clear timeout controller if it is there

                // schedule next transmission if something in txQueue
                ScheduleNextSend();

                _resetting = false;
            }
            else if ((byte)e.Type == (byte)MessageType.AREQ)
            {
                
            }

            ParseIncomingData(e);
        }

        public void Start()
        {
            Enabled = true;
            Unpi.Open();
        }

        public void Stop()
        {
            Enabled = false;
            _txQueue.Clear();
            Unpi = null;

            Closed?.Invoke(this, EventArgs.Empty);
        }

        public void Reset()
        {

        }

        public void PermitJoin(int time, bool onCoord)
        {
            if(Enabled == false)
            {
                throw new Exception("ZNP is not enabled");
            }
            
            byte addrmode = 0x02;       //Coordinator
            ushort dstaddr = 0x0000;    //Coordinator adress;

            if (onCoord == false)
            {
                addrmode = 0x0F;
                dstaddr = 0xFFFC;   // all coord and routers
            }

            if (time > 255 || time < 0)
                throw new Exception("Jointime can only range from  0 to 255.");

            byte cmd = 54; //mgmtPermitJoinReq

            ArgumentCollection valObj = new ArgumentCollection();
            valObj.Add("addrmode", DataType.UInt8, addrmode);
            valObj.Add("dstaddr", DataType.UInt16, dstaddr);
            valObj.Add("duration", DataType.UInt16, 0);
            valObj.Add("tcsignificance", DataType.UInt16, 0);

            this.Request(SubSystem.ZDO, cmd, valObj);
        }

        public byte[] SendCommand(BaseCommand command, Action callback = null)
        {
            return Request(command, callback);
        }

        public byte[] SendCommand(MessageType type, SubSystem subSystem, byte commandId, byte[] payload)
        {
            return Unpi.Send((int)type, (int)subSystem, commandId, payload);
        }

        public byte[] Request(ZpiObject zpiObject, Action callback = null)
        {
            return Request(zpiObject.SubSystem, zpiObject.CommandId, zpiObject.Arguments, callback);
        }

        public byte[] Request(SubSystem subSystem, byte commandId, ArgumentCollection valObject, Action callback = null)
        {
            if(Unpi == null)
            {
                throw new NullReferenceException("CCZnp has not been initialized yet");
            }

            if(_spinLock)
            {
                byte[] result = Request(subSystem, commandId, valObject, callback);

                _txQueue.Add(result);

                return result;
            }

            //prepare for transmission
            _spinLock = true;

            ZpiObject zpiObject = new ZpiObject(subSystem, commandId, valObject);

            if(zpiObject.Type == MessageType.SREQ)
            {
                return SendSREQ(zpiObject, callback);
            }
            else if (zpiObject.Type == MessageType.AREQ)
            {
                return SendAREQ(zpiObject, callback);
            }

            return null;
        }

        private byte[] SendSREQ(ZpiObject zpiObject, Action callback = null)
        {
            //TODO: Check for timeout

            return Unpi.Send((int)MessageType.SREQ, (int)zpiObject.SubSystem, zpiObject.CommandId, zpiObject.Frame);
        }

        private byte[] SendAREQ(ZpiObject zpiObject, Action callback = null)
        {
            if((zpiObject.SubSystem == SubSystem.SYS && zpiObject.CommandId == 0) 
                || (zpiObject.SubSystem == SubSystem.SAPI && zpiObject.CommandId == 9)) //resetReq or systemReset
            {
                _resetting = true;
                // clear all pending requests, since the system is reset
                _txQueue.Clear();

                // if AREQ:SYS:RESET does not return in 30 sec
                // release the lock to avoid the requests from enqueuing
                if (_resetting && _resetTimer.ElapsedMilliseconds > 30000)
                {
                    _spinLock = false;
                }                
            } else
            {
                _spinLock = false;
                ScheduleNextSend();
                callback?.Invoke();
            }

            return Unpi.Send((int)MessageType.AREQ, (int)zpiObject.SubSystem, zpiObject.CommandId, zpiObject.Frame);
        }

        private void ScheduleNextSend()
        {
            if(_txQueue.Count > 0)
            {
                _txQueue.RemoveAt(0);
            }
        }

        private void ParseIncomingData(Packet data)
        {
            ZpiObject zpiObject = new ZpiObject((SubSystem)data.SubSystem, data.Cmd1);

            zpiObject.Parse((MessageType)data.Type, data.Length, data.Payload, (string error, ArgumentCollection result) =>
            {
                zpiObject.Arguments = result;

                MtIcomingDataHandler(error, zpiObject);
            });        
        }

        private void MtIcomingDataHandler(string error, ZpiObject data)
        {
            if(data.Type == MessageType.SRSP)
            {
                SyncResponse?.Invoke(this, data);
            }
            else if(data.Type == MessageType.AREQ)
            {
                AsyncResponse?.Invoke(this, data);
            }
        }
    }
}

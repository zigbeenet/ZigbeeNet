﻿using System;
using System.Collections.Generic;
using System.Text;
using ZigbeeNet.CC.Packet;
using ZigbeeNet.CC.Packet.ZDO;
using ZigbeeNet.Logging;

namespace ZigbeeNet.CC.Network
{
    internal class NetworkStateListener : IAsynchronousCommandListener
    {
        private readonly ILog _logger = LogProvider.For<NetworkStateListener>();

        public event EventHandler<DriverStatus> OnStateChanged;
        
        public void ReceivedAsynchronousCommand(AsynchronousRequest packet)
        {
            if(packet is ZDO_STATE_CHANGE_IND stateInd)
            {
                switch(stateInd.Status)
                {
                    case DeviceState.Started_as_ZigBee_Coordinator:
                        _logger.Debug("Started as Zigbee Coordinator");
                        OnStateChanged?.Invoke(this, DriverStatus.NETWORK_READY);
                        break;
                    default:
                        break;
                }
            }
        }

        public void ReceivedUnclaimedSynchronousCommandResponse(SerialPacket packet)
        {
            // Processing not requiered
            throw new NotImplementedException();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:3.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Ember.Ezsp.Command
{
    using ZigBeeNet.Hardware.Ember.Internal.Serializer;
    
    
    /// <summary>
    /// Class to implement the Ember EZSP command " mfglibStart ".
    /// Activate use of mfglib test routines and enables the radio receiver to report packets it
    /// receives to the mfgLibRxHandler() callback. These packets will not be passed up with a CRC
    /// failure. All other mfglib functions will return an error until the mfglibStart() has been
    /// called
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspMfglibStartRequest : EzspFrameRequest
    {
        
        public const int FRAME_ID = 131;
        
        /// <summary>
        ///  true to generate a mfglibRxHandler callback when a packet is received.
        /// </summary>
        private bool _rxCallback;
        
        private EzspSerializer _serializer;
        
        public EzspMfglibStartRequest()
        {
            _frameId = FRAME_ID;
            _serializer = new EzspSerializer();
        }
        
        /// <summary>
        /// The rxCallback to set as <see cref="bool"/> </summary>
        public void SetRxCallback(bool rxCallback)
        {
            _rxCallback = rxCallback;
        }
        
        /// <summary>
        ///  true to generate a mfglibRxHandler callback when a packet is received.
        /// Return the rxCallback as <see cref="System.Boolean"/>
        /// </summary>
        public bool GetRxCallback()
        {
            return _rxCallback;
        }
        
        /// <summary>
        /// Method for serializing the command fields </summary>
        public override int[] Serialize()
        {
            SerializeHeader(_serializer);
            _serializer.SerializeBool(_rxCallback);
            return _serializer.GetPayload();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspMfglibStartRequest [rxCallback=");
            builder.Append(_rxCallback);
            builder.Append(']');
            return builder.ToString();
        }
    }
}

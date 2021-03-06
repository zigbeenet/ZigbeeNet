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
    /// Class to implement the Ember EZSP command " energyScanRequest ".
    /// Sends a ZDO energy scan request. This request may only be sent by the current network manager
    /// and must be unicast, not broadcast. See ezsp-utils.h for related macros
    /// emberSetNetworkManagerRequest() and emberChangeChannelRequest()
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspEnergyScanRequestRequest : EzspFrameRequest
    {
        
        public const int FRAME_ID = 156;
        
        /// <summary>
        ///  The network address of the node to perform the scan.
        /// </summary>
        private int _target;
        
        /// <summary>
        ///  A mask of the channels to be scanned.
        /// </summary>
        private int _scanChannels;
        
        /// <summary>
        ///  How long to scan on each channel. Allowed values are 0..5, with the scan times as specified by
        /// 802.15.4 (0 = 31ms, 1 = 46ms, 2 = 77ms, 3 = 138ms, 4 = 261ms, 5 = 507ms).
        /// </summary>
        private int _scanDuration;
        
        /// <summary>
        ///  The number of scans to be performed on each channel (1..8).
        /// </summary>
        private int _scanCount;
        
        private EzspSerializer _serializer;
        
        public EzspEnergyScanRequestRequest()
        {
            _frameId = FRAME_ID;
            _serializer = new EzspSerializer();
        }
        
        /// <summary>
        /// The target to set as <see cref="EmberNodeId"/> </summary>
        public void SetTarget(int target)
        {
            _target = target;
        }
        
        /// <summary>
        /// The scanChannels to set as <see cref="uint32_t"/> </summary>
        public void SetScanChannels(int scanChannels)
        {
            _scanChannels = scanChannels;
        }
        
        /// <summary>
        /// The scanDuration to set as <see cref="uint8_t"/> </summary>
        public void SetScanDuration(int scanDuration)
        {
            _scanDuration = scanDuration;
        }
        
        /// <summary>
        /// The scanCount to set as <see cref="uint16_t"/> </summary>
        public void SetScanCount(int scanCount)
        {
            _scanCount = scanCount;
        }
        
        /// <summary>
        ///  The network address of the node to perform the scan.
        /// Return the target as <see cref="System.Int32"/>
        /// </summary>
        public int GetTarget()
        {
            return _target;
        }
        
        /// <summary>
        ///  A mask of the channels to be scanned.
        /// Return the scanChannels as <see cref="System.Int32"/>
        /// </summary>
        public int GetScanChannels()
        {
            return _scanChannels;
        }
        
        /// <summary>
        ///  How long to scan on each channel. Allowed values are 0..5, with the scan times as specified by
        /// 802.15.4 (0 = 31ms, 1 = 46ms, 2 = 77ms, 3 = 138ms, 4 = 261ms, 5 = 507ms).
        /// Return the scanDuration as <see cref="System.Int32"/>
        /// </summary>
        public int GetScanDuration()
        {
            return _scanDuration;
        }
        
        /// <summary>
        ///  The number of scans to be performed on each channel (1..8).
        /// Return the scanCount as <see cref="System.Int32"/>
        /// </summary>
        public int GetScanCount()
        {
            return _scanCount;
        }
        
        /// <summary>
        /// Method for serializing the command fields </summary>
        public override int[] Serialize()
        {
            SerializeHeader(_serializer);
            _serializer.SerializeUInt16(_target);
            _serializer.SerializeUInt32(_scanChannels);
            _serializer.SerializeUInt8(_scanDuration);
            _serializer.SerializeUInt16(_scanCount);
            return _serializer.GetPayload();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspEnergyScanRequestRequest [target=");
            builder.Append(string.Format("0x{0:X04}", _target));
            builder.Append(", scanChannels=");
            builder.Append(string.Format("0x{0:X08}", _scanChannels));
            builder.Append(", scanDuration=");
            builder.Append(_scanDuration);
            builder.Append(", scanCount=");
            builder.Append(_scanCount);
            builder.Append(']');
            return builder.ToString();
        }
    }
}

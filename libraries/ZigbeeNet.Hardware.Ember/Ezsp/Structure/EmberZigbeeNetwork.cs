//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:3.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Ember.Ezsp.Structure
{
    using ZigBeeNet.Hardware.Ember.Internal.Serializer;
    using ZigBeeNet.Hardware.Ember.Ezsp.Structure;
    
    
    /// <summary>
    /// Class to implement the Ember Structure " EmberZigbeeNetwork ".
    /// The parameters of a ZigBee network.
    /// </summary>
    public class EmberZigbeeNetwork
    {
        
        /// <summary>
        ///  The 802.15.4 channel associated with the network.
        /// </summary>
        private int _channel;
        
        /// <summary>
        ///  The network's PAN identifier
        /// </summary>
        private int _panId;
        
        /// <summary>
        ///  The network's extended PAN identifier.
        /// </summary>
        private ExtendedPanId _extendedPanId;
        
        /// <summary>
        ///  Whether the network is allowing MAC associations.
        /// </summary>
        private bool _allowingJoin;
        
        /// <summary>
        ///  The Stack Profile associated with the network.
        /// </summary>
        private int _stackProfile;
        
        /// <summary>
        ///  The instance of the Network.
        /// </summary>
        private int _nwkUpdateId;
        
        public EmberZigbeeNetwork()
        {
        }
        
        public EmberZigbeeNetwork(EzspDeserializer deserializer)
        {
            Deserialize(deserializer);
        }
        
        /// <summary>
        /// The channel to set as <see cref="uint8_t"/> </summary>
        public void SetChannel(int channel)
        {
            _channel = channel;
        }
        
        /// <summary>
        /// The panId to set as <see cref="uint16_t"/> </summary>
        public void SetPanId(int panId)
        {
            _panId = panId;
        }
        
        /// <summary>
        /// The extendedPanId to set as <see cref="ExtendedPanId"/> </summary>
        public void SetExtendedPanId(ExtendedPanId extendedPanId)
        {
            _extendedPanId = extendedPanId;
        }
        
        /// <summary>
        /// The allowingJoin to set as <see cref="bool"/> </summary>
        public void SetAllowingJoin(bool allowingJoin)
        {
            _allowingJoin = allowingJoin;
        }
        
        /// <summary>
        /// The stackProfile to set as <see cref="uint8_t"/> </summary>
        public void SetStackProfile(int stackProfile)
        {
            _stackProfile = stackProfile;
        }
        
        /// <summary>
        /// The nwkUpdateId to set as <see cref="uint8_t"/> </summary>
        public void SetNwkUpdateId(int nwkUpdateId)
        {
            _nwkUpdateId = nwkUpdateId;
        }
        
        /// <summary>
        ///  The 802.15.4 channel associated with the network.
        /// Return the channel as <see cref="System.Int32"/>
        /// </summary>
        public int GetChannel()
        {
            return _channel;
        }
        
        /// <summary>
        ///  The network's PAN identifier
        /// Return the panId as <see cref="System.Int32"/>
        /// </summary>
        public int GetPanId()
        {
            return _panId;
        }
        
        /// <summary>
        ///  The network's extended PAN identifier.
        /// Return the extendedPanId as <see cref="ExtendedPanId"/>
        /// </summary>
        public ExtendedPanId GetExtendedPanId()
        {
            return _extendedPanId;
        }
        
        /// <summary>
        ///  Whether the network is allowing MAC associations.
        /// Return the allowingJoin as <see cref="System.Boolean"/>
        /// </summary>
        public bool GetAllowingJoin()
        {
            return _allowingJoin;
        }
        
        /// <summary>
        ///  The Stack Profile associated with the network.
        /// Return the stackProfile as <see cref="System.Int32"/>
        /// </summary>
        public int GetStackProfile()
        {
            return _stackProfile;
        }
        
        /// <summary>
        ///  The instance of the Network.
        /// Return the nwkUpdateId as <see cref="System.Int32"/>
        /// </summary>
        public int GetNwkUpdateId()
        {
            return _nwkUpdateId;
        }
        
        /// <summary>
        /// Serialise the contents of the EZSP structure. </summary>
        public int[] Serialize(EzspSerializer serializer)
        {
            serializer.SerializeUInt8(_channel);
            serializer.SerializeUInt16(_panId);
            serializer.SerializeExtendedPanId(_extendedPanId);
            serializer.SerializeBool(_allowingJoin);
            serializer.SerializeUInt8(_stackProfile);
            serializer.SerializeUInt8(_nwkUpdateId);
            return serializer.GetPayload();
        }
        
        /// <summary>
        /// Deserialise the contents of the EZSP structure. </summary>
        public void Deserialize(EzspDeserializer deserializer)
        {
            _channel = deserializer.DeserializeUInt8();
            _panId = deserializer.DeserializeUInt16();
            _extendedPanId = deserializer.DeserializeExtendedPanId();
            _allowingJoin = deserializer.DeserializeBool();
            _stackProfile = deserializer.DeserializeUInt8();
            _nwkUpdateId = deserializer.DeserializeUInt8();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EmberZigbeeNetwork [channel=");
            builder.Append(_channel);
            builder.Append(", panId=");
            builder.Append(string.Format("0x{0:X04}", _panId));
            builder.Append(", extendedPanId=");
            builder.Append(_extendedPanId);
            builder.Append(", allowingJoin=");
            builder.Append(_allowingJoin);
            builder.Append(", stackProfile=");
            builder.Append(_stackProfile);
            builder.Append(", nwkUpdateId=");
            builder.Append(_nwkUpdateId);
            builder.Append(']');
            return builder.ToString();
        }
    }
}

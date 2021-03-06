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
    /// Class to implement the Ember EZSP command " getEui64 ".
    /// Returns the EUI64 ID of the local node.
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspGetEui64Response : EzspFrameResponse
    {
        
        public const int FRAME_ID = 38;
        
        /// <summary>
        ///  The 64-bit ID.
        /// </summary>
        private IeeeAddress _eui64;
        
        public EzspGetEui64Response(int[] inputBuffer) : 
                base(inputBuffer)
        {
            _eui64 = deserializer.DeserializeEmberEui64();
        }
        
        /// <summary>
        /// The eui64 to set as <see cref="EmberEUI64"/> </summary>
        public void SetEui64(IeeeAddress eui64)
        {
            _eui64 = eui64;
        }
        
        /// <summary>
        ///  The 64-bit ID.
        /// Return the eui64 as <see cref="IeeeAddress"/>
        /// </summary>
        public IeeeAddress GetEui64()
        {
            return _eui64;
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspGetEui64Response [eui64=");
            builder.Append(_eui64);
            builder.Append(']');
            return builder.ToString();
        }
    }
}

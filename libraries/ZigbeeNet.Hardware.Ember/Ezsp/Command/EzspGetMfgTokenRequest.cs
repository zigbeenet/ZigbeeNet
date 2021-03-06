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
    using ZigBeeNet.Hardware.Ember.Ezsp.Structure;
    
    
    /// <summary>
    /// Class to implement the Ember EZSP command " getMfgToken ".
    /// Retrieves a manufacturing token from the Flash Information Area of the NCP (except for
    /// EZSP_STACK_CAL_DATA which is managed by the stack).
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspGetMfgTokenRequest : EzspFrameRequest
    {
        
        public const int FRAME_ID = 11;
        
        /// <summary>
        ///  Which manufacturing token to read.
        /// </summary>
        private EzspMfgTokenId _tokenId;
        
        private EzspSerializer _serializer;
        
        public EzspGetMfgTokenRequest()
        {
            _frameId = FRAME_ID;
            _serializer = new EzspSerializer();
        }
        
        /// <summary>
        /// The tokenId to set as <see cref="EzspMfgTokenId"/> </summary>
        public void SetTokenId(EzspMfgTokenId tokenId)
        {
            _tokenId = tokenId;
        }
        
        /// <summary>
        ///  Which manufacturing token to read.
        /// Return the tokenId as <see cref="EzspMfgTokenId"/>
        /// </summary>
        public EzspMfgTokenId GetTokenId()
        {
            return _tokenId;
        }
        
        /// <summary>
        /// Method for serializing the command fields </summary>
        public override int[] Serialize()
        {
            SerializeHeader(_serializer);
            _serializer.SerializeEzspMfgTokenId(_tokenId);
            return _serializer.GetPayload();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspGetMfgTokenRequest [tokenId=");
            builder.Append(_tokenId);
            builder.Append(']');
            return builder.ToString();
        }
    }
}

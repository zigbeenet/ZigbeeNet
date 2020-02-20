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
    /// Class to implement the Ember EZSP command " requestLinkKey ".
    /// A function to request a Link Key from the Trust Center with another device on the Network
    /// (which could be the Trust Center). A Link Key with the Trust Center is possible but the
    /// requesting device cannot be the Trust Center. Link Keys are optional in ZigBee Standard
    /// Security and thus the stack cannot know whether the other device supports them. If
    /// EMBER_REQUEST_KEY_TIMEOUT is non-zero on the Trust Center and the partner device is not the
    /// Trust Center, both devices must request keys with their partner device within the time
    /// period. The Trust Center only supports one outstanding key request at a time and therefore
    /// will ignore other requests. If the timeout is zero then the Trust Center will immediately
    /// respond and not wait for the second request. The Trust Center will always immediately
    /// respond to requests for a Link Key with it. Sleepy devices should poll at a higher rate until a
    /// response is received or the request times out. The success or failure of the request is
    /// returned via ezspZigbeeKeyEstablishmentHandler(...).
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspRequestLinkKeyRequest : EzspFrameRequest
    {
        
        public const int FRAME_ID = 20;
        
        /// <summary>
        ///  This is the IEEE address of the partner device that will share the link key.
        /// </summary>
        private IeeeAddress _partner;
        
        private EzspSerializer _serializer;
        
        public EzspRequestLinkKeyRequest()
        {
            _frameId = FRAME_ID;
            _serializer = new EzspSerializer();
        }
        
        /// <summary>
        /// The partner to set as <see cref="EmberEUI64"/> </summary>
        public void SetPartner(IeeeAddress partner)
        {
            _partner = partner;
        }
        
        /// <summary>
        ///  This is the IEEE address of the partner device that will share the link key.
        /// Return the partner as <see cref="IeeeAddress"/>
        /// </summary>
        public IeeeAddress GetPartner()
        {
            return _partner;
        }
        
        /// <summary>
        /// Method for serializing the command fields </summary>
        public override int[] Serialize()
        {
            SerializeHeader(_serializer);
            _serializer.SerializeEmberEui64(_partner);
            return _serializer.GetPayload();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspRequestLinkKeyRequest [partner=");
            builder.Append(_partner);
            builder.Append(']');
            return builder.ToString();
        }
    }
}
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
    /// Class to implement the Ember EZSP command " getBindingRemoteNodeId ".
    /// Returns the node ID for the binding's destination, if the ID is known. If a message is sent
    /// using the binding and the destination's ID is not known, the stack will discover the ID by
    /// broadcasting a ZDO address request. The application can avoid the need for this discovery by
    /// using setBindingRemoteNodeId when it knows the correct ID via some other means. The
    /// destination's node ID is forgotten when the binding is changed, when the local node reboots
    /// or, much more rarely, when the destination node changes its ID in response to an ID conflict.
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspGetBindingRemoteNodeIdResponse : EzspFrameResponse
    {
        
        public const int FRAME_ID = 47;
        
        /// <summary>
        ///  The short ID of the destination node or EMBER_NULL_NODE_ID if no destination is known.
        /// </summary>
        private int _nodeId;
        
        public EzspGetBindingRemoteNodeIdResponse(int[] inputBuffer) : 
                base(inputBuffer)
        {
            _nodeId = deserializer.DeserializeUInt16();
        }
        
        /// <summary>
        /// The nodeId to set as <see cref="EmberNodeId"/> </summary>
        public void SetNodeId(int nodeId)
        {
            _nodeId = nodeId;
        }
        
        /// <summary>
        ///  The short ID of the destination node or EMBER_NULL_NODE_ID if no destination is known.
        /// Return the nodeId as <see cref="System.Int32"/>
        /// </summary>
        public int GetNodeId()
        {
            return _nodeId;
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspGetBindingRemoteNodeIdResponse [nodeId=");
            builder.Append(string.Format("0x{0:X04}", _nodeId));
            builder.Append(']');
            return builder.ToString();
        }
    }
}
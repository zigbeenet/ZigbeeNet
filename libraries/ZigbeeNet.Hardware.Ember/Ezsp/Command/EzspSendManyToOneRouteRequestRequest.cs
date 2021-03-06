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
    /// Class to implement the Ember EZSP command " sendManyToOneRouteRequest ".
    /// Sends a route request packet that creates routes from every node in the network back to this
    /// node. This function should be called by an application that wishes to communicate with many
    /// nodes, for example, a gateway, central monitor, or controller. A device using this function
    /// was referred to as an 'aggregator' in EmberZNet 2.x and earlier, and is referred to as a
    /// 'concentrator' in the ZigBee specification and EmberZNet 3. This function enables large
    /// scale networks, because the other devices do not have to individually perform
    /// bandwidth-intensive route discoveries. Instead, when a remote node sends an APS unicast to
    /// a concentrator, its network layer automatically delivers a special route record packet
    /// first, which lists the network ids of all the intermediate relays. The concentrator can then
    /// use source routing to send outbound APS unicasts. (A source routed message is one in which the
    /// entire route is listed in the network layer header.) This allows the concentrator to
    /// communicate with thousands of devices without requiring large route tables on neighboring
    /// nodes. This function is only available in ZigBee Pro (stack profile 2), and cannot be called
    /// on end devices. Any router can be a concentrator (not just the coordinator), and there can be
    /// multiple concentrators on a network. Note that a concentrator does not automatically
    /// obtain routes to all network nodes after calling this function. Remote applications must
    /// first initiate an inbound APS unicast. Many-to-one routes are not repaired automatically.
    /// Instead, the concentrator application must call this function to rediscover the routes as
    /// necessary, for example, upon failure of a retried APS message. The reason for this is that
    /// there is no scalable one-size-fits-all route repair strategy. A common and recommended
    /// strategy is for the concentrator application to refresh the routes by calling this function
    /// periodically.
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspSendManyToOneRouteRequestRequest : EzspFrameRequest
    {
        
        public const int FRAME_ID = 65;
        
        /// <summary>
        ///  Must be either EMBER_HIGH_RAM_CONCENTRATOR or EMBER_LOW_RAM_CONCENTRATOR. The former
        /// is used when the caller has enough memory to store source routes for the whole network. In that
        /// case, remote nodes stop sending route records once the concentrator has successfully
        /// received one. The latter is used when the concentrator has insufficient RAM to store all
        /// outbound source routes. In that case, route records are sent to the concentrator prior to
        /// every inbound APS unicast.
        /// </summary>
        private EmberConcentratorType _concentratorType;
        
        /// <summary>
        ///  The maximum number of hops the route request will be relayed. A radius of zero is converted to
        /// EMBER_MAX_HOPS.
        /// </summary>
        private int _radius;
        
        private EzspSerializer _serializer;
        
        public EzspSendManyToOneRouteRequestRequest()
        {
            _frameId = FRAME_ID;
            _serializer = new EzspSerializer();
        }
        
        /// <summary>
        /// The concentratorType to set as <see cref="EmberConcentratorType"/> </summary>
        public void SetConcentratorType(EmberConcentratorType concentratorType)
        {
            _concentratorType = concentratorType;
        }
        
        /// <summary>
        /// The radius to set as <see cref="uint8_t"/> </summary>
        public void SetRadius(int radius)
        {
            _radius = radius;
        }
        
        /// <summary>
        ///  Must be either EMBER_HIGH_RAM_CONCENTRATOR or EMBER_LOW_RAM_CONCENTRATOR. The former
        /// is used when the caller has enough memory to store source routes for the whole network. In that
        /// case, remote nodes stop sending route records once the concentrator has successfully
        /// received one. The latter is used when the concentrator has insufficient RAM to store all
        /// outbound source routes. In that case, route records are sent to the concentrator prior to
        /// every inbound APS unicast.
        /// Return the concentratorType as <see cref="EmberConcentratorType"/>
        /// </summary>
        public EmberConcentratorType GetConcentratorType()
        {
            return _concentratorType;
        }
        
        /// <summary>
        ///  The maximum number of hops the route request will be relayed. A radius of zero is converted to
        /// EMBER_MAX_HOPS.
        /// Return the radius as <see cref="System.Int32"/>
        /// </summary>
        public int GetRadius()
        {
            return _radius;
        }
        
        /// <summary>
        /// Method for serializing the command fields </summary>
        public override int[] Serialize()
        {
            SerializeHeader(_serializer);
            _serializer.SerializeEmberConcentratorType(_concentratorType);
            _serializer.SerializeUInt8(_radius);
            return _serializer.GetPayload();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspSendManyToOneRouteRequestRequest [concentratorType=");
            builder.Append(_concentratorType);
            builder.Append(", radius=");
            builder.Append(_radius);
            builder.Append(']');
            return builder.ToString();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using ZigBeeNet.ZCL;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZDO.Field;

namespace ZigBeeNet.ZDO.Command
{
    /**
     * Node Descriptor Response value object class.
     * 
     * The Node_Desc_rsp is generated by a remote device in response to a
     * Node_Desc_req directed to the remote device. This command shall be unicast to
     * the originator of the Node_Desc_req command.
     * 
     * The NWKAddrOfInterest field shall match that specified in the original
     * Node_Desc_req command. If the NWKAddrOfInterest field matches the network
     * address of the remote device, it shall set the Status field to
     * SUCCESS and include its node descriptor in the NodeDescriptor field.
     * 
     * If the NWKAddrOfInterest field does not match the network address of the
     * remote device and it is an end device, it shall set the Status field to
     * INV_REQUESTTYPE and not include the NodeDescriptor field. If the
     * NWKAddrOfInterest field does not match the network address of the remote
     * device and it is the coordinator or a router, it shall determine whether the
     * NWKAddrOfInterest field matches the network address of one of its children. If
     * the NWKAddrOfInterest field does not match the network address of one of the
     * children of the remote device, it shall set the Status field to
     * DEVICE_NOT_FOUND and not include the NodeDescriptor field. If the
     * NWKAddrOfInterest matches the network address of one of the children of the
     * remote device, it shall determine whether a node descriptor for that device is
     * available. If a node descriptor is not available for the child indicated by the
     * NWKAddrOfInterest field, the remote device shall set the Status field to
     * NO_DESCRIPTOR and not include the NodeDescriptor field. If a node descriptor
     * is available for the child indicated by the NWKAddrOfInterest field, the remote
     * device shall set the Status field to SUCCESS and include the node descriptor of
     * the matching child device in the NodeDescriptor field.
     */
    public class NodeDescriptorResponse : ZdoResponse
    {
        /**
         * NWKAddrOfInterest command message field.
         */
        public ushort NwkAddrOfInterest { get; set; }

        /**
         * NodeDescriptor command message field.
         */
        public NodeDescriptor NodeDescriptor { get; set; }

        /**
         * Default constructor.
         */
        public NodeDescriptorResponse()
        {
            ClusterId = 0x8002;
        }

        public override void Serialize(ZclFieldSerializer serializer)
        {
            base.Serialize(serializer);

            serializer.Serialize(Status, ZclDataType.Get(DataType.ZDO_STATUS));
            serializer.Serialize(NwkAddrOfInterest, ZclDataType.Get(DataType.NWK_ADDRESS));
            serializer.Serialize(NodeDescriptor, ZclDataType.Get(DataType.NODE_DESCRIPTOR));
        }

        public override void Deserialize(ZclFieldDeserializer deserializer)
        {
            base.Deserialize(deserializer);

            Status = (ZdoStatus)deserializer.Deserialize(ZclDataType.Get(DataType.ZDO_STATUS));

            if (Status != ZdoStatus.SUCCESS)
            {
                // Don't read the full response if we have an error
                return;
            }
            NwkAddrOfInterest = (ushort)deserializer.Deserialize(ZclDataType.Get(DataType.NWK_ADDRESS));
            NodeDescriptor = (NodeDescriptor)deserializer.Deserialize(ZclDataType.Get(DataType.NODE_DESCRIPTOR));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("NodeDescriptorResponse [")
                   .Append(base.ToString())
                   .Append(", status=")
                   .Append(Status)
                   .Append(", nwkAddrOfInterest=")
                   .Append(NwkAddrOfInterest)
                   .Append(", nodeDescriptor=")
                   .Append(NodeDescriptor)
                   .Append(']');

            return builder.ToString();
        }

    }
}

﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.IASACE;

/**
 * Get Zone Information Command value object class.
 *
 * Cluster: IAS ACE. Command is sentTO the server.
 * This command is a specific command used for the IAS ACE cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 13.02.2019 - 21:42 */
namespace ZigBeeNet.ZCL.Clusters.IASACE
{
   public class GetZoneInformationCommand : ZclCommand
   {
           /**
           * Zone ID command message field.
           */
           public byte ZoneID { get; set; }


           /**
           * Default constructor.
           */
           public GetZoneInformationCommand()
           {
               GenericCommand = false;
               ClusterId = 1281;
               CommandId = 6;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(ZoneID, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        ZoneID = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("GetZoneInformationCommand [");
           builder.Append(base.ToString());
           builder.Append(", ZoneID=");
           builder.Append(ZoneID);
           builder.Append(']');

           return builder.ToString();
       }

   }
}

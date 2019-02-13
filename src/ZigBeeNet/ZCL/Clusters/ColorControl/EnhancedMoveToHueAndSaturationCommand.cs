﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.ColorControl;

/**
 * Enhanced Move To Hue and Saturation Command value object class.
 *
 * Cluster: Color Control. Command is sentTO the server.
 * This command is a specific command used for the Color Control cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 13.02.2019 - 21:42 */
namespace ZigBeeNet.ZCL.Clusters.ColorControl
{
   public class EnhancedMoveToHueAndSaturationCommand : ZclCommand
   {
           /**
           * Hue command message field.
           */
           public ushort Hue { get; set; }

           /**
           * Saturation command message field.
           */
           public byte Saturation { get; set; }

           /**
           * Transition time command message field.
           */
           public ushort TransitionTime { get; set; }


           /**
           * Default constructor.
           */
           public EnhancedMoveToHueAndSaturationCommand()
           {
               GenericCommand = false;
               ClusterId = 768;
               CommandId = 66;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(Hue, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        serializer.Serialize(Saturation, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        serializer.Serialize(TransitionTime, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        Hue = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        Saturation = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        TransitionTime = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("EnhancedMoveToHueAndSaturationCommand [");
           builder.Append(base.ToString());
           builder.Append(", Hue=");
           builder.Append(Hue);
           builder.Append(", Saturation=");
           builder.Append(Saturation);
           builder.Append(", TransitionTime=");
           builder.Append(TransitionTime);
           builder.Append(']');

           return builder.ToString();
       }

   }
}

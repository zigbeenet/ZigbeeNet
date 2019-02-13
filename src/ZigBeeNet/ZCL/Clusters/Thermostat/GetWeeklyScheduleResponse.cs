﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Thermostat;

/**
 * Get Weekly Schedule Response value object class.
 *
 * Cluster: Thermostat. Command is sentFROM the server.
 * This command is a specific command used for the Thermostat cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 13.02.2019 - 21:42 */
namespace ZigBeeNet.ZCL.Clusters.Thermostat
{
   public class GetWeeklyScheduleResponse : ZclCommand
   {
           /**
           * Number of Transitions command message field.
           */
           public byte NumberOfTransitions { get; set; }

           /**
           * Day of Week command message field.
           */
           public byte DayOfWeek { get; set; }

           /**
           * Mode command message field.
           */
           public byte Mode { get; set; }

           /**
           * Transition command message field.
           */
           public ushort Transition { get; set; }

           /**
           * Heat Set command message field.
           */
           public ushort HeatSet { get; set; }

           /**
           * Cool Set command message field.
           */
           public ushort CoolSet { get; set; }


           /**
           * Default constructor.
           */
           public GetWeeklyScheduleResponse()
           {
               GenericCommand = false;
               ClusterId = 513;
               CommandId = 0;
               CommandDirection = ZclCommandDirection.SERVER_TO_CLIENT;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(NumberOfTransitions, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        serializer.Serialize(DayOfWeek, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        serializer.Serialize(Mode, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        serializer.Serialize(Transition, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        serializer.Serialize(HeatSet, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        serializer.Serialize(CoolSet, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        NumberOfTransitions = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        DayOfWeek = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        Mode = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
        Transition = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        HeatSet = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        CoolSet = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("GetWeeklyScheduleResponse [");
           builder.Append(base.ToString());
           builder.Append(", NumberOfTransitions=");
           builder.Append(NumberOfTransitions);
           builder.Append(", DayOfWeek=");
           builder.Append(DayOfWeek);
           builder.Append(", Mode=");
           builder.Append(Mode);
           builder.Append(", Transition=");
           builder.Append(Transition);
           builder.Append(", HeatSet=");
           builder.Append(HeatSet);
           builder.Append(", CoolSet=");
           builder.Append(CoolSet);
           builder.Append(']');

           return builder.ToString();
       }

   }
}

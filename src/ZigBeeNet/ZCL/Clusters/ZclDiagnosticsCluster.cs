﻿// License text here

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZigBeeNet.DAO;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;

/**
 *Diagnosticscluster implementation (Cluster ID 0x0B05).
 *
 * Code is auto-generated. Modifications may be overwritten!
 */
/* Autogenerated: 13.02.2019 - 21:42 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclDiagnosticsCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0B05;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Diagnostics";

       /* Attribute constants */
       /**
       */
       public static ushort ATTR_MACRXBCAST = 0x0100;

       /**
       */
       public static ushort ATTR_MACTXBCAST = 0x0101;

       /**
       */
       public static ushort ATTR_MACRXUCAST = 0x0102;

       /**
       */
       public static ushort ATTR_MACTXUCAST = 0x0103;

       /**
       */
       public static ushort ATTR_MACTXUCASTRETRY = 0x0104;

       /**
       */
       public static ushort ATTR_MACTXUCASTFAIL = 0x0105;

       /**
       */
       public static ushort ATTR_APSRXBCAST = 0x0106;

       /**
       */
       public static ushort ATTR_APSTXBCAST = 0x0107;

       /**
       */
       public static ushort ATTR_APSRXUCAST = 0x0108;

       /**
       */
       public static ushort ATTR_APSTXUCASTSUCCESS = 0x0109;

       /**
       */
       public static ushort ATTR_APSTXUCASTRETRY = 0x010A;

       /**
       */
       public static ushort ATTR_APSTXUCASTFAIL = 0x010B;

       /**
       */
       public static ushort ATTR_ROUTEDISCINITIATED = 0x010C;

       /**
       */
       public static ushort ATTR_NEIGHBORADDED = 0x010D;

       /**
       */
       public static ushort ATTR_NEIGHBORREMOVED = 0x010E;

       /**
       */
       public static ushort ATTR_NEIGHBORSTALE = 0x010F;

       /**
       */
       public static ushort ATTR_JOININDICATION = 0x0110;

       /**
       */
       public static ushort ATTR_CHILDMOVED = 0x0111;

       /**
       */
       public static ushort ATTR_NWKFCFAILURE = 0x0112;

       /**
       */
       public static ushort ATTR_APSFCFAILURE = 0x0113;

       /**
       */
       public static ushort ATTR_APSUNAUTHORIZEDKEY = 0x0114;

       /**
       */
       public static ushort ATTR_NWKDECRYPTFAILURES = 0x0115;

       /**
       */
       public static ushort ATTR_APSDECRYPTFAILURES = 0x0116;

       /**
       */
       public static ushort ATTR_PACKETBUFFERALLOCATEFAILURES = 0x0117;

       /**
       */
       public static ushort ATTR_RELAYEDUCAST = 0x0118;

       /**
       */
       public static ushort ATTR_PHYTOMACQUEUELIMITREACHED = 0x0119;

       /**
       */
       public static ushort ATTR_PACKETVALIDATEDROPCOUNT = 0x011A;

       /**
       */
       public static ushort ATTR_AVERAGEMACRETRYPERAPSMESSAGESENT = 0x011B;

       /**
       */
       public static ushort ATTR_LASTMESSAGELQI = 0x011C;

       /**
       */
       public static ushort ATTR_LASTMESSAGERSSI = 0x011D;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(30);

           ZclClusterType diagnostics = ZclClusterType.GetValueById(ClusterType.DIAGNOSTICS);

           attributeMap.Add(ATTR_MACRXBCAST, new ZclAttribute(diagnostics, ATTR_MACRXBCAST, "MacRxBcast", ZclDataType.Get(DataType.UNSIGNED_32_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_MACTXBCAST, new ZclAttribute(diagnostics, ATTR_MACTXBCAST, "MacTxBcast", ZclDataType.Get(DataType.UNSIGNED_32_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_MACRXUCAST, new ZclAttribute(diagnostics, ATTR_MACRXUCAST, "MacRxUcast", ZclDataType.Get(DataType.UNSIGNED_32_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_MACTXUCAST, new ZclAttribute(diagnostics, ATTR_MACTXUCAST, "MacTxUcast", ZclDataType.Get(DataType.UNSIGNED_32_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_MACTXUCASTRETRY, new ZclAttribute(diagnostics, ATTR_MACTXUCASTRETRY, "MacTxUcastRetry", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_MACTXUCASTFAIL, new ZclAttribute(diagnostics, ATTR_MACTXUCASTFAIL, "MacTxUcastFail", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSRXBCAST, new ZclAttribute(diagnostics, ATTR_APSRXBCAST, "APSRxBcast", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSTXBCAST, new ZclAttribute(diagnostics, ATTR_APSTXBCAST, "APSTxBcast", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSRXUCAST, new ZclAttribute(diagnostics, ATTR_APSRXUCAST, "APSRxUcast", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSTXUCASTSUCCESS, new ZclAttribute(diagnostics, ATTR_APSTXUCASTSUCCESS, "APSTxUcastSuccess", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSTXUCASTRETRY, new ZclAttribute(diagnostics, ATTR_APSTXUCASTRETRY, "APSTxUcastRetry", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSTXUCASTFAIL, new ZclAttribute(diagnostics, ATTR_APSTXUCASTFAIL, "APSTxUcastFail", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_ROUTEDISCINITIATED, new ZclAttribute(diagnostics, ATTR_ROUTEDISCINITIATED, "RouteDiscInitiated", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_NEIGHBORADDED, new ZclAttribute(diagnostics, ATTR_NEIGHBORADDED, "NeighborAdded", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_NEIGHBORREMOVED, new ZclAttribute(diagnostics, ATTR_NEIGHBORREMOVED, "NeighborRemoved", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_NEIGHBORSTALE, new ZclAttribute(diagnostics, ATTR_NEIGHBORSTALE, "NeighborStale", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_JOININDICATION, new ZclAttribute(diagnostics, ATTR_JOININDICATION, "JoinIndication", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_CHILDMOVED, new ZclAttribute(diagnostics, ATTR_CHILDMOVED, "ChildMoved", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_NWKFCFAILURE, new ZclAttribute(diagnostics, ATTR_NWKFCFAILURE, "NWKFCFailure", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSFCFAILURE, new ZclAttribute(diagnostics, ATTR_APSFCFAILURE, "APSFCFailure", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSUNAUTHORIZEDKEY, new ZclAttribute(diagnostics, ATTR_APSUNAUTHORIZEDKEY, "APSUnauthorizedKey", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_NWKDECRYPTFAILURES, new ZclAttribute(diagnostics, ATTR_NWKDECRYPTFAILURES, "NWKDecryptFailures", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APSDECRYPTFAILURES, new ZclAttribute(diagnostics, ATTR_APSDECRYPTFAILURES, "APSDecryptFailures", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_PACKETBUFFERALLOCATEFAILURES, new ZclAttribute(diagnostics, ATTR_PACKETBUFFERALLOCATEFAILURES, "PacketBufferAllocateFailures", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_RELAYEDUCAST, new ZclAttribute(diagnostics, ATTR_RELAYEDUCAST, "RelayedUcast", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_PHYTOMACQUEUELIMITREACHED, new ZclAttribute(diagnostics, ATTR_PHYTOMACQUEUELIMITREACHED, "PhytoMACqueuelimitreached", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_PACKETVALIDATEDROPCOUNT, new ZclAttribute(diagnostics, ATTR_PACKETVALIDATEDROPCOUNT, "PacketValidatedropcount", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_AVERAGEMACRETRYPERAPSMESSAGESENT, new ZclAttribute(diagnostics, ATTR_AVERAGEMACRETRYPERAPSMESSAGESENT, "AverageMACRetryPerAPSMessageSent", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_LASTMESSAGELQI, new ZclAttribute(diagnostics, ATTR_LASTMESSAGELQI, "LastMessageLQI", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_LASTMESSAGERSSI, new ZclAttribute(diagnostics, ATTR_LASTMESSAGERSSI, "LastMessageRSSI", ZclDataType.Get(DataType.SIGNED_8_BIT_INTEGER), true, true, false, false));

        return attributeMap;
       }

       /**
       * Default constructor to create a Diagnostics cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclDiagnosticsCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

       public Task<CommandResult> GetMacRxBcastAsync()
       {
           return Read(_attributes[ATTR_MACRXBCAST]);
       }
       public uint GetMacRxBcast(long refreshPeriod)
       {
           if (_attributes[ATTR_MACRXBCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (uint)_attributes[ATTR_MACRXBCAST].LastValue;
           }

           return (uint)ReadSync(_attributes[ATTR_MACRXBCAST]);
       }

       public Task<CommandResult> GetMacTxBcastAsync()
       {
           return Read(_attributes[ATTR_MACTXBCAST]);
       }
       public uint GetMacTxBcast(long refreshPeriod)
       {
           if (_attributes[ATTR_MACTXBCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (uint)_attributes[ATTR_MACTXBCAST].LastValue;
           }

           return (uint)ReadSync(_attributes[ATTR_MACTXBCAST]);
       }

       public Task<CommandResult> GetMacRxUcastAsync()
       {
           return Read(_attributes[ATTR_MACRXUCAST]);
       }
       public uint GetMacRxUcast(long refreshPeriod)
       {
           if (_attributes[ATTR_MACRXUCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (uint)_attributes[ATTR_MACRXUCAST].LastValue;
           }

           return (uint)ReadSync(_attributes[ATTR_MACRXUCAST]);
       }

       public Task<CommandResult> GetMacTxUcastAsync()
       {
           return Read(_attributes[ATTR_MACTXUCAST]);
       }
       public uint GetMacTxUcast(long refreshPeriod)
       {
           if (_attributes[ATTR_MACTXUCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (uint)_attributes[ATTR_MACTXUCAST].LastValue;
           }

           return (uint)ReadSync(_attributes[ATTR_MACTXUCAST]);
       }

       public Task<CommandResult> GetMacTxUcastRetryAsync()
       {
           return Read(_attributes[ATTR_MACTXUCASTRETRY]);
       }
       public ushort GetMacTxUcastRetry(long refreshPeriod)
       {
           if (_attributes[ATTR_MACTXUCASTRETRY].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MACTXUCASTRETRY].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MACTXUCASTRETRY]);
       }

       public Task<CommandResult> GetMacTxUcastFailAsync()
       {
           return Read(_attributes[ATTR_MACTXUCASTFAIL]);
       }
       public ushort GetMacTxUcastFail(long refreshPeriod)
       {
           if (_attributes[ATTR_MACTXUCASTFAIL].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MACTXUCASTFAIL].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MACTXUCASTFAIL]);
       }

       public Task<CommandResult> GetAPSRxBcastAsync()
       {
           return Read(_attributes[ATTR_APSRXBCAST]);
       }
       public ushort GetAPSRxBcast(long refreshPeriod)
       {
           if (_attributes[ATTR_APSRXBCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSRXBCAST].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSRXBCAST]);
       }

       public Task<CommandResult> GetAPSTxBcastAsync()
       {
           return Read(_attributes[ATTR_APSTXBCAST]);
       }
       public ushort GetAPSTxBcast(long refreshPeriod)
       {
           if (_attributes[ATTR_APSTXBCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSTXBCAST].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSTXBCAST]);
       }

       public Task<CommandResult> GetAPSRxUcastAsync()
       {
           return Read(_attributes[ATTR_APSRXUCAST]);
       }
       public ushort GetAPSRxUcast(long refreshPeriod)
       {
           if (_attributes[ATTR_APSRXUCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSRXUCAST].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSRXUCAST]);
       }

       public Task<CommandResult> GetAPSTxUcastSuccessAsync()
       {
           return Read(_attributes[ATTR_APSTXUCASTSUCCESS]);
       }
       public ushort GetAPSTxUcastSuccess(long refreshPeriod)
       {
           if (_attributes[ATTR_APSTXUCASTSUCCESS].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSTXUCASTSUCCESS].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSTXUCASTSUCCESS]);
       }

       public Task<CommandResult> GetAPSTxUcastRetryAsync()
       {
           return Read(_attributes[ATTR_APSTXUCASTRETRY]);
       }
       public ushort GetAPSTxUcastRetry(long refreshPeriod)
       {
           if (_attributes[ATTR_APSTXUCASTRETRY].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSTXUCASTRETRY].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSTXUCASTRETRY]);
       }

       public Task<CommandResult> GetAPSTxUcastFailAsync()
       {
           return Read(_attributes[ATTR_APSTXUCASTFAIL]);
       }
       public ushort GetAPSTxUcastFail(long refreshPeriod)
       {
           if (_attributes[ATTR_APSTXUCASTFAIL].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSTXUCASTFAIL].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSTXUCASTFAIL]);
       }

       public Task<CommandResult> GetRouteDiscInitiatedAsync()
       {
           return Read(_attributes[ATTR_ROUTEDISCINITIATED]);
       }
       public ushort GetRouteDiscInitiated(long refreshPeriod)
       {
           if (_attributes[ATTR_ROUTEDISCINITIATED].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ROUTEDISCINITIATED].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ROUTEDISCINITIATED]);
       }

       public Task<CommandResult> GetNeighborAddedAsync()
       {
           return Read(_attributes[ATTR_NEIGHBORADDED]);
       }
       public ushort GetNeighborAdded(long refreshPeriod)
       {
           if (_attributes[ATTR_NEIGHBORADDED].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_NEIGHBORADDED].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_NEIGHBORADDED]);
       }

       public Task<CommandResult> GetNeighborRemovedAsync()
       {
           return Read(_attributes[ATTR_NEIGHBORREMOVED]);
       }
       public ushort GetNeighborRemoved(long refreshPeriod)
       {
           if (_attributes[ATTR_NEIGHBORREMOVED].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_NEIGHBORREMOVED].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_NEIGHBORREMOVED]);
       }

       public Task<CommandResult> GetNeighborStaleAsync()
       {
           return Read(_attributes[ATTR_NEIGHBORSTALE]);
       }
       public ushort GetNeighborStale(long refreshPeriod)
       {
           if (_attributes[ATTR_NEIGHBORSTALE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_NEIGHBORSTALE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_NEIGHBORSTALE]);
       }

       public Task<CommandResult> GetJoinIndicationAsync()
       {
           return Read(_attributes[ATTR_JOININDICATION]);
       }
       public ushort GetJoinIndication(long refreshPeriod)
       {
           if (_attributes[ATTR_JOININDICATION].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_JOININDICATION].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_JOININDICATION]);
       }

       public Task<CommandResult> GetChildMovedAsync()
       {
           return Read(_attributes[ATTR_CHILDMOVED]);
       }
       public ushort GetChildMoved(long refreshPeriod)
       {
           if (_attributes[ATTR_CHILDMOVED].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_CHILDMOVED].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_CHILDMOVED]);
       }

       public Task<CommandResult> GetNWKFCFailureAsync()
       {
           return Read(_attributes[ATTR_NWKFCFAILURE]);
       }
       public ushort GetNWKFCFailure(long refreshPeriod)
       {
           if (_attributes[ATTR_NWKFCFAILURE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_NWKFCFAILURE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_NWKFCFAILURE]);
       }

       public Task<CommandResult> GetAPSFCFailureAsync()
       {
           return Read(_attributes[ATTR_APSFCFAILURE]);
       }
       public ushort GetAPSFCFailure(long refreshPeriod)
       {
           if (_attributes[ATTR_APSFCFAILURE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSFCFAILURE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSFCFAILURE]);
       }

       public Task<CommandResult> GetAPSUnauthorizedKeyAsync()
       {
           return Read(_attributes[ATTR_APSUNAUTHORIZEDKEY]);
       }
       public ushort GetAPSUnauthorizedKey(long refreshPeriod)
       {
           if (_attributes[ATTR_APSUNAUTHORIZEDKEY].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSUNAUTHORIZEDKEY].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSUNAUTHORIZEDKEY]);
       }

       public Task<CommandResult> GetNWKDecryptFailuresAsync()
       {
           return Read(_attributes[ATTR_NWKDECRYPTFAILURES]);
       }
       public ushort GetNWKDecryptFailures(long refreshPeriod)
       {
           if (_attributes[ATTR_NWKDECRYPTFAILURES].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_NWKDECRYPTFAILURES].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_NWKDECRYPTFAILURES]);
       }

       public Task<CommandResult> GetAPSDecryptFailuresAsync()
       {
           return Read(_attributes[ATTR_APSDECRYPTFAILURES]);
       }
       public ushort GetAPSDecryptFailures(long refreshPeriod)
       {
           if (_attributes[ATTR_APSDECRYPTFAILURES].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_APSDECRYPTFAILURES].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_APSDECRYPTFAILURES]);
       }

       public Task<CommandResult> GetPacketBufferAllocateFailuresAsync()
       {
           return Read(_attributes[ATTR_PACKETBUFFERALLOCATEFAILURES]);
       }
       public ushort GetPacketBufferAllocateFailures(long refreshPeriod)
       {
           if (_attributes[ATTR_PACKETBUFFERALLOCATEFAILURES].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_PACKETBUFFERALLOCATEFAILURES].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_PACKETBUFFERALLOCATEFAILURES]);
       }

       public Task<CommandResult> GetRelayedUcastAsync()
       {
           return Read(_attributes[ATTR_RELAYEDUCAST]);
       }
       public ushort GetRelayedUcast(long refreshPeriod)
       {
           if (_attributes[ATTR_RELAYEDUCAST].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_RELAYEDUCAST].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_RELAYEDUCAST]);
       }

       public Task<CommandResult> GetPhytoMACqueuelimitreachedAsync()
       {
           return Read(_attributes[ATTR_PHYTOMACQUEUELIMITREACHED]);
       }
       public ushort GetPhytoMACqueuelimitreached(long refreshPeriod)
       {
           if (_attributes[ATTR_PHYTOMACQUEUELIMITREACHED].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_PHYTOMACQUEUELIMITREACHED].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_PHYTOMACQUEUELIMITREACHED]);
       }

       public Task<CommandResult> GetPacketValidatedropcountAsync()
       {
           return Read(_attributes[ATTR_PACKETVALIDATEDROPCOUNT]);
       }
       public ushort GetPacketValidatedropcount(long refreshPeriod)
       {
           if (_attributes[ATTR_PACKETVALIDATEDROPCOUNT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_PACKETVALIDATEDROPCOUNT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_PACKETVALIDATEDROPCOUNT]);
       }

       public Task<CommandResult> GetAverageMACRetryPerAPSMessageSentAsync()
       {
           return Read(_attributes[ATTR_AVERAGEMACRETRYPERAPSMESSAGESENT]);
       }
       public ushort GetAverageMACRetryPerAPSMessageSent(long refreshPeriod)
       {
           if (_attributes[ATTR_AVERAGEMACRETRYPERAPSMESSAGESENT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_AVERAGEMACRETRYPERAPSMESSAGESENT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_AVERAGEMACRETRYPERAPSMESSAGESENT]);
       }

       public Task<CommandResult> GetLastMessageLQIAsync()
       {
           return Read(_attributes[ATTR_LASTMESSAGELQI]);
       }
       public byte GetLastMessageLQI(long refreshPeriod)
       {
           if (_attributes[ATTR_LASTMESSAGELQI].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_LASTMESSAGELQI].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_LASTMESSAGELQI]);
       }

       public Task<CommandResult> GetLastMessageRSSIAsync()
       {
           return Read(_attributes[ATTR_LASTMESSAGERSSI]);
       }
       public sbyte GetLastMessageRSSI(long refreshPeriod)
       {
           if (_attributes[ATTR_LASTMESSAGERSSI].IsLastValueCurrent(refreshPeriod))
           {
               return (sbyte)_attributes[ATTR_LASTMESSAGERSSI].LastValue;
           }

           return (sbyte)ReadSync(_attributes[ATTR_LASTMESSAGERSSI]);
       }

   }
}

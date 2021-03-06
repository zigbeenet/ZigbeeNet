﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZigBeeNet.App;
using ZigBeeNet.Database;
using ZigBeeNet.Transaction;
using ZigBeeNet.ZCL;
using ZigBeeNet.ZCL.Clusters;
using ZigBeeNet.ZCL.Clusters.General;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.Util;
using Microsoft.Extensions.Logging;

namespace ZigBeeNet
{
    public class ZigBeeEndpoint
    {
        /// <summary>
        /// ILogger for logging events for this class
        /// </summary>
        private static ILogger _logger = LogManager.GetLog<ZigBeeEndpoint>();
        // /// The <see cref="ZigBeeNetworkManager"> that manages this endpoint
        // /// </summary>
        //private readonly ZigBeeNetworkManager _networkManager;

        /// <summary>
         /// Link to the parent <see cref="ZigBeeNode"> to which this endpoint belongs
         /// </summary>
        public ZigBeeNode Node { get; private set; }

        /// <summary>
         /// The endpoint number for this endpoint. Applications shall only use endpoints 1-254. Endpoints 241-254 shall be
         /// used only with the approval of the ZigBee Alliance.
         /// </summary>
        public byte EndpointId { get; private set; }

        /// <summary>
         /// The profile ID.
         /// </summary>
        public ushort ProfileId { get; set; }

        /// <summary>
         /// The device ID. Specifies the device description supported on this endpoint. Device description identifiers shall
         /// be obtained from the ZigBee Alliance.
         /// </summary>
        public ushort DeviceId { get; set; }

        /// <summary>
         /// The device version.
         /// </summary>
        public int DeviceVersion { get; set; }

        /// <summary>
         /// List of input clusters supported by the endpoint
         /// </summary>
        private readonly ConcurrentDictionary<int, ZclCluster> _inputClusters = new ConcurrentDictionary<int, ZclCluster>();

        /// <summary>
         /// List of output clusters supported by the endpoint
         /// </summary>
        private readonly ConcurrentDictionary<int, ZclCluster> _outputClusters = new ConcurrentDictionary<int, ZclCluster>();

        /// <summary>
         /// Map of <see cref="ZigBeeApplication">s that are available to this endpoint. Applications are added
         /// with the {@link #addApplication(ZigBeeApplication application)} method and can be retrieved with the
         /// {@link #getApplication(int clusterId)} method.
         /// </summary>
        private readonly ConcurrentDictionary<int, IZigBeeApplication> _applications = new ConcurrentDictionary<int, IZigBeeApplication>();

        /// <summary>
         /// Constructor
         ///
         /// <param name="networkManager">the <see cref="ZigBeeNetworkManager"> to which the endpoint belongs</param>
         /// <param name="node">the parent <see cref="ZigBeeNode"></param>
         /// <param name="endpoint">the endpoint number within the <see cref="ZigBeeNode"></param>
         /// </summary>
        public ZigBeeEndpoint(ZigBeeNode node, byte endpoint)
        {
            this.Node = node;
            this.EndpointId = endpoint;
        }


        /// <summary>
         /// Gets input cluster IDs. This lists the IDs of all clusters the device
         /// supports as a server.
         ///
         /// <returns>the <see cref="Collection"> of input cluster IDs</returns>
         /// </summary>
        public IEnumerable<int> GetInputClusterIds()
        {
            return _inputClusters.Keys;
        }

        /// <summary>
         /// Gets an input cluster
         ///
         /// @deprecated Use {@link #getInputCluster}
         /// @param clusterId
         ///            the cluster number
         /// <returns>the cluster or null if cluster is not found</returns>
         /// </summary>

        /// <summary>
         /// Gets an input cluster
         ///
         /// <param name="clusterId">the cluster number</param>
         /// <returns>the <see cref="ZclCluster"> or null if cluster is not found</returns>
         /// </summary>
        public ZclCluster GetInputCluster(int clusterId)
        {
            _inputClusters.TryGetValue(clusterId, out ZclCluster cluster);
            return cluster;
        }

        /// <summary>
         /// Gets an output cluster
         ///
         /// <param name="clusterId">the cluster number</param>
         /// <returns>the <see cref="ZclCluster"> or null if cluster is not found</returns>
         /// </summary>
        public ZclCluster GetOutputCluster(int clusterId)
        {
            _outputClusters.TryGetValue(clusterId, out ZclCluster cluster);
            return cluster;
        }

        /// <summary>
         /// Sets input cluster IDs.
         ///
         /// @param inputClusterIds
         ///            the input cluster IDs
         /// </summary>
        public void SetInputClusterIds(List<ushort> inputClusterIds)
        {
            this._inputClusters.Clear();

            _logger.LogDebug("{Endpoint}: Setting input clusters {Clusters}", GetEndpointAddress(), inputClusterIds.Select(c => ZclClusterType.GetValueById(c)?.Label ?? $"Cluster #{c}"));

            UpdateClusters(_inputClusters, inputClusterIds, true);
        }

        /// <summary>
         /// Gets the <see cref="IeeeAddress"> for this endpoint from it's parent <see cref="ZigBeeNode">
         ///
         /// <returns>the node <see cref="IeeeAddress"></returns>
         /// </summary>
        public IeeeAddress GetIeeeAddress()
        {
            return Node.IeeeAddress;
        }

        /// <summary>
         /// Gets the endpoint address
         ///
         /// <returns>the <see cref="ZigBeeEndpointAddress"></returns>
         /// </summary>
        public ZigBeeEndpointAddress GetEndpointAddress()
        {
            return new ZigBeeEndpointAddress(Node.NetworkAddress, (byte)EndpointId);
        }

        /// <summary>
         /// Gets output cluster IDs. This provides the IDs of all clusters the endpoint
         /// supports as a client.
         ///
         /// <returns>the <see cref="Collection"> of output cluster IDs</returns>
         /// </summary>
        public IEnumerable<int> GetOutputClusterIds()
        {
            return _outputClusters.Keys;
        }

        /// <summary>
         /// Sets output cluster IDs.
         ///
         /// @param outputClusterIds
         ///            the output cluster IDs
         /// </summary>
        public void SetOutputClusterIds(List<ushort> outputClusterIds)
        {
            this._outputClusters.Clear();

            _logger.LogDebug("{Endpoint}: Setting output clusters {Clusters}", GetEndpointAddress(), outputClusterIds.Select(c => ZclClusterType.GetValueById(c)?.Label ?? $"Cluster #{c}"));

            UpdateClusters(_outputClusters, outputClusterIds, false);
        }

        /// <summary>
         /// Gets a cluster from the input or output cluster list depending on the command <see cref="ZclCommandDirection"> for a
         /// received command.
         /// 
         /// If commandDirection is {@link ZclCommandDirection#CLIENT_TO_SERVER} then the cluster comes from the output
         /// cluster list.
         /// If commandDirection is {@link ZclCommandDirection#SERVER_TO_CLIENT} then the cluster comes from the input
         /// cluster list.
         ///
         /// <param name="clusterId">the cluster ID to get</param>
         /// <param name="direction">the <see cref="ZclCommandDirection"></param>
         /// <returns>the <see cref="ZclCluster"> or null if the cluster is not known</returns>
         /// </summary>
        private ZclCluster GetReceiveCluster(int clusterId, ZclCommandDirection direction)
        {
            if (direction == ZclCommandDirection.CLIENT_TO_SERVER)
            {
                return GetOutputCluster(clusterId);
            }
            else
            {
                return GetInputCluster(clusterId);
            }
        }

        public ZclCluster GetClusterClass(ushort clusterId)
        {
            ZclClusterType clusterType = ZclClusterType.GetValueById(clusterId);
            if (clusterType == null)
            {
                // Unsupported cluster
                _logger.LogDebug("{Endpoint}: Unsupported cluster {Cluster} - using ZclCustomCluster", GetEndpointAddress(), clusterId);
                return new ZclCustomCluster(this, clusterId);
            }

            // Create a cluster class
            return clusterType.ClusterFactory(this);
        }

        private void UpdateClusters(ConcurrentDictionary<int, ZclCluster> clusters, List<ushort> newList, bool isInput)
        {
            // Get a list any clusters that are no longer in the list
            List<int> removeIds = new List<int>();

            foreach (ZclCluster cluster in clusters.Values)
            {
                if (newList.Contains(cluster.GetClusterId()))
                {
                    // The existing cluster is in the new list, so no need to remove it
                    continue;
                }

                removeIds.Add(cluster.GetClusterId());
            }

            // Remove clusters no longer in use
            foreach (int id in removeIds)
            {
                _logger.LogDebug("{Endpoint}: Removing cluster {Cluster}", GetEndpointAddress(), id);
                clusters.TryRemove(id, out ZclCluster not_used);
            }

            // Add any missing clusters into the list
            foreach (ushort id in newList)
            {
                if (!clusters.ContainsKey(id))
                {
                    // Get the cluster type
                    ZclCluster clusterClass = GetClusterClass(id);
                    if (clusterClass == null)
                    {
                        _logger.LogDebug("{EndpointAddress}: Cluster {Cluster} not created", GetEndpointAddress(), id);
                        continue;
                    }

                    if (isInput)
                    {
                        _logger.LogDebug("{EndpointAddress}: Setting cluster {Cluster} as server", GetEndpointAddress(), clusterClass.GetClusterName());
                        clusterClass.SetServer();
                    }
                    else
                    {
                        _logger.LogDebug("{EndpointAddress}: Setting cluster {Cluster} as client", GetEndpointAddress(), clusterClass.GetClusterName());
                        clusterClass.SetClient();
                    }

                    // Add to our list of clusters
                    clusters.TryAdd(id, clusterClass);
                }
            }
        }


        /// <summary>
        /// Adds an application and makes it available to this endpoint.
        /// The cluster used by the server must be in the output clusters list and this will be passed to the
        /// {@link ZclApplication#serverStartup()) method to start the application.
        ///
        /// <param name="application">the new <see cref="ZigBeeApplication"></param>
        /// <returns> the <see cref="ZigBeeStatus"/> of the call. <see cref="ZigBeeStatus.SUCCESS"/> if the application was registered and 
        /// started, and <see cref="ZigBeeStatus.INVALID_STATE"/> if an application is already registered to the cluster </returns>
        /// </summary>
        public ZigBeeStatus AddApplication(IZigBeeApplication application)
        {
            if (_applications.TryAdd(application.GetClusterId(), application))
            {
                _outputClusters.TryGetValue(application.GetClusterId(), out ZclCluster cluster);

                if (cluster == null)
                {
                    _inputClusters.TryGetValue(application.GetClusterId(), out cluster);
                }

                return application.AppStartup(cluster);
            }
            else
            {
                return ZigBeeStatus.INVALID_STATE;
            }
        }

        /// <summary>
        /// Gets the application associated with the clusterId. Returns null if there is no server linked to the requested
        /// cluster
        ///
        /// <param name="clusterId"> the cluster ID of the application to retrieve </param>
        /// <returns>the <see cref="ZigBeeApplication"/> registered to the clusterId or null if no application is registered</returns>
        /// </summary>
        public IZigBeeApplication GetApplication(int clusterId)
        {
            _applications.TryGetValue(clusterId, out IZigBeeApplication app);

            return app;
        }

        /// <summary>
         /// Incoming command handler. The endpoint will process any commands addressed to this endpoint ID and pass o
         /// clusters and applications
         ///
         /// <param name="command">the <see cref="ZclCommand"> received</param>
         /// </summary>
        public void CommandReceived(ZclCommand command)
        {
            if (!command.SourceAddress.Equals(GetEndpointAddress()))
            {
                return;
            }

            // Pass all commands received from this endpoint to any registered applications
            lock (_applications)
            {
                foreach (IZigBeeApplication application in _applications.Values)
                {
                    application.CommandReceived(command);
                }
            }

            // Get the cluster
            ZclCluster cluster = GetReceiveCluster(command.ClusterId, command.CommandDirection);
            if (cluster == null)
            {
                _logger.LogDebug("{EndpointAdress}: Cluster {Cluster} not found for attribute response", GetEndpointAddress(), command.ClusterId);
                return;
            }

            if (command is ReportAttributesCommand reportAttributesCommand)
            {
                // Pass the reports to the cluster
                cluster.HandleAttributeReport(reportAttributesCommand.Reports);
                return;
            }

            if (command is ReadAttributesResponse readAttributesResponse)
            {
                // Pass the reports to the cluster
                cluster.HandleAttributeStatus(readAttributesResponse.Records);
                return;
            }

            // If this is a specific cluster command, pass the command to the cluster command handler
            if (!command.GenericCommand)
            {
                cluster.HandleCommand(command);
            }
        }

        /// <summary>
         /// Gets a <see cref="ZigBeeEndpointDao"> used for serialisation of the <see cref="ZigBeeEndpoint">
         ///
         /// <returns>the <see cref="ZigBeeEndpointDao"></returns>
         /// </summary>
        public ZigBeeEndpointDao GetDao()
        {
            ZigBeeEndpointDao dao = new ZigBeeEndpointDao
            {
                EndpointId = EndpointId,
                ProfileId = ProfileId,
                DeviceId = DeviceId,
                DeviceVersion = DeviceVersion
            };

            List<ZclClusterDao> clusters;

            clusters = new List<ZclClusterDao>();
            foreach (ZclCluster cluster in _inputClusters.Values)
            {
                clusters.Add(cluster.GetDao());
            }

            dao.SetInputClusters(clusters);

            clusters = new List<ZclClusterDao>();
            foreach (ZclCluster cluster in _outputClusters.Values)
            {
                clusters.Add(cluster.GetDao());
            }
            dao.SetOutputClusters(clusters);

            return dao;
        }

        public void SetDao(ZigBeeEndpointDao dao)
        {
            EndpointId = dao.EndpointId;
            ProfileId = dao.ProfileId;
            DeviceId = dao.DeviceId;
            DeviceVersion = dao.DeviceVersion;

            if (dao.InputClusters != null)
            {
                foreach (ZclClusterDao clusterDao in dao.InputClusters)
                {
                    ZclCluster cluster = GetClusterClass(clusterDao.ClusterId);
                    cluster.SetDao(clusterDao);
                    _inputClusters.TryAdd(clusterDao.ClusterId, cluster);
                }
            }

            if (dao.OutputClusters != null)
            {
                foreach (ZclClusterDao clusterDao in dao.OutputClusters)
                {
                    ZclCluster cluster = GetClusterClass(clusterDao.ClusterId);
                    cluster.SetDao(clusterDao);
                    _outputClusters.TryAdd(clusterDao.ClusterId, cluster);
                }
            }
        }

        /// <summary>
         /// Sends ZigBee command without waiting for response.
         ///
         /// <param name="command">the <see cref="ZigBeeCommand"> to send</param>
        /// </summary>
        public void SendTransaction(ZigBeeCommand command)
        {
            command.DestinationAddress = GetEndpointAddress();
            Node.SendTransaction(command);
        }

        /// <summary>
         /// Sends <see cref="ZigBeeCommand"> command and uses the <see cref="ZigBeeTransactionMatcher"> to match the response.
         ///
         /// <param name="command">the <see cref="ZigBeeCommand"> to send</param>
         /// <param name="responseMatcher">the <see cref="ZigBeeTransactionMatcher"> used to match the response to the request</param>
         /// <returns>the <see cref="CommandResult"> future.</returns>
         /// </summary>
        public Task<CommandResult> SendTransaction(ZigBeeCommand command, IZigBeeTransactionMatcher responseMatcher)
        {
            command.DestinationAddress = GetEndpointAddress();
            return Node.SendTransaction(command, responseMatcher);
        }

        public override string ToString()
        {
            return "ZigBeeEndpoint [networkAddress=" + GetEndpointAddress().ToString() + ", profileId="
                    + string.Format("{0:X4}", ProfileId) + ", deviceId=" + DeviceId + ", deviceVersion=" + DeviceVersion
                    + ", inputClusterIds=" + string.Join(",", GetInputClusterIds()) + ", outputClusterIds="
                    + string.Join(",", GetOutputClusterIds())+ "]";
        }
    }
}

﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ZigBeeNet
{
    /// <summary>
    /// Interface for a hardware specific channel. This should reside in the ZCL part of the library
    /// and all hardware implementations should implement this interface
    /// TODO
    /// Add events for received events
    /// Some "short" commands like get nodes or stuff... You know, to keep life simple.
    /// </summary>
    public interface IHardwareChannel
    {
        event EventHandler Started;
        event EventHandler<ZigBeeNode> NewDevice;
        event EventHandler<ZigBeeEndpoint> NewEndpoint;
        event EventHandler<ZigBeeNode> DeviceInfoChanged;

        void Start();
        void Stop();
        Task SendAsync(byte[] payload);

        Task PermitJoinAsync(int time);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Digi.XBee.Internal.Protocol
{
    
    
    /// <summary>
    /// Class to implement the XBee command " Link Key ".
    /// AT Command <b>KY</b></p>Sets the 128-bit AES link key value that the device uses for
    /// encryption and decryption. This command is write-only and cannot be read. If you set KY to 0
    /// the coordinator transmits the network key in the clear to joining devices, and joining
    /// devices acquire the network key in the clear when joining. 
    /// This class provides methods for processing XBee API commands.
    /// </summary>
    public class XBeeLinkKeyResponse : XBeeFrame, IXBeeResponse 
    {
        
        /// <summary>
        /// Response field
        /// </summary>
        private int _frameId;
        
        /// <summary>
        /// Response field
        /// </summary>
        private CommandStatus _commandStatus;
        
        /// <summary>
        ///  Return the frameId as <see cref="System.Int32"/>
        /// </summary>
        public int GetFrameId()
        {
            return _frameId;
        }
        
        /// <summary>
        ///  Return the commandStatus as <see cref="CommandStatus"/>
        /// </summary>
        public CommandStatus GetCommandStatus()
        {
            return _commandStatus;
        }
        
        /// <summary>
        /// Method for deserializing the fields for the response </summary>
        public void Deserialize(int[] incomingData)
        {
            InitializeDeserializer(incomingData);
            _frameId = DeserializeInt8();
            DeserializeAtCommand();
            _commandStatus = DeserializeCommandStatus();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder(379);
            builder.Append("XBeeLinkKeyResponse [frameId=");
            builder.Append(_frameId);
            builder.Append(", commandStatus=");
            builder.Append(_commandStatus);
            builder.Append(']');
            return builder.ToString();
        }
    }
}

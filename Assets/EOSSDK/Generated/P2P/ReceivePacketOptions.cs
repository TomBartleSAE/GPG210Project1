// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.P2P
{
	/// <summary>
	/// Structure containing information about who would like to receive a packet, and how much data can be stored safely.
	/// </summary>
	public class ReceivePacketOptions
	{
		/// <summary>
		/// The Product User ID of the user who is receiving the packet
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The maximum amount of data in bytes that can be safely copied to OutData in the function call
		/// </summary>
		public uint MaxDataSizeBytes { get; set; }

		/// <summary>
		/// An optional channel to request the data for. If NULL, we're retrieving the next packet on any channel
		/// </summary>
		public byte? RequestedChannel { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct ReceivePacketOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private uint m_MaxDataSizeBytes;
		private System.IntPtr m_RequestedChannel;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public uint MaxDataSizeBytes
		{
			set
			{
				m_MaxDataSizeBytes = value;
			}
		}

		public byte? RequestedChannel
		{
			set
			{
				Helper.TryMarshalSet(ref m_RequestedChannel, value);
			}
		}

		public void Set(ReceivePacketOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = P2PInterface.ReceivepacketApiLatest;
				LocalUserId = other.LocalUserId;
				MaxDataSizeBytes = other.MaxDataSizeBytes;
				RequestedChannel = other.RequestedChannel;
			}
		}

		public void Set(object other)
		{
			Set(other as ReceivePacketOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LocalUserId);
			Helper.TryMarshalDispose(ref m_RequestedChannel);
		}
	}
}
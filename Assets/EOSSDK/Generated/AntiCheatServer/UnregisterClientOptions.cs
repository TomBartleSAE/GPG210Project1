// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.AntiCheatServer
{
	public class UnregisterClientOptions
	{
		/// <summary>
		/// Locally unique value describing the remote user, as previously passed to RegisterClient
		/// </summary>
		public System.IntPtr ClientHandle { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct UnregisterClientOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_ClientHandle;

		public System.IntPtr ClientHandle
		{
			set
			{
				m_ClientHandle = value;
			}
		}

		public void Set(UnregisterClientOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = AntiCheatServerInterface.UnregisterclientApiLatest;
				ClientHandle = other.ClientHandle;
			}
		}

		public void Set(object other)
		{
			Set(other as UnregisterClientOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_ClientHandle);
		}
	}
}
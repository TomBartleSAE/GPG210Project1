// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbyInterface.JoinLobby" /> function.
	/// </summary>
	public class JoinLobbyOptions
	{
		/// <summary>
		/// The handle of the lobby to join
		/// </summary>
		public LobbyDetails LobbyDetailsHandle { get; set; }

		/// <summary>
		/// The Product User ID of the local user joining the lobby
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// If true, this lobby will be associated with the user's presence information. A user can only associate one lobby at a time with their presence information.
		/// This affects the ability of the Social Overlay to show game related actions to take in the user's social graph.
		/// 
		/// @note The Social Overlay can handle only one of the following three options at a time:
		/// using the bPresenceEnabled flags within the Sessions interface
		/// using the bPresenceEnabled flags within the Lobby interface
		/// using <see cref="Presence.PresenceModification.SetJoinInfo" />
		/// <seealso cref="Presence.PresenceModificationSetJoinInfoOptions" />
		/// <seealso cref="CreateLobbyOptions" />
		/// <seealso cref="JoinLobbyOptions" />
		/// <seealso cref="Sessions.CreateSessionModificationOptions" />
		/// <seealso cref="Sessions.JoinSessionOptions" />
		/// </summary>
		public bool PresenceEnabled { get; set; }

		/// <summary>
		/// (Optional) Set this value to override the default local options for the RTC Room, if it is enabled for this lobby. Set this to NULL if
		/// your application does not use the Lobby RTC Rooms feature, or if you would like to use the default settings. This option is ignored if
		/// the specified lobby does not have an RTC Room enabled and will not cause errors.
		/// </summary>
		public LocalRTCOptions LocalRTCOptions { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct JoinLobbyOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LobbyDetailsHandle;
		private System.IntPtr m_LocalUserId;
		private int m_PresenceEnabled;
		private System.IntPtr m_LocalRTCOptions;

		public LobbyDetails LobbyDetailsHandle
		{
			set
			{
				Helper.TryMarshalSet(ref m_LobbyDetailsHandle, value);
			}
		}

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public bool PresenceEnabled
		{
			set
			{
				Helper.TryMarshalSet(ref m_PresenceEnabled, value);
			}
		}

		public LocalRTCOptions LocalRTCOptions
		{
			set
			{
				Helper.TryMarshalSet<LocalRTCOptionsInternal, LocalRTCOptions>(ref m_LocalRTCOptions, value);
			}
		}

		public void Set(JoinLobbyOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = LobbyInterface.JoinlobbyApiLatest;
				LobbyDetailsHandle = other.LobbyDetailsHandle;
				LocalUserId = other.LocalUserId;
				PresenceEnabled = other.PresenceEnabled;
				LocalRTCOptions = other.LocalRTCOptions;
			}
		}

		public void Set(object other)
		{
			Set(other as JoinLobbyOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LobbyDetailsHandle);
			Helper.TryMarshalDispose(ref m_LocalUserId);
			Helper.TryMarshalDispose(ref m_LocalRTCOptions);
		}
	}
}
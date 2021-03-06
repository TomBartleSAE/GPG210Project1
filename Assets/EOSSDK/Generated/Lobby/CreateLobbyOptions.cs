// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbyInterface.CreateLobby" /> function.
	/// </summary>
	public class CreateLobbyOptions
	{
		/// <summary>
		/// The Product User ID of the local user creating the lobby; this user will automatically join the lobby as its owner
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The maximum number of users who can be in the lobby at a time
		/// </summary>
		public uint MaxLobbyMembers { get; set; }

		/// <summary>
		/// The initial permission level of the lobby
		/// </summary>
		public LobbyPermissionLevel PermissionLevel { get; set; }

		/// <summary>
		/// If true, this lobby will be associated with presence information. A user's presence can only be associated with one lobby at a time.
		/// This affects the ability of the Social Overlay to show game related actions to take in the user's social graph.
		/// 
		/// @note The Social Overlay can handle only one of the following three options at a time:
		/// using the bPresenceEnabled flags within the Sessions interface
		/// using the bPresenceEnabled flags within the Lobby interface
		/// using <see cref="Presence.PresenceModification.SetJoinInfo" />
		/// <seealso cref="Presence.PresenceModificationSetJoinInfoOptions" />
		/// <seealso cref="JoinLobbyOptions" />
		/// <seealso cref="Sessions.CreateSessionModificationOptions" />
		/// <seealso cref="Sessions.JoinSessionOptions" />
		/// </summary>
		public bool PresenceEnabled { get; set; }

		/// <summary>
		/// Are members of the lobby allowed to invite others
		/// </summary>
		public bool AllowInvites { get; set; }

		/// <summary>
		/// Bucket ID associated with the lobby
		/// </summary>
		public string BucketId { get; set; }

		/// <summary>
		/// Is host migration allowed (will the lobby stay open if the original host leaves?)
		/// NOTE: <see cref="LobbyInterface.PromoteMember" /> is still allowed regardless of this setting
		/// </summary>
		public bool DisableHostMigration { get; set; }

		/// <summary>
		/// Creates a real-time communication (RTC) room for all members of this lobby. All members of the lobby will automatically join the RTC
		/// room when they connect to the lobby and they will automatically leave the RTC room when they leave or are removed from the lobby.
		/// While the joining and leaving of the RTC room is automatic, applications will still need to use the EOS RTC interfaces to handle all
		/// other functionality for the room.
		/// <seealso cref="LobbyInterface.GetRTCRoomName" />
		/// <seealso cref="LobbyInterface.AddNotifyRTCRoomConnectionChanged" />
		/// </summary>
		public bool EnableRTCRoom { get; set; }

		/// <summary>
		/// (Optional) Allows the local application to set local audio options for the RTC Room if it is enabled. Set this to NULL if the RTC
		/// RTC room is disabled or you would like to use the defaults.
		/// </summary>
		public LocalRTCOptions LocalRTCOptions { get; set; }

		/// <summary>
		/// (Optional) Set to a globally unique value to override the backend assignment
		/// If not specified the backend service will assign one to the lobby. Do not mix and match override and non override settings.
		/// This value can be of size [<see cref="LobbyInterface.MinLobbyidoverrideLength" />, <see cref="LobbyInterface.MaxLobbyidoverrideLength" />]
		/// </summary>
		public string LobbyId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct CreateLobbyOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private uint m_MaxLobbyMembers;
		private LobbyPermissionLevel m_PermissionLevel;
		private int m_PresenceEnabled;
		private int m_AllowInvites;
		private System.IntPtr m_BucketId;
		private int m_DisableHostMigration;
		private int m_EnableRTCRoom;
		private System.IntPtr m_LocalRTCOptions;
		private System.IntPtr m_LobbyId;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public uint MaxLobbyMembers
		{
			set
			{
				m_MaxLobbyMembers = value;
			}
		}

		public LobbyPermissionLevel PermissionLevel
		{
			set
			{
				m_PermissionLevel = value;
			}
		}

		public bool PresenceEnabled
		{
			set
			{
				Helper.TryMarshalSet(ref m_PresenceEnabled, value);
			}
		}

		public bool AllowInvites
		{
			set
			{
				Helper.TryMarshalSet(ref m_AllowInvites, value);
			}
		}

		public string BucketId
		{
			set
			{
				Helper.TryMarshalSet(ref m_BucketId, value);
			}
		}

		public bool DisableHostMigration
		{
			set
			{
				Helper.TryMarshalSet(ref m_DisableHostMigration, value);
			}
		}

		public bool EnableRTCRoom
		{
			set
			{
				Helper.TryMarshalSet(ref m_EnableRTCRoom, value);
			}
		}

		public LocalRTCOptions LocalRTCOptions
		{
			set
			{
				Helper.TryMarshalSet<LocalRTCOptionsInternal, LocalRTCOptions>(ref m_LocalRTCOptions, value);
			}
		}

		public string LobbyId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LobbyId, value);
			}
		}

		public void Set(CreateLobbyOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = LobbyInterface.CreatelobbyApiLatest;
				LocalUserId = other.LocalUserId;
				MaxLobbyMembers = other.MaxLobbyMembers;
				PermissionLevel = other.PermissionLevel;
				PresenceEnabled = other.PresenceEnabled;
				AllowInvites = other.AllowInvites;
				BucketId = other.BucketId;
				DisableHostMigration = other.DisableHostMigration;
				EnableRTCRoom = other.EnableRTCRoom;
				LocalRTCOptions = other.LocalRTCOptions;
				LobbyId = other.LobbyId;
			}
		}

		public void Set(object other)
		{
			Set(other as CreateLobbyOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LocalUserId);
			Helper.TryMarshalDispose(ref m_BucketId);
			Helper.TryMarshalDispose(ref m_LocalRTCOptions);
			Helper.TryMarshalDispose(ref m_LobbyId);
		}
	}
}
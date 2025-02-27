/*
Copyright (C) 1997-2001 Id Software, Inc.

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

*/
namespace QClient.server;

using game;
using game.types;
using qcommon;
using qcommon.types;
using sys;
using types;
using util;

public class SV_MAIN
{
	/** Addess of group servers.*/
	public static netadr_t[] master_adr = new netadr_t[Defines.MAX_MASTERS];

	static SV_MAIN()
	{
		for (var i = 0; i < Defines.MAX_MASTERS; i++)
			SV_MAIN.master_adr[i] = new();
	}

	public static client_t sv_client; // current client
	public static cvar_t sv_paused;
	public static cvar_t sv_timedemo;
	public static cvar_t sv_enforcetime;
	public static cvar_t timeout; // seconds without any message
	public static cvar_t zombietime; // seconds to sink messages after

	// disconnect
	public static cvar_t rcon_password; // password for remote server commands
	public static cvar_t allow_download;
	public static cvar_t allow_download_players;
	public static cvar_t allow_download_models;
	public static cvar_t allow_download_sounds;
	public static cvar_t allow_download_maps;
	public static cvar_t sv_airaccelerate;
	public static cvar_t sv_noreload; // don't reload level state when

	// reentering
	public static cvar_t maxclients; // FIXME: rename sv_maxclients
	public static cvar_t sv_showclamp;
	public static cvar_t hostname;
	public static cvar_t public_server; // should heartbeats be sent
	public static cvar_t sv_reconnect_limit; // minimum seconds between connect

	// messages

	/**
     * Send a message to the master every few minutes to let it know we are
     * alive, and log information.
     */
	public static readonly int HEARTBEAT_SECONDS = 300;

	/**
     * Called when the player is totally leaving the server, either willingly or
     * unwillingly. This is NOT called if the entire server is quiting or
     * crashing.
     */
	public static void SV_DropClient(client_t drop)
	{
		// add the disconnect
		MSG.WriteByte(drop.netchan.message, Defines.svc_disconnect);

		if (drop.state == Defines.cs_spawned)
		{
			// call the prog function for removing a client
			// this will remove the body, among other things
			PlayerClient.ClientDisconnect(drop.edict);
		}

		if (drop.download != null)
		{
			FS.FreeFile(drop.download);
			drop.download = null;
		}

		drop.state = Defines.cs_zombie; // become free in a few seconds
		drop.name = "";
	}

	/* ==============================================================================
	 * 
	 * CONNECTIONLESS COMMANDS
	 * 
	 * ==============================================================================*/

	/**
     * Builds the string that is sent as heartbeats and status replies.
     */
	public static string SV_StatusString()
	{
		string player;
		var status = "";
		int i;
		client_t cl;
		int statusLength;
		int playerLength;

		status = Cvar.Serverinfo() + "\n";

		for (i = 0; i < SV_MAIN.maxclients.value; i++)
		{
			cl = SV_INIT.svs.clients[i];

			if (cl.state == Defines.cs_connected || cl.state == Defines.cs_spawned)
			{
				player = "" + cl.edict.client.ps.stats[Defines.STAT_FRAGS] + " " + cl.ping + "\"" + cl.name + "\"\n";

				playerLength = player.Length;
				statusLength = status.Length;

				if (statusLength + playerLength >= 1024)
					break; // can't hold any more

				status += player;
			}
		}

		return status;
	}

	/**
     * Responds with all the info that qplug or qspy can see
     */
	public static void SVC_Status()
	{
		Netchan.OutOfBandPrint(Defines.NS_SERVER, Globals.net_from, "print\n" + SV_MAIN.SV_StatusString());
	}

	/**
     *  SVC_Ack
     */
	public static void SVC_Ack()
	{
		Com.Printf("Ping acknowledge from " + NET.AdrToString(Globals.net_from) + "\n");
	}

	/**
     * SVC_Info, responds with short info for broadcast scans The second parameter should
     * be the current protocol version number.
     */
	public static void SVC_Info()
	{
		string @string;
		int i, count;
		int version;

		if (SV_MAIN.maxclients.value == 1)
			return; // ignore in single player

		version = Lib.atoi(Cmd.Argv(1));

		if (version != Defines.PROTOCOL_VERSION)
			@string = SV_MAIN.hostname.@string + ": wrong version\n";
		else
		{
			count = 0;

			for (i = 0; i < SV_MAIN.maxclients.value; i++)
			{
				if (SV_INIT.svs.clients[i].state >= Defines.cs_connected)
					count++;
			}

			@string = SV_MAIN.hostname.@string + " " + SV_INIT.sv.name + " " + count + "/" + (int)SV_MAIN.maxclients.value + "\n";
		}

		Netchan.OutOfBandPrint(Defines.NS_SERVER, Globals.net_from, "info\n" + @string);
	}

	/**
     * SVC_Ping, Just responds with an acknowledgement.
     */
	public static void SVC_Ping()
	{
		Netchan.OutOfBandPrint(Defines.NS_SERVER, Globals.net_from, "ack");
	}

	/** 
     * Returns a challenge number that can be used in a subsequent
     * client_connect command. We do this to prevent denial of service attacks
     * that flood the server with invalid connection IPs. With a challenge, they
     * must give a valid IP address.
     */
	public static void SVC_GetChallenge()
	{
		int i;
		int oldest;
		int oldestTime;

		oldest = 0;
		oldestTime = 0x7fffffff;

		// see if we already have a challenge for this ip
		for (i = 0; i < Defines.MAX_CHALLENGES; i++)
		{
			if (NET.CompareBaseAdr(Globals.net_from, SV_INIT.svs.challenges[i].adr))
				break;

			if (SV_INIT.svs.challenges[i].time < oldestTime)
			{
				oldestTime = SV_INIT.svs.challenges[i].time;
				oldest = i;
			}
		}

		if (i == Defines.MAX_CHALLENGES)
		{
			// overwrite the oldest
			SV_INIT.svs.challenges[oldest].challenge = Lib.rand() & 0x7fff;
			SV_INIT.svs.challenges[oldest].adr = Globals.net_from;
			SV_INIT.svs.challenges[oldest].time = (int)Globals.curtime;
			i = oldest;
		}

		// send it back
		Netchan.OutOfBandPrint(Defines.NS_SERVER, Globals.net_from, "challenge " + SV_INIT.svs.challenges[i].challenge);
	}

	/**
     * A connection request that did not come from the master.
     */
	public static void SVC_DirectConnect()
	{
		string userinfo;
		netadr_t adr;
		int i;
		client_t cl;

		int version;
		int qport;

		adr = Globals.net_from;

		Com.DPrintf("SVC_DirectConnect ()\n");

		version = Lib.atoi(Cmd.Argv(1));

		if (version != Defines.PROTOCOL_VERSION)
		{
			Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "print\nServer is version " + Globals.VERSION + "\n");
			Com.DPrintf("    rejected connect from version " + version + "\n");

			return;
		}

		qport = Lib.atoi(Cmd.Argv(2));
		var challenge = Lib.atoi(Cmd.Argv(3));
		userinfo = Cmd.Argv(4);

		// force the IP key/value pair so the game can filter based on ip
		userinfo = Info.Info_SetValueForKey(userinfo, "ip", NET.AdrToString(Globals.net_from));

		// attractloop servers are ONLY for local clients
		if (SV_INIT.sv.attractloop)
		{
			if (!NET.IsLocalAddress(adr))
			{
				Com.Printf("Remote connect in attract loop.  Ignored.\n");
				Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "print\nConnection refused.\n");

				return;
			}
		}

		// see if the challenge is valid
		if (!NET.IsLocalAddress(adr))
		{
			for (i = 0; i < Defines.MAX_CHALLENGES; i++)
			{
				if (NET.CompareBaseAdr(Globals.net_from, SV_INIT.svs.challenges[i].adr))
				{
					if (challenge == SV_INIT.svs.challenges[i].challenge)
						break; // good

					Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "print\nBad challenge.\n");

					return;
				}
			}

			if (i == Defines.MAX_CHALLENGES)
			{
				Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "print\nNo challenge for address.\n");

				return;
			}
		}

		// if there is already a slot for this ip, reuse it
		for (i = 0; i < SV_MAIN.maxclients.value; i++)
		{
			cl = SV_INIT.svs.clients[i];

			if (cl.state == Defines.cs_free)
				continue;

			if (NET.CompareBaseAdr(adr, cl.netchan.remote_address) && (cl.netchan.qport == qport || adr.port == cl.netchan.remote_address.port))
			{
				if (!NET.IsLocalAddress(adr) && SV_INIT.svs.realtime - cl.lastconnect < (int)SV_MAIN.sv_reconnect_limit.value * 1000)
				{
					Com.DPrintf(NET.AdrToString(adr) + ":reconnect rejected : too soon\n");

					return;
				}

				Com.Printf(NET.AdrToString(adr) + ":reconnect\n");

				SV_MAIN.gotnewcl(i, challenge, userinfo, adr, qport);

				return;
			}
		}

		// find a client slot
		//newcl = null;
		var index = -1;

		for (i = 0; i < SV_MAIN.maxclients.value; i++)
		{
			cl = SV_INIT.svs.clients[i];

			if (cl.state == Defines.cs_free)
			{
				index = i;

				break;
			}
		}

		if (index == -1)
		{
			Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "print\nServer is full.\n");
			Com.DPrintf("Rejected a connection.\n");

			return;
		}

		SV_MAIN.gotnewcl(index, challenge, userinfo, adr, qport);
	}

	/**
     * Initializes player structures after successfull connection.
     */
	public static void gotnewcl(int i, int challenge, string userinfo, netadr_t adr, int qport)
	{
		// build a new connection
		// accept the new client
		// this is the only place a client_t is ever initialized

		SV_MAIN.sv_client = SV_INIT.svs.clients[i];

		var edictnum = i + 1;

		var ent = GameBase.g_edicts[edictnum];
		SV_INIT.svs.clients[i].edict = ent;

		// save challenge for checksumming
		SV_INIT.svs.clients[i].challenge = challenge;

		// get the game a chance to reject this connection or modify the
		// userinfo
		if (!PlayerClient.ClientConnect(ent, userinfo))
		{
			if (Info.Info_ValueForKey(userinfo, "rejmsg") != null)
				Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "print\n" + Info.Info_ValueForKey(userinfo, "rejmsg") + "\nConnection refused.\n");
			else
				Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "print\nConnection refused.\n");

			Com.DPrintf("Game rejected a connection.\n");

			return;
		}

		// parse some info from the info strings
		SV_INIT.svs.clients[i].userinfo = userinfo;
		SV_MAIN.SV_UserinfoChanged(SV_INIT.svs.clients[i]);

		// send the connect packet to the client
		Netchan.OutOfBandPrint(Defines.NS_SERVER, adr, "client_connect");

		Netchan.Setup(Defines.NS_SERVER, SV_INIT.svs.clients[i].netchan, adr, qport);

		SV_INIT.svs.clients[i].state = Defines.cs_connected;

		SZ.Init(SV_INIT.svs.clients[i].datagram, SV_INIT.svs.clients[i].datagram_buf, SV_INIT.svs.clients[i].datagram_buf.Length);

		SV_INIT.svs.clients[i].datagram.allowoverflow = true;
		SV_INIT.svs.clients[i].lastmessage = SV_INIT.svs.realtime; // don't timeout
		SV_INIT.svs.clients[i].lastconnect = SV_INIT.svs.realtime;
		Com.DPrintf("new client added.\n");
	}

	/** 
     * Checks if the rcon password is corect.
     */
	public static int Rcon_Validate()
	{
		if (0 == SV_MAIN.rcon_password.@string.Length)
			return 0;

		if (0 != Lib.strcmp(Cmd.Argv(1), SV_MAIN.rcon_password.@string))
			return 0;

		return 1;
	}

	/**
     * A client issued an rcon command. Shift down the remaining args Redirect
     * all printfs fromt hte server to the client.
     */
	public static void SVC_RemoteCommand()
	{
		int i;
		string remaining;

		i = SV_MAIN.Rcon_Validate();

		var msg = Lib.CtoJava(Globals.net_message.data, 4, 1024);

		if (i == 0)
			Com.Printf("Bad rcon from " + NET.AdrToString(Globals.net_from) + ":\n" + msg + "\n");
		else
			Com.Printf("Rcon from " + NET.AdrToString(Globals.net_from) + ":\n" + msg + "\n");

		Com.BeginRedirect(
			Defines.RD_PACKET,
			SV_SEND.sv_outputbuf,
			Defines.SV_OUTPUTBUF_LENGTH,
			(target, buffer) => { SV_SEND.SV_FlushRedirect(target, Lib.stringToBytes(buffer.ToString())); }
		);

		if (0 == SV_MAIN.Rcon_Validate())
			Com.Printf("Bad rcon_password.\n");
		else
		{
			remaining = "";

			for (i = 2; i < Cmd.Argc(); i++)
			{
				remaining += Cmd.Argv(i);
				remaining += " ";
			}

			Cmd.ExecuteString(remaining);
		}

		Com.EndRedirect();
	}

	/**
     * A connectionless packet has four leading 0xff characters to distinguish
     * it from a game channel. Clients that are in the game can still send
     * connectionless packets. It is used also by rcon commands.
     */
	public static void SV_ConnectionlessPacket()
	{
		string s;
		string c;

		MSG.BeginReading(Globals.net_message);
		MSG.ReadLong(Globals.net_message); // skip the -1 marker

		s = MSG.ReadStringLine(Globals.net_message);

		Cmd.TokenizeString(s.ToCharArray(), false);

		c = Cmd.Argv(0);

		//for debugging purposes
		//Com.Printf("Packet " + NET.AdrToString(Netchan.net_from) + " : " + c + "\n");
		//Com.Printf(Lib.hexDump(net_message.data, 64, false) + "\n");

		if (0 == Lib.strcmp(c, "ping"))
			SV_MAIN.SVC_Ping();
		else if (0 == Lib.strcmp(c, "ack"))
			SV_MAIN.SVC_Ack();
		else if (0 == Lib.strcmp(c, "status"))
			SV_MAIN.SVC_Status();
		else if (0 == Lib.strcmp(c, "info"))
			SV_MAIN.SVC_Info();
		else if (0 == Lib.strcmp(c, "getchallenge"))
			SV_MAIN.SVC_GetChallenge();
		else if (0 == Lib.strcmp(c, "connect"))
			SV_MAIN.SVC_DirectConnect();
		else if (0 == Lib.strcmp(c, "rcon"))
			SV_MAIN.SVC_RemoteCommand();
		else
		{
			Com.Printf("bad connectionless packet from " + NET.AdrToString(Globals.net_from) + "\n");
			Com.Printf("[" + s + "]\n");
			Com.Printf("" + Lib.hexDump(Globals.net_message.data, 128, false));
		}
	}

	/**
     * Updates the cl.ping variables.
     */
	public static void SV_CalcPings()
	{
		int i, j;
		client_t cl;
		int total, count;

		for (i = 0; i < SV_MAIN.maxclients.value; i++)
		{
			cl = SV_INIT.svs.clients[i];

			if (cl.state != Defines.cs_spawned)
				continue;

			total = 0;
			count = 0;

			for (j = 0; j < Defines.LATENCY_COUNTS; j++)
			{
				if (cl.frame_latency[j] > 0)
				{
					count++;
					total += cl.frame_latency[j];
				}
			}

			if (0 == count)
				cl.ping = 0;
			else
				cl.ping = total / count;

			// let the game dll know about the ping
			cl.edict.client.ping = cl.ping;
		}
	}

	/**
     * Every few frames, gives all clients an allotment of milliseconds for
     * their command moves. If they exceed it, assume cheating.
     */
	public static void SV_GiveMsec()
	{
		int i;
		client_t cl;

		if ((SV_INIT.sv.framenum & 15) != 0)
			return;

		for (i = 0; i < SV_MAIN.maxclients.value; i++)
		{
			cl = SV_INIT.svs.clients[i];

			if (cl.state == Defines.cs_free)
				continue;

			cl.commandMsec = 1800; // 1600 + some slop
		}
	}

	/**
     * Reads packets from the network or loopback.
     */
	public static void SV_ReadPackets()
	{
		int i;
		client_t cl;
		var qport = 0;

		while (NET.GetPacket(Defines.NS_SERVER, Globals.net_from, Globals.net_message))
		{
			// check for connectionless packet (0xffffffff) first
			if (Globals.net_message.data[0] == 255
			    && Globals.net_message.data[1] == 255
			    && Globals.net_message.data[2] == 255
			    && Globals.net_message.data[3] == 255)
			{
				SV_MAIN.SV_ConnectionlessPacket();

				continue;
			}

			// read the qport out of the message so we can fix up
			// stupid address translating routers
			MSG.BeginReading(Globals.net_message);
			MSG.ReadLong(Globals.net_message); // sequence number
			MSG.ReadLong(Globals.net_message); // sequence number
			qport = MSG.ReadShort(Globals.net_message) & 0xffff;

			// check for packets from connected clients
			for (i = 0; i < SV_MAIN.maxclients.value; i++)
			{
				cl = SV_INIT.svs.clients[i];

				if (cl.state == Defines.cs_free)
					continue;

				if (!NET.CompareBaseAdr(Globals.net_from, cl.netchan.remote_address))
					continue;

				if (cl.netchan.qport != qport)
					continue;

				if (cl.netchan.remote_address.port != Globals.net_from.port)
				{
					Com.Printf("SV_ReadPackets: fixing up a translated port\n");
					cl.netchan.remote_address.port = Globals.net_from.port;
				}

				if (Netchan.Process(cl.netchan, Globals.net_message))
				{
					// this is a valid, sequenced packet, so process it
					if (cl.state != Defines.cs_zombie)
					{
						cl.lastmessage = SV_INIT.svs.realtime; // don't timeout
						SV_USER.SV_ExecuteClientMessage(cl);
					}
				}

				break;
			}

			if (i != SV_MAIN.maxclients.value)
				continue;
		}
	}

	/**
     * If a packet has not been received from a client for timeout.value
     * seconds, drop the conneciton. Server frames are used instead of realtime
     * to avoid dropping the local client while debugging.
     * 
     * When a client is normally dropped, the client_t goes into a zombie state
     * for a few seconds to make sure any final reliable message gets resent if
     * necessary.
     */
	public static void SV_CheckTimeouts()
	{
		int i;
		client_t cl;
		int droppoint;
		int zombiepoint;

		droppoint = (int)(SV_INIT.svs.realtime - 1000 * SV_MAIN.timeout.value);
		zombiepoint = (int)(SV_INIT.svs.realtime - 1000 * SV_MAIN.zombietime.value);

		for (i = 0; i < SV_MAIN.maxclients.value; i++)
		{
			cl = SV_INIT.svs.clients[i];

			// message times may be wrong across a changelevel
			if (cl.lastmessage > SV_INIT.svs.realtime)
				cl.lastmessage = SV_INIT.svs.realtime;

			if (cl.state == Defines.cs_zombie && cl.lastmessage < zombiepoint)
			{
				cl.state = Defines.cs_free; // can now be reused

				continue;
			}

			if ((cl.state == Defines.cs_connected || cl.state == Defines.cs_spawned) && cl.lastmessage < droppoint)
			{
				SV_SEND.SV_BroadcastPrintf(Defines.PRINT_HIGH, cl.name + " timed out\n");
				SV_MAIN.SV_DropClient(cl);
				cl.state = Defines.cs_free; // don't bother with zombie state
			}
		}
	}

	/**
     * SV_PrepWorldFrame
     * 
     * This has to be done before the world logic, because player processing
     * happens outside RunWorldFrame.
     */
	public static void SV_PrepWorldFrame()
	{
		edict_t ent;
		int i;

		for (i = 0; i < GameBase.num_edicts; i++)
		{
			ent = GameBase.g_edicts[i];

			// events only last for a single message
			ent.s.@event = 0;
		}
	}

	/**
     * SV_RunGameFrame.
     */
	public static void SV_RunGameFrame()
	{
		if (Globals.host_speeds.value != 0)
			Globals.time_before_game = Timer.Milliseconds();

		// we always need to bump framenum, even if we
		// don't run the world, otherwise the delta
		// compression can get confused when a client
		// has the "current" frame
		SV_INIT.sv.framenum++;
		SV_INIT.sv.time = SV_INIT.sv.framenum * 100;

		// don't run if paused
		if (0 == SV_MAIN.sv_paused.value || SV_MAIN.maxclients.value > 1)
		{
			GameBase.G_RunFrame();

			// never get more than one tic behind
			if (SV_INIT.sv.time < SV_INIT.svs.realtime)
			{
				if (SV_MAIN.sv_showclamp.value != 0)
					Com.Printf("sv highclamp\n");

				SV_INIT.svs.realtime = SV_INIT.sv.time;
			}
		}

		if (Globals.host_speeds.value != 0)
			Globals.time_after_game = Timer.Milliseconds();
	}

	/**
     * SV_Frame.
     */
	public static void SV_Frame(long msec)
	{
		Globals.time_before_game = Globals.time_after_game = 0;

		// if server is not active, do nothing
		if (!SV_INIT.svs.initialized)
			return;

		SV_INIT.svs.realtime += (int)msec;

		// keep the random time dependent
		Lib.rand();

		// check timeouts
		SV_MAIN.SV_CheckTimeouts();

		// get packets from clients
		SV_MAIN.SV_ReadPackets();

		//if (Game.g_edicts[1] !=null)
		//	Com.p("player at:" + Lib.vtofsbeaty(Game.g_edicts[1].s.origin ));

		// move autonomous things around if enough time has passed
		if (0 == SV_MAIN.sv_timedemo.value && SV_INIT.svs.realtime < SV_INIT.sv.time)
		{
			// never let the time get too far off
			if (SV_INIT.sv.time - SV_INIT.svs.realtime > 100)
			{
				if (SV_MAIN.sv_showclamp.value != 0)
					Com.Printf("sv lowclamp\n");

				SV_INIT.svs.realtime = SV_INIT.sv.time - 100;
			}

			return;
		}

		// update ping based on the last known frame from all clients
		SV_MAIN.SV_CalcPings();

		// give the clients some timeslices
		SV_MAIN.SV_GiveMsec();

		// let everything in the world think and move
		SV_MAIN.SV_RunGameFrame();

		// send messages back to the clients that had packets read this frame
		SV_SEND.SV_SendClientMessages();

		// save the entire world state if recording a serverdemo
		SV_ENTS.SV_RecordDemoMessage();

		// send a heartbeat to the master if needed
		SV_MAIN.Master_Heartbeat();

		// clear teleport flags, etc for next frame
		SV_MAIN.SV_PrepWorldFrame();
	}

	public static void Master_Heartbeat()
	{
		string @string;
		int i;

		// pgm post3.19 change, cvar pointer not validated before dereferencing
		if (Globals.dedicated == null || 0 == Globals.dedicated.value)
			return; // only dedicated servers send heartbeats

		// pgm post3.19 change, cvar pointer not validated before dereferencing
		if (null == SV_MAIN.public_server || 0 == SV_MAIN.public_server.value)
			return; // a private dedicated game

		// check for time wraparound
		if (SV_INIT.svs.last_heartbeat > SV_INIT.svs.realtime)
			SV_INIT.svs.last_heartbeat = SV_INIT.svs.realtime;

		if (SV_INIT.svs.realtime - SV_INIT.svs.last_heartbeat < SV_MAIN.HEARTBEAT_SECONDS * 1000)
			return; // not time to send yet

		SV_INIT.svs.last_heartbeat = SV_INIT.svs.realtime;

		// send the same string that we would give for a status OOB command
		@string = SV_MAIN.SV_StatusString();

		// send to group master
		for (i = 0; i < Defines.MAX_MASTERS; i++)
		{
			if (SV_MAIN.master_adr[i].port != 0)
			{
				Com.Printf("Sending heartbeat to " + NET.AdrToString(SV_MAIN.master_adr[i]) + "\n");
				Netchan.OutOfBandPrint(Defines.NS_SERVER, SV_MAIN.master_adr[i], "heartbeat\n" + @string);
			}
		}
	}

	/**
     * Master_Shutdown, Informs all masters that this server is going down.
     */
	public static void Master_Shutdown()
	{
		int i;

		// pgm post3.19 change, cvar pointer not validated before dereferencing
		if (null == Globals.dedicated || 0 == Globals.dedicated.value)
			return; // only dedicated servers send heartbeats

		// pgm post3.19 change, cvar pointer not validated before dereferencing
		if (null == SV_MAIN.public_server || 0 == SV_MAIN.public_server.value)
			return; // a private dedicated game

		// send to group master
		for (i = 0; i < Defines.MAX_MASTERS; i++)
		{
			if (SV_MAIN.master_adr[i].port != 0)
			{
				if (i > 0)
					Com.Printf("Sending heartbeat to " + NET.AdrToString(SV_MAIN.master_adr[i]) + "\n");

				Netchan.OutOfBandPrint(Defines.NS_SERVER, SV_MAIN.master_adr[i], "shutdown");
			}
		}
	}

	/**
     * Pull specific info from a newly changed userinfo string into a more C
     * freindly form.
     */
	public static void SV_UserinfoChanged(client_t cl)
	{
		string val;
		int i;

		// call prog code to allow overrides
		PlayerClient.ClientUserinfoChanged(cl.edict, cl.userinfo);

		// name for C code
		cl.name = Info.Info_ValueForKey(cl.userinfo, "name");

		// mask off high bit
		//TODO: masking for german umlaute
		//for (i=0 ; i<sizeof(cl.name) ; i++)
		//	cl.name[i] &= 127;

		// rate command
		val = Info.Info_ValueForKey(cl.userinfo, "rate");

		if (val.Length > 0)
		{
			i = Lib.atoi(val);
			cl.rate = i;

			if (cl.rate < 100)
				cl.rate = 100;

			if (cl.rate > 15000)
				cl.rate = 15000;
		}
		else
			cl.rate = 5000;

		// msg command
		val = Info.Info_ValueForKey(cl.userinfo, "msg");

		if (val.Length > 0)
			cl.messagelevel = Lib.atoi(val);
	}

	/**
     * Only called at quake2.exe startup, not for each game
     */
	public static void SV_Init()
	{
		SV_CCMDS.SV_InitOperatorCommands(); //ok.

		SV_MAIN.rcon_password = Cvar.Get("rcon_password", "", 0);
		Cvar.Get("skill", "1", 0);
		Cvar.Get("deathmatch", "0", Defines.CVAR_LATCH);
		Cvar.Get("coop", "0", Defines.CVAR_LATCH);
		Cvar.Get("dmflags", "" + Defines.DF_INSTANT_ITEMS, Defines.CVAR_SERVERINFO);
		Cvar.Get("fraglimit", "0", Defines.CVAR_SERVERINFO);
		Cvar.Get("timelimit", "0", Defines.CVAR_SERVERINFO);
		Cvar.Get("cheats", "0", Defines.CVAR_SERVERINFO | Defines.CVAR_LATCH);
		Cvar.Get("protocol", "" + Defines.PROTOCOL_VERSION, Defines.CVAR_SERVERINFO | Defines.CVAR_NOSET);

		SV_MAIN.maxclients = Cvar.Get("maxclients", "1", Defines.CVAR_SERVERINFO | Defines.CVAR_LATCH);
		SV_MAIN.hostname = Cvar.Get("hostname", "noname", Defines.CVAR_SERVERINFO | Defines.CVAR_ARCHIVE);
		SV_MAIN.timeout = Cvar.Get("timeout", "125", 0);
		SV_MAIN.zombietime = Cvar.Get("zombietime", "2", 0);
		SV_MAIN.sv_showclamp = Cvar.Get("showclamp", "0", 0);
		SV_MAIN.sv_paused = Cvar.Get("paused", "0", 0);
		SV_MAIN.sv_timedemo = Cvar.Get("timedemo", "0", 0);
		SV_MAIN.sv_enforcetime = Cvar.Get("sv_enforcetime", "0", 0);

		SV_MAIN.allow_download = Cvar.Get("allow_download", "1", Defines.CVAR_ARCHIVE);
		SV_MAIN.allow_download_players = Cvar.Get("allow_download_players", "0", Defines.CVAR_ARCHIVE);
		SV_MAIN.allow_download_models = Cvar.Get("allow_download_models", "1", Defines.CVAR_ARCHIVE);
		SV_MAIN.allow_download_sounds = Cvar.Get("allow_download_sounds", "1", Defines.CVAR_ARCHIVE);
		SV_MAIN.allow_download_maps = Cvar.Get("allow_download_maps", "1", Defines.CVAR_ARCHIVE);

		SV_MAIN.sv_noreload = Cvar.Get("sv_noreload", "0", 0);
		SV_MAIN.sv_airaccelerate = Cvar.Get("sv_airaccelerate", "0", Defines.CVAR_LATCH);
		SV_MAIN.public_server = Cvar.Get("public", "0", 0);
		SV_MAIN.sv_reconnect_limit = Cvar.Get("sv_reconnect_limit", "3", Defines.CVAR_ARCHIVE);

		SZ.Init(Globals.net_message, Globals.net_message_buffer, Globals.net_message_buffer.Length);
	}

	/**
     * Used by SV_Shutdown to send a final message to all connected clients
     * before the server goes down. The messages are sent immediately, not just
     * stuck on the outgoing message list, because the server is going to
     * totally exit after returning from this function.
     */
	public static void SV_FinalMessage(string message, bool reconnect)
	{
		int i;
		client_t cl;

		SZ.Clear(Globals.net_message);
		MSG.WriteByte(Globals.net_message, Defines.svc_print);
		MSG.WriteByte(Globals.net_message, Defines.PRINT_HIGH);
		MSG.WriteString(Globals.net_message, message);

		if (reconnect)
			MSG.WriteByte(Globals.net_message, Defines.svc_reconnect);
		else
			MSG.WriteByte(Globals.net_message, Defines.svc_disconnect);

		// send it twice
		// stagger the packets to crutch operating system limited buffers

		for (i = 0; i < SV_INIT.svs.clients.Length; i++)
		{
			cl = SV_INIT.svs.clients[i];

			if (cl.state >= Defines.cs_connected)
				Netchan.Transmit(cl.netchan, Globals.net_message.cursize, Globals.net_message.data);
		}

		for (i = 0; i < SV_INIT.svs.clients.Length; i++)
		{
			cl = SV_INIT.svs.clients[i];

			if (cl.state >= Defines.cs_connected)
				Netchan.Transmit(cl.netchan, Globals.net_message.cursize, Globals.net_message.data);
		}
	}

	/**
     * Called when each game quits, before Sys_Quit or Sys_Error.
     */
	public static void SV_Shutdown(string finalmsg, bool reconnect)
	{
		if (SV_INIT.svs.clients != null)
			SV_MAIN.SV_FinalMessage(finalmsg, reconnect);

		SV_MAIN.Master_Shutdown();

		SV_GAME.SV_ShutdownGameProgs();

		// free current level
		if (SV_INIT.sv.demofile != null)
		{
			try
			{
				SV_INIT.sv.demofile.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		SV_INIT.sv = new();

		Globals.server_state = SV_INIT.sv.state;

		if (SV_INIT.svs.demofile != null)
		{
			try
			{
				SV_INIT.svs.demofile.Close();
			}
			catch (Exception e1)
			{
				Console.WriteLine(e1);
			}
		}

		SV_INIT.svs = new();
	}
}
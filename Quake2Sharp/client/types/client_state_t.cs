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
namespace Quake2Sharp.client.types
{
	using game.types;
	using render.types;
	using sound.types;
	using System.IO;

	public class client_state_t
	{
		public client_state_t()
		{
			for (var n = 0; n < Defines.CMD_BACKUP; n++)
				this.cmds[n] = new();

			for (var i = 0; i < this.frames.Length; i++)
				this.frames[i] = new();

			for (var n = 0; n < Defines.MAX_CONFIGSTRINGS; n++)
				this.configstrings[n] = string.Empty;

			for (var n = 0; n < Defines.MAX_CLIENTS; n++)
				this.clientinfo[n] = new();

			for (var n = 0; n < this.predicted_origins.Length; n++)
				this.predicted_origins[n] = new short[3];
		}

		//
		//	   the client_state_t structure is wiped completely at every
		//	   server map change
		//
		public int timeoutcount;
		public int timedemo_frames;
		public int timedemo_start;
		public bool refresh_prepped; // false if on new level or new ref dll
		public bool sound_prepped; // ambient sounds can start
		public bool force_refdef; // vid has changed, so we can't use a paused refdef
		public int parse_entities; // index (not anded off) into cl_parse_entities[]
		public usercmd_t cmd = new();
		public usercmd_t[] cmds = new usercmd_t[Defines.CMD_BACKUP]; // each mesage will send several old cmds
		public int[] cmd_time = new int[Defines.CMD_BACKUP]; // time sent, for calculating pings
		public short[][] predicted_origins = new short[Defines.CMD_BACKUP][]; // for debug comparing against server
		public float predicted_step; // for stair up smoothing
		public int predicted_step_time;
		public float[] predicted_origin = { 0, 0, 0 }; // generated by CL_PredictMovement
		public float[] predicted_angles = { 0, 0, 0 };
		public float[] prediction_error = { 0, 0, 0 };
		public frame_t frame = new(); // received from server
		public int surpressCount; // number of messages rate supressed
		public frame_t[] frames = new frame_t[Defines.UPDATE_BACKUP];

		// the client maintains its own idea of view angles, which are
		// sent to the server each frame.  It is cleared to 0 upon entering each level.
		// the server sends a delta each frame which is added to the locally
		// tracked view angles to account for standing on rotating objects,
		// and teleport direction changes
		public float[] viewangles = { 0, 0, 0 };
		public int time; // this is the time value that the client

		// is rendering at.  always <= cls.realtime
		public float lerpfrac; // between oldframe and frame
		public refdef_t refdef = new();
		public float[] v_forward = { 0, 0, 0 };
		public float[] v_right = { 0, 0, 0 };
		public float[] v_up = { 0, 0, 0 }; // set when refdef.angles is set

		//
		// transient data from server
		//
		public string layout = ""; // general 2D overlay
		public int[] inventory = new int[Defines.MAX_ITEMS];

		//
		// non-gameserver infornamtion
		// FIXME: move this cinematic stuff into the cin_t structure
		public BinaryReader cinematic_file;
		public int cinematictime; // cls.realtime for first cinematic frame
		public int cinematicframe;
		public byte[] cinematicpalette = new byte[768];
		public bool cinematicpalette_active;

		//
		// server state information
		//
		public bool attractloop; // running the attract loop, any key will menu
		public int servercount; // server identification for prespawns
		public string gamedir = "";
		public int playernum;
		public string[] configstrings = new string[Defines.MAX_CONFIGSTRINGS];

		//
		// locally derived information from server state
		//
		public model_t[] model_draw = new model_t[Defines.MAX_MODELS];
		public cmodel_t[] model_clip = new cmodel_t[Defines.MAX_MODELS];
		public sfx_t[] sound_precache = new sfx_t[Defines.MAX_SOUNDS];
		public image_t[] image_precache = new image_t[Defines.MAX_IMAGES];
		public clientinfo_t[] clientinfo = new clientinfo_t[Defines.MAX_CLIENTS];
		public clientinfo_t baseclientinfo = new();
	}
}

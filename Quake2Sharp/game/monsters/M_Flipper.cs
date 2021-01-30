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
namespace Quake2Sharp.game.monsters
{
	using adapters;
	using types;
	using util;

	public class M_Flipper
	{
		//	This file generated by ModelGen - Do NOT Modify
		public static readonly int FRAME_flpbit01 = 0;
		public static readonly int FRAME_flpbit02 = 1;
		public static readonly int FRAME_flpbit03 = 2;
		public static readonly int FRAME_flpbit04 = 3;
		public static readonly int FRAME_flpbit05 = 4;
		public static readonly int FRAME_flpbit06 = 5;
		public static readonly int FRAME_flpbit07 = 6;
		public static readonly int FRAME_flpbit08 = 7;
		public static readonly int FRAME_flpbit09 = 8;
		public static readonly int FRAME_flpbit10 = 9;
		public static readonly int FRAME_flpbit11 = 10;
		public static readonly int FRAME_flpbit12 = 11;
		public static readonly int FRAME_flpbit13 = 12;
		public static readonly int FRAME_flpbit14 = 13;
		public static readonly int FRAME_flpbit15 = 14;
		public static readonly int FRAME_flpbit16 = 15;
		public static readonly int FRAME_flpbit17 = 16;
		public static readonly int FRAME_flpbit18 = 17;
		public static readonly int FRAME_flpbit19 = 18;
		public static readonly int FRAME_flpbit20 = 19;
		public static readonly int FRAME_flptal01 = 20;
		public static readonly int FRAME_flptal02 = 21;
		public static readonly int FRAME_flptal03 = 22;
		public static readonly int FRAME_flptal04 = 23;
		public static readonly int FRAME_flptal05 = 24;
		public static readonly int FRAME_flptal06 = 25;
		public static readonly int FRAME_flptal07 = 26;
		public static readonly int FRAME_flptal08 = 27;
		public static readonly int FRAME_flptal09 = 28;
		public static readonly int FRAME_flptal10 = 29;
		public static readonly int FRAME_flptal11 = 30;
		public static readonly int FRAME_flptal12 = 31;
		public static readonly int FRAME_flptal13 = 32;
		public static readonly int FRAME_flptal14 = 33;
		public static readonly int FRAME_flptal15 = 34;
		public static readonly int FRAME_flptal16 = 35;
		public static readonly int FRAME_flptal17 = 36;
		public static readonly int FRAME_flptal18 = 37;
		public static readonly int FRAME_flptal19 = 38;
		public static readonly int FRAME_flptal20 = 39;
		public static readonly int FRAME_flptal21 = 40;
		public static readonly int FRAME_flphor01 = 41;
		public static readonly int FRAME_flphor02 = 42;
		public static readonly int FRAME_flphor03 = 43;
		public static readonly int FRAME_flphor04 = 44;
		public static readonly int FRAME_flphor05 = 45;
		public static readonly int FRAME_flphor06 = 46;
		public static readonly int FRAME_flphor07 = 47;
		public static readonly int FRAME_flphor08 = 48;
		public static readonly int FRAME_flphor09 = 49;
		public static readonly int FRAME_flphor10 = 50;
		public static readonly int FRAME_flphor11 = 51;
		public static readonly int FRAME_flphor12 = 52;
		public static readonly int FRAME_flphor13 = 53;
		public static readonly int FRAME_flphor14 = 54;
		public static readonly int FRAME_flphor15 = 55;
		public static readonly int FRAME_flphor16 = 56;
		public static readonly int FRAME_flphor17 = 57;
		public static readonly int FRAME_flphor18 = 58;
		public static readonly int FRAME_flphor19 = 59;
		public static readonly int FRAME_flphor20 = 60;
		public static readonly int FRAME_flphor21 = 61;
		public static readonly int FRAME_flphor22 = 62;
		public static readonly int FRAME_flphor23 = 63;
		public static readonly int FRAME_flphor24 = 64;
		public static readonly int FRAME_flpver01 = 65;
		public static readonly int FRAME_flpver02 = 66;
		public static readonly int FRAME_flpver03 = 67;
		public static readonly int FRAME_flpver04 = 68;
		public static readonly int FRAME_flpver05 = 69;
		public static readonly int FRAME_flpver06 = 70;
		public static readonly int FRAME_flpver07 = 71;
		public static readonly int FRAME_flpver08 = 72;
		public static readonly int FRAME_flpver09 = 73;
		public static readonly int FRAME_flpver10 = 74;
		public static readonly int FRAME_flpver11 = 75;
		public static readonly int FRAME_flpver12 = 76;
		public static readonly int FRAME_flpver13 = 77;
		public static readonly int FRAME_flpver14 = 78;
		public static readonly int FRAME_flpver15 = 79;
		public static readonly int FRAME_flpver16 = 80;
		public static readonly int FRAME_flpver17 = 81;
		public static readonly int FRAME_flpver18 = 82;
		public static readonly int FRAME_flpver19 = 83;
		public static readonly int FRAME_flpver20 = 84;
		public static readonly int FRAME_flpver21 = 85;
		public static readonly int FRAME_flpver22 = 86;
		public static readonly int FRAME_flpver23 = 87;
		public static readonly int FRAME_flpver24 = 88;
		public static readonly int FRAME_flpver25 = 89;
		public static readonly int FRAME_flpver26 = 90;
		public static readonly int FRAME_flpver27 = 91;
		public static readonly int FRAME_flpver28 = 92;
		public static readonly int FRAME_flpver29 = 93;
		public static readonly int FRAME_flppn101 = 94;
		public static readonly int FRAME_flppn102 = 95;
		public static readonly int FRAME_flppn103 = 96;
		public static readonly int FRAME_flppn104 = 97;
		public static readonly int FRAME_flppn105 = 98;
		public static readonly int FRAME_flppn201 = 99;
		public static readonly int FRAME_flppn202 = 100;
		public static readonly int FRAME_flppn203 = 101;
		public static readonly int FRAME_flppn204 = 102;
		public static readonly int FRAME_flppn205 = 103;
		public static readonly int FRAME_flpdth01 = 104;
		public static readonly int FRAME_flpdth02 = 105;
		public static readonly int FRAME_flpdth03 = 106;
		public static readonly int FRAME_flpdth04 = 107;
		public static readonly int FRAME_flpdth05 = 108;
		public static readonly int FRAME_flpdth06 = 109;
		public static readonly int FRAME_flpdth07 = 110;
		public static readonly int FRAME_flpdth08 = 111;
		public static readonly int FRAME_flpdth09 = 112;
		public static readonly int FRAME_flpdth10 = 113;
		public static readonly int FRAME_flpdth11 = 114;
		public static readonly int FRAME_flpdth12 = 115;
		public static readonly int FRAME_flpdth13 = 116;
		public static readonly int FRAME_flpdth14 = 117;
		public static readonly int FRAME_flpdth15 = 118;
		public static readonly int FRAME_flpdth16 = 119;
		public static readonly int FRAME_flpdth17 = 120;
		public static readonly int FRAME_flpdth18 = 121;
		public static readonly int FRAME_flpdth19 = 122;
		public static readonly int FRAME_flpdth20 = 123;
		public static readonly int FRAME_flpdth21 = 124;
		public static readonly int FRAME_flpdth22 = 125;
		public static readonly int FRAME_flpdth23 = 126;
		public static readonly int FRAME_flpdth24 = 127;
		public static readonly int FRAME_flpdth25 = 128;
		public static readonly int FRAME_flpdth26 = 129;
		public static readonly int FRAME_flpdth27 = 130;
		public static readonly int FRAME_flpdth28 = 131;
		public static readonly int FRAME_flpdth29 = 132;
		public static readonly int FRAME_flpdth30 = 133;
		public static readonly int FRAME_flpdth31 = 134;
		public static readonly int FRAME_flpdth32 = 135;
		public static readonly int FRAME_flpdth33 = 136;
		public static readonly int FRAME_flpdth34 = 137;
		public static readonly int FRAME_flpdth35 = 138;
		public static readonly int FRAME_flpdth36 = 139;
		public static readonly int FRAME_flpdth37 = 140;
		public static readonly int FRAME_flpdth38 = 141;
		public static readonly int FRAME_flpdth39 = 142;
		public static readonly int FRAME_flpdth40 = 143;
		public static readonly int FRAME_flpdth41 = 144;
		public static readonly int FRAME_flpdth42 = 145;
		public static readonly int FRAME_flpdth43 = 146;
		public static readonly int FRAME_flpdth44 = 147;
		public static readonly int FRAME_flpdth45 = 148;
		public static readonly int FRAME_flpdth46 = 149;
		public static readonly int FRAME_flpdth47 = 150;
		public static readonly int FRAME_flpdth48 = 151;
		public static readonly int FRAME_flpdth49 = 152;
		public static readonly int FRAME_flpdth50 = 153;
		public static readonly int FRAME_flpdth51 = 154;
		public static readonly int FRAME_flpdth52 = 155;
		public static readonly int FRAME_flpdth53 = 156;
		public static readonly int FRAME_flpdth54 = 157;
		public static readonly int FRAME_flpdth55 = 158;
		public static readonly int FRAME_flpdth56 = 159;
		public static readonly float MODEL_SCALE = 1.000000f;
		private static int sound_chomp;
		private static int sound_attack;
		private static int sound_pain1;
		private static int sound_pain2;
		private static int sound_death;
		private static int sound_idle;
		private static int sound_search;
		private static int sound_sight;
		private static readonly mframe_t[] flipper_frames_stand = { new(GameAI.ai_stand, 0, null) };
		private static readonly mmove_t flipper_move_stand = new(M_Flipper.FRAME_flphor01, M_Flipper.FRAME_flphor01, M_Flipper.flipper_frames_stand, null);

		private static readonly EntThinkAdapter flipper_stand = new("flipper_stand", self =>
		{
			self.monsterinfo.currentmove = M_Flipper.flipper_move_stand;

			return true;
		});

		public static readonly int FLIPPER_RUN_SPEED = 24;

		private static readonly mframe_t[] flipper_frames_run =
		{
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null), // 6
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),

			// 10

			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),

			// 20

			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null),
			new(GameAI.ai_run, M_Flipper.FLIPPER_RUN_SPEED, null) // 29
		};

		private static readonly mmove_t flipper_move_run_loop = new(M_Flipper.FRAME_flpver06, M_Flipper.FRAME_flpver29, M_Flipper.flipper_frames_run, null);

		private static readonly EntThinkAdapter flipper_run_loop = new("flipper_run_loop", self =>
		{
			self.monsterinfo.currentmove = M_Flipper.flipper_move_run_loop;

			return true;
		});

		private static readonly mframe_t[] flipper_frames_run_start =
		{
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null)
		};

		private static readonly mmove_t flipper_move_run_start =
			new(M_Flipper.FRAME_flpver01, M_Flipper.FRAME_flpver06, M_Flipper.flipper_frames_run_start, M_Flipper.flipper_run_loop);

		private static readonly EntThinkAdapter flipper_run = new("flipper_run", self =>
		{
			self.monsterinfo.currentmove = M_Flipper.flipper_move_run_start;

			return true;
		});

		/* Standard Swimming */
		private static readonly mframe_t[] flipper_frames_walk =
		{
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null),
			new(GameAI.ai_walk, 4, null)
		};

		private static readonly mmove_t flipper_move_walk = new(M_Flipper.FRAME_flphor01, M_Flipper.FRAME_flphor24, M_Flipper.flipper_frames_walk, null);

		private static readonly EntThinkAdapter flipper_walk = new("flipper_walk", self =>
		{
			self.monsterinfo.currentmove = M_Flipper.flipper_move_walk;

			return true;
		});

		private static readonly mframe_t[] flipper_frames_start_run =
		{
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, null),
			new(GameAI.ai_run, 8, M_Flipper.flipper_run)
		};

		private static readonly mmove_t flipper_move_start_run =
			new(M_Flipper.FRAME_flphor01, M_Flipper.FRAME_flphor05, M_Flipper.flipper_frames_start_run, null);

		private static readonly EntThinkAdapter flipper_start_run = new("flipper_start_run", self =>
		{
			self.monsterinfo.currentmove = M_Flipper.flipper_move_start_run;

			return true;
		});

		private static readonly mframe_t[] flipper_frames_pain2 =
		{
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null)
		};

		private static readonly mmove_t flipper_move_pain2 =
			new(M_Flipper.FRAME_flppn101, M_Flipper.FRAME_flppn105, M_Flipper.flipper_frames_pain2, M_Flipper.flipper_run);

		private static readonly mframe_t[] flipper_frames_pain1 =
		{
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null)
		};

		private static readonly mmove_t flipper_move_pain1 =
			new(M_Flipper.FRAME_flppn201, M_Flipper.FRAME_flppn205, M_Flipper.flipper_frames_pain1, M_Flipper.flipper_run);

		private static readonly EntThinkAdapter flipper_bite = new("flipper_bite", self =>
		{
			float[] aim = { 0, 0, 0 };

			Math3D.VectorSet(aim, Defines.MELEE_DISTANCE, 0, 0);
			GameWeapon.fire_hit(self, aim, 5, 0);

			return true;
		});

		private static readonly EntThinkAdapter flipper_preattack = new("flipper_preattack", self =>
		{
			GameBase.gi.sound(self, Defines.CHAN_WEAPON, M_Flipper.sound_chomp, 1, Defines.ATTN_NORM, 0);

			return true;
		});

		private static readonly mframe_t[] flipper_frames_attack =
		{
			new(GameAI.ai_charge, 0, M_Flipper.flipper_preattack),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, M_Flipper.flipper_bite),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, M_Flipper.flipper_bite),
			new(GameAI.ai_charge, 0, null)
		};

		private static readonly mmove_t flipper_move_attack =
			new(M_Flipper.FRAME_flpbit01, M_Flipper.FRAME_flpbit20, M_Flipper.flipper_frames_attack, M_Flipper.flipper_run);

		private static readonly EntThinkAdapter flipper_melee = new("flipper_melee", self =>
		{
			self.monsterinfo.currentmove = M_Flipper.flipper_move_attack;

			return true;
		});

		private static readonly EntPainAdapter flipper_pain = new("flipper_pain", (self, other, kick, damage) =>
		{
			int n;

			if (self.health < self.max_health / 2)
				self.s.skinnum = 1;

			if (GameBase.level.time < self.pain_debounce_time)
				return;

			self.pain_debounce_time = GameBase.level.time + 3;

			if (GameBase.skill.value == 3)
				return; // no pain anims in nightmare

			n = (Lib.rand() + 1) % 2;

			if (n == 0)
			{
				GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Flipper.sound_pain1, 1, Defines.ATTN_NORM, 0);
				self.monsterinfo.currentmove = M_Flipper.flipper_move_pain1;
			}
			else
			{
				GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Flipper.sound_pain2, 1, Defines.ATTN_NORM, 0);
				self.monsterinfo.currentmove = M_Flipper.flipper_move_pain2;
			}

			return;
		});

		private static readonly EntThinkAdapter flipper_dead = new("flipper_dead", self =>
		{
			Math3D.VectorSet(self.mins, -16, -16, -24);
			Math3D.VectorSet(self.maxs, 16, 16, -8);
			self.movetype = Defines.MOVETYPE_TOSS;
			self.svflags |= Defines.SVF_DEADMONSTER;
			self.nextthink = 0;
			GameBase.gi.linkentity(self);

			return true;
		});

		private static readonly mframe_t[] flipper_frames_death =
		{
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null)
		};

		private static readonly mmove_t flipper_move_death =
			new(M_Flipper.FRAME_flpdth01, M_Flipper.FRAME_flpdth56, M_Flipper.flipper_frames_death, M_Flipper.flipper_dead);

		private static readonly EntInteractAdapter flipper_sight = new("flipper_sight", (self, other) =>
		{
			GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Flipper.sound_sight, 1, Defines.ATTN_NORM, 0);

			return true;
		});

		private static readonly EntDieAdapter flipper_die = new("flipper_die", (self, inflictor, attacker, damage, point) =>
		{
			int n;

			//	check for gib
			if (self.health <= self.gib_health)
			{
				GameBase.gi.sound(self, Defines.CHAN_VOICE, GameBase.gi.soundindex("misc/udeath.wav"), 1, Defines.ATTN_NORM, 0);

				for (n = 0; n < 2; n++)
					GameMisc.ThrowGib(self, "models/objects/gibs/bone/tris.md2", damage, Defines.GIB_ORGANIC);

				for (n = 0; n < 2; n++)
					GameMisc.ThrowGib(self, "models/objects/gibs/sm_meat/tris.md2", damage, Defines.GIB_ORGANIC);

				GameMisc.ThrowHead(self, "models/objects/gibs/sm_meat/tris.md2", damage, Defines.GIB_ORGANIC);
				self.deadflag = Defines.DEAD_DEAD;

				return;
			}

			if (self.deadflag == Defines.DEAD_DEAD)
				return;

			//	regular death
			GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Flipper.sound_death, 1, Defines.ATTN_NORM, 0);
			self.deadflag = Defines.DEAD_DEAD;
			self.takedamage = Defines.DAMAGE_YES;
			self.monsterinfo.currentmove = M_Flipper.flipper_move_death;
		});

		/*
		 * QUAKED monster_flipper (1 .5 0) (-16 -16 -24) (16 16 32) Ambush
		 * Trigger_Spawn Sight
		 */
		public static void SP_monster_flipper(edict_t self)
		{
			if (GameBase.deathmatch.value != 0)
			{
				GameUtil.G_FreeEdict(self);

				return;
			}

			M_Flipper.sound_pain1 = GameBase.gi.soundindex("flipper/flppain1.wav");
			M_Flipper.sound_pain2 = GameBase.gi.soundindex("flipper/flppain2.wav");
			M_Flipper.sound_death = GameBase.gi.soundindex("flipper/flpdeth1.wav");
			M_Flipper.sound_chomp = GameBase.gi.soundindex("flipper/flpatck1.wav");
			M_Flipper.sound_attack = GameBase.gi.soundindex("flipper/flpatck2.wav");
			M_Flipper.sound_idle = GameBase.gi.soundindex("flipper/flpidle1.wav");
			M_Flipper.sound_search = GameBase.gi.soundindex("flipper/flpsrch1.wav");
			M_Flipper.sound_sight = GameBase.gi.soundindex("flipper/flpsght1.wav");

			self.movetype = Defines.MOVETYPE_STEP;
			self.solid = Defines.SOLID_BBOX;
			self.s.modelindex = GameBase.gi.modelindex("models/monsters/flipper/tris.md2");
			Math3D.VectorSet(self.mins, -16, -16, 0);
			Math3D.VectorSet(self.maxs, 16, 16, 32);

			self.health = 50;
			self.gib_health = -30;
			self.mass = 100;

			self.pain = M_Flipper.flipper_pain;
			self.die = M_Flipper.flipper_die;

			self.monsterinfo.stand = M_Flipper.flipper_stand;
			self.monsterinfo.walk = M_Flipper.flipper_walk;
			self.monsterinfo.run = M_Flipper.flipper_start_run;
			self.monsterinfo.melee = M_Flipper.flipper_melee;
			self.monsterinfo.sight = M_Flipper.flipper_sight;

			GameBase.gi.linkentity(self);

			self.monsterinfo.currentmove = M_Flipper.flipper_move_stand;
			self.monsterinfo.scale = M_Flipper.MODEL_SCALE;

			GameAI.swimmonster_start.think(self);
		}
	}
}

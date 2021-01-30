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

	public class M_Supertank
	{
		// This file generated by ModelGen - Do NOT Modify
		public static readonly int FRAME_attak1_1 = 0;
		public static readonly int FRAME_attak1_2 = 1;
		public static readonly int FRAME_attak1_3 = 2;
		public static readonly int FRAME_attak1_4 = 3;
		public static readonly int FRAME_attak1_5 = 4;
		public static readonly int FRAME_attak1_6 = 5;
		public static readonly int FRAME_attak1_7 = 6;
		public static readonly int FRAME_attak1_8 = 7;
		public static readonly int FRAME_attak1_9 = 8;
		public static readonly int FRAME_attak1_10 = 9;
		public static readonly int FRAME_attak1_11 = 10;
		public static readonly int FRAME_attak1_12 = 11;
		public static readonly int FRAME_attak1_13 = 12;
		public static readonly int FRAME_attak1_14 = 13;
		public static readonly int FRAME_attak1_15 = 14;
		public static readonly int FRAME_attak1_16 = 15;
		public static readonly int FRAME_attak1_17 = 16;
		public static readonly int FRAME_attak1_18 = 17;
		public static readonly int FRAME_attak1_19 = 18;
		public static readonly int FRAME_attak1_20 = 19;
		public static readonly int FRAME_attak2_1 = 20;
		public static readonly int FRAME_attak2_2 = 21;
		public static readonly int FRAME_attak2_3 = 22;
		public static readonly int FRAME_attak2_4 = 23;
		public static readonly int FRAME_attak2_5 = 24;
		public static readonly int FRAME_attak2_6 = 25;
		public static readonly int FRAME_attak2_7 = 26;
		public static readonly int FRAME_attak2_8 = 27;
		public static readonly int FRAME_attak2_9 = 28;
		public static readonly int FRAME_attak2_10 = 29;
		public static readonly int FRAME_attak2_11 = 30;
		public static readonly int FRAME_attak2_12 = 31;
		public static readonly int FRAME_attak2_13 = 32;
		public static readonly int FRAME_attak2_14 = 33;
		public static readonly int FRAME_attak2_15 = 34;
		public static readonly int FRAME_attak2_16 = 35;
		public static readonly int FRAME_attak2_17 = 36;
		public static readonly int FRAME_attak2_18 = 37;
		public static readonly int FRAME_attak2_19 = 38;
		public static readonly int FRAME_attak2_20 = 39;
		public static readonly int FRAME_attak2_21 = 40;
		public static readonly int FRAME_attak2_22 = 41;
		public static readonly int FRAME_attak2_23 = 42;
		public static readonly int FRAME_attak2_24 = 43;
		public static readonly int FRAME_attak2_25 = 44;
		public static readonly int FRAME_attak2_26 = 45;
		public static readonly int FRAME_attak2_27 = 46;
		public static readonly int FRAME_attak3_1 = 47;
		public static readonly int FRAME_attak3_2 = 48;
		public static readonly int FRAME_attak3_3 = 49;
		public static readonly int FRAME_attak3_4 = 50;
		public static readonly int FRAME_attak3_5 = 51;
		public static readonly int FRAME_attak3_6 = 52;
		public static readonly int FRAME_attak3_7 = 53;
		public static readonly int FRAME_attak3_8 = 54;
		public static readonly int FRAME_attak3_9 = 55;
		public static readonly int FRAME_attak3_10 = 56;
		public static readonly int FRAME_attak3_11 = 57;
		public static readonly int FRAME_attak3_12 = 58;
		public static readonly int FRAME_attak3_13 = 59;
		public static readonly int FRAME_attak3_14 = 60;
		public static readonly int FRAME_attak3_15 = 61;
		public static readonly int FRAME_attak3_16 = 62;
		public static readonly int FRAME_attak3_17 = 63;
		public static readonly int FRAME_attak3_18 = 64;
		public static readonly int FRAME_attak3_19 = 65;
		public static readonly int FRAME_attak3_20 = 66;
		public static readonly int FRAME_attak3_21 = 67;
		public static readonly int FRAME_attak3_22 = 68;
		public static readonly int FRAME_attak3_23 = 69;
		public static readonly int FRAME_attak3_24 = 70;
		public static readonly int FRAME_attak3_25 = 71;
		public static readonly int FRAME_attak3_26 = 72;
		public static readonly int FRAME_attak3_27 = 73;
		public static readonly int FRAME_attak4_1 = 74;
		public static readonly int FRAME_attak4_2 = 75;
		public static readonly int FRAME_attak4_3 = 76;
		public static readonly int FRAME_attak4_4 = 77;
		public static readonly int FRAME_attak4_5 = 78;
		public static readonly int FRAME_attak4_6 = 79;
		public static readonly int FRAME_backwd_1 = 80;
		public static readonly int FRAME_backwd_2 = 81;
		public static readonly int FRAME_backwd_3 = 82;
		public static readonly int FRAME_backwd_4 = 83;
		public static readonly int FRAME_backwd_5 = 84;
		public static readonly int FRAME_backwd_6 = 85;
		public static readonly int FRAME_backwd_7 = 86;
		public static readonly int FRAME_backwd_8 = 87;
		public static readonly int FRAME_backwd_9 = 88;
		public static readonly int FRAME_backwd_10 = 89;
		public static readonly int FRAME_backwd_11 = 90;
		public static readonly int FRAME_backwd_12 = 91;
		public static readonly int FRAME_backwd_13 = 92;
		public static readonly int FRAME_backwd_14 = 93;
		public static readonly int FRAME_backwd_15 = 94;
		public static readonly int FRAME_backwd_16 = 95;
		public static readonly int FRAME_backwd_17 = 96;
		public static readonly int FRAME_backwd_18 = 97;
		public static readonly int FRAME_death_1 = 98;
		public static readonly int FRAME_death_2 = 99;
		public static readonly int FRAME_death_3 = 100;
		public static readonly int FRAME_death_4 = 101;
		public static readonly int FRAME_death_5 = 102;
		public static readonly int FRAME_death_6 = 103;
		public static readonly int FRAME_death_7 = 104;
		public static readonly int FRAME_death_8 = 105;
		public static readonly int FRAME_death_9 = 106;
		public static readonly int FRAME_death_10 = 107;
		public static readonly int FRAME_death_11 = 108;
		public static readonly int FRAME_death_12 = 109;
		public static readonly int FRAME_death_13 = 110;
		public static readonly int FRAME_death_14 = 111;
		public static readonly int FRAME_death_15 = 112;
		public static readonly int FRAME_death_16 = 113;
		public static readonly int FRAME_death_17 = 114;
		public static readonly int FRAME_death_18 = 115;
		public static readonly int FRAME_death_19 = 116;
		public static readonly int FRAME_death_20 = 117;
		public static readonly int FRAME_death_21 = 118;
		public static readonly int FRAME_death_22 = 119;
		public static readonly int FRAME_death_23 = 120;
		public static readonly int FRAME_death_24 = 121;
		public static readonly int FRAME_death_31 = 122;
		public static readonly int FRAME_death_32 = 123;
		public static readonly int FRAME_death_33 = 124;
		public static readonly int FRAME_death_45 = 125;
		public static readonly int FRAME_death_46 = 126;
		public static readonly int FRAME_death_47 = 127;
		public static readonly int FRAME_forwrd_1 = 128;
		public static readonly int FRAME_forwrd_2 = 129;
		public static readonly int FRAME_forwrd_3 = 130;
		public static readonly int FRAME_forwrd_4 = 131;
		public static readonly int FRAME_forwrd_5 = 132;
		public static readonly int FRAME_forwrd_6 = 133;
		public static readonly int FRAME_forwrd_7 = 134;
		public static readonly int FRAME_forwrd_8 = 135;
		public static readonly int FRAME_forwrd_9 = 136;
		public static readonly int FRAME_forwrd_10 = 137;
		public static readonly int FRAME_forwrd_11 = 138;
		public static readonly int FRAME_forwrd_12 = 139;
		public static readonly int FRAME_forwrd_13 = 140;
		public static readonly int FRAME_forwrd_14 = 141;
		public static readonly int FRAME_forwrd_15 = 142;
		public static readonly int FRAME_forwrd_16 = 143;
		public static readonly int FRAME_forwrd_17 = 144;
		public static readonly int FRAME_forwrd_18 = 145;
		public static readonly int FRAME_left_1 = 146;
		public static readonly int FRAME_left_2 = 147;
		public static readonly int FRAME_left_3 = 148;
		public static readonly int FRAME_left_4 = 149;
		public static readonly int FRAME_left_5 = 150;
		public static readonly int FRAME_left_6 = 151;
		public static readonly int FRAME_left_7 = 152;
		public static readonly int FRAME_left_8 = 153;
		public static readonly int FRAME_left_9 = 154;
		public static readonly int FRAME_left_10 = 155;
		public static readonly int FRAME_left_11 = 156;
		public static readonly int FRAME_left_12 = 157;
		public static readonly int FRAME_left_13 = 158;
		public static readonly int FRAME_left_14 = 159;
		public static readonly int FRAME_left_15 = 160;
		public static readonly int FRAME_left_16 = 161;
		public static readonly int FRAME_left_17 = 162;
		public static readonly int FRAME_left_18 = 163;
		public static readonly int FRAME_pain1_1 = 164;
		public static readonly int FRAME_pain1_2 = 165;
		public static readonly int FRAME_pain1_3 = 166;
		public static readonly int FRAME_pain1_4 = 167;
		public static readonly int FRAME_pain2_5 = 168;
		public static readonly int FRAME_pain2_6 = 169;
		public static readonly int FRAME_pain2_7 = 170;
		public static readonly int FRAME_pain2_8 = 171;
		public static readonly int FRAME_pain3_9 = 172;
		public static readonly int FRAME_pain3_10 = 173;
		public static readonly int FRAME_pain3_11 = 174;
		public static readonly int FRAME_pain3_12 = 175;
		public static readonly int FRAME_right_1 = 176;
		public static readonly int FRAME_right_2 = 177;
		public static readonly int FRAME_right_3 = 178;
		public static readonly int FRAME_right_4 = 179;
		public static readonly int FRAME_right_5 = 180;
		public static readonly int FRAME_right_6 = 181;
		public static readonly int FRAME_right_7 = 182;
		public static readonly int FRAME_right_8 = 183;
		public static readonly int FRAME_right_9 = 184;
		public static readonly int FRAME_right_10 = 185;
		public static readonly int FRAME_right_11 = 186;
		public static readonly int FRAME_right_12 = 187;
		public static readonly int FRAME_right_13 = 188;
		public static readonly int FRAME_right_14 = 189;
		public static readonly int FRAME_right_15 = 190;
		public static readonly int FRAME_right_16 = 191;
		public static readonly int FRAME_right_17 = 192;
		public static readonly int FRAME_right_18 = 193;
		public static readonly int FRAME_stand_1 = 194;
		public static readonly int FRAME_stand_2 = 195;
		public static readonly int FRAME_stand_3 = 196;
		public static readonly int FRAME_stand_4 = 197;
		public static readonly int FRAME_stand_5 = 198;
		public static readonly int FRAME_stand_6 = 199;
		public static readonly int FRAME_stand_7 = 200;
		public static readonly int FRAME_stand_8 = 201;
		public static readonly int FRAME_stand_9 = 202;
		public static readonly int FRAME_stand_10 = 203;
		public static readonly int FRAME_stand_11 = 204;
		public static readonly int FRAME_stand_12 = 205;
		public static readonly int FRAME_stand_13 = 206;
		public static readonly int FRAME_stand_14 = 207;
		public static readonly int FRAME_stand_15 = 208;
		public static readonly int FRAME_stand_16 = 209;
		public static readonly int FRAME_stand_17 = 210;
		public static readonly int FRAME_stand_18 = 211;
		public static readonly int FRAME_stand_19 = 212;
		public static readonly int FRAME_stand_20 = 213;
		public static readonly int FRAME_stand_21 = 214;
		public static readonly int FRAME_stand_22 = 215;
		public static readonly int FRAME_stand_23 = 216;
		public static readonly int FRAME_stand_24 = 217;
		public static readonly int FRAME_stand_25 = 218;
		public static readonly int FRAME_stand_26 = 219;
		public static readonly int FRAME_stand_27 = 220;
		public static readonly int FRAME_stand_28 = 221;
		public static readonly int FRAME_stand_29 = 222;
		public static readonly int FRAME_stand_30 = 223;
		public static readonly int FRAME_stand_31 = 224;
		public static readonly int FRAME_stand_32 = 225;
		public static readonly int FRAME_stand_33 = 226;
		public static readonly int FRAME_stand_34 = 227;
		public static readonly int FRAME_stand_35 = 228;
		public static readonly int FRAME_stand_36 = 229;
		public static readonly int FRAME_stand_37 = 230;
		public static readonly int FRAME_stand_38 = 231;
		public static readonly int FRAME_stand_39 = 232;
		public static readonly int FRAME_stand_40 = 233;
		public static readonly int FRAME_stand_41 = 234;
		public static readonly int FRAME_stand_42 = 235;
		public static readonly int FRAME_stand_43 = 236;
		public static readonly int FRAME_stand_44 = 237;
		public static readonly int FRAME_stand_45 = 238;
		public static readonly int FRAME_stand_46 = 239;
		public static readonly int FRAME_stand_47 = 240;
		public static readonly int FRAME_stand_48 = 241;
		public static readonly int FRAME_stand_49 = 242;
		public static readonly int FRAME_stand_50 = 243;
		public static readonly int FRAME_stand_51 = 244;
		public static readonly int FRAME_stand_52 = 245;
		public static readonly int FRAME_stand_53 = 246;
		public static readonly int FRAME_stand_54 = 247;
		public static readonly int FRAME_stand_55 = 248;
		public static readonly int FRAME_stand_56 = 249;
		public static readonly int FRAME_stand_57 = 250;
		public static readonly int FRAME_stand_58 = 251;
		public static readonly int FRAME_stand_59 = 252;
		public static readonly int FRAME_stand_60 = 253;
		public static readonly float MODEL_SCALE = 1.000000f;
		private static int sound_pain1;
		private static int sound_pain2;
		private static int sound_pain3;
		private static int sound_death;
		private static int sound_search1;
		private static int sound_search2;
		private static int tread_sound;

		private static readonly EntThinkAdapter TreadSound = new("TreadSound", self =>
		{
			GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Supertank.tread_sound, 1, Defines.ATTN_NORM, 0);

			return true;
		});

		private static readonly EntThinkAdapter supertank_search = new("supertank_search", self =>
		{
			if (Lib.random() < 0.5)
				GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Supertank.sound_search1, 1, Defines.ATTN_NORM, 0);
			else
				GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Supertank.sound_search2, 1, Defines.ATTN_NORM, 0);

			return true;
		});

		//
		// stand
		//

		private static readonly mframe_t[] supertank_frames_stand =
		{
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null),
			new(GameAI.ai_stand, 0, null)
		};

		private static readonly mmove_t supertank_move_stand =
			new(M_Supertank.FRAME_stand_1, M_Supertank.FRAME_stand_60, M_Supertank.supertank_frames_stand, null);

		private static readonly EntThinkAdapter supertank_stand = new("supertank_stand", self =>
		{
			self.monsterinfo.currentmove = M_Supertank.supertank_move_stand;

			return true;
		});

		private static readonly mframe_t[] supertank_frames_run =
		{
			new(GameAI.ai_run, 12, M_Supertank.TreadSound),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null),
			new(GameAI.ai_run, 12, null)
		};

		private static readonly mmove_t supertank_move_run =
			new(M_Supertank.FRAME_forwrd_1, M_Supertank.FRAME_forwrd_18, M_Supertank.supertank_frames_run, null);

		//
		// walk
		//

		private static readonly mframe_t[] supertank_frames_forward =
		{
			new(GameAI.ai_walk, 4, M_Supertank.TreadSound),
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

		private static readonly mmove_t supertank_move_forward =
			new(M_Supertank.FRAME_forwrd_1, M_Supertank.FRAME_forwrd_18, M_Supertank.supertank_frames_forward, null);

		private static EntThinkAdapter supertank_forward = new("supertank_forward", self =>
		{
			self.monsterinfo.currentmove = M_Supertank.supertank_move_forward;

			return true;
		});

		private static readonly EntThinkAdapter supertank_walk = new("supertank_walk", self =>
		{
			self.monsterinfo.currentmove = M_Supertank.supertank_move_forward;

			return true;
		});

		private static readonly EntThinkAdapter supertank_run = new("supertank_run", self =>
		{
			if ((self.monsterinfo.aiflags & Defines.AI_STAND_GROUND) != 0)
				self.monsterinfo.currentmove = M_Supertank.supertank_move_stand;
			else
				self.monsterinfo.currentmove = M_Supertank.supertank_move_run;

			return true;
		});

		//
		// death
		//
		private static readonly EntThinkAdapter supertank_dead = new("supertank_dead", self =>
		{
			Math3D.VectorSet(self.mins, -60, -60, 0);
			Math3D.VectorSet(self.maxs, 60, 60, 72);
			self.movetype = Defines.MOVETYPE_TOSS;
			self.svflags |= Defines.SVF_DEADMONSTER;
			self.nextthink = 0;
			GameBase.gi.linkentity(self);

			return true;
		});

		private static readonly EntThinkAdapter supertankRocket = new("supertankRocket", self =>
		{
			float[] forward = { 0, 0, 0 }, right = { 0, 0, 0 };
			float[] start = { 0, 0, 0 };
			float[] dir = { 0, 0, 0 };
			float[] vec = { 0, 0, 0 };
			int flash_number;

			if (self.s.frame == M_Supertank.FRAME_attak2_8)
				flash_number = Defines.MZ2_SUPERTANK_ROCKET_1;
			else if (self.s.frame == M_Supertank.FRAME_attak2_11)
				flash_number = Defines.MZ2_SUPERTANK_ROCKET_2;
			else

				// (self.s.frame == FRAME_attak2_14)
				flash_number = Defines.MZ2_SUPERTANK_ROCKET_3;

			Math3D.AngleVectors(self.s.angles, forward, right, null);
			Math3D.G_ProjectSource(self.s.origin, M_Flash.monster_flash_offset[flash_number], forward, right, start);

			Math3D.VectorCopy(self.enemy.s.origin, vec);
			vec[2] += self.enemy.viewheight;
			Math3D.VectorSubtract(vec, start, dir);
			Math3D.VectorNormalize(dir);

			Monster.monster_fire_rocket(self, start, dir, 50, 500, flash_number);

			return true;
		});

		private static readonly EntThinkAdapter supertankMachineGun = new("supertankMachineGun", self =>
		{
			float[] dir = { 0, 0, 0 };
			float[] vec = { 0, 0, 0 };
			float[] start = { 0, 0, 0 };
			float[] forward = { 0, 0, 0 }, right = { 0, 0, 0 };
			int flash_number;

			flash_number = Defines.MZ2_SUPERTANK_MACHINEGUN_1 + (self.s.frame - M_Supertank.FRAME_attak1_1);

			//FIXME!!!
			dir[0] = 0;
			dir[1] = self.s.angles[1];
			dir[2] = 0;

			Math3D.AngleVectors(dir, forward, right, null);
			Math3D.G_ProjectSource(self.s.origin, M_Flash.monster_flash_offset[flash_number], forward, right, start);

			if (self.enemy != null)
			{
				Math3D.VectorCopy(self.enemy.s.origin, vec);
				Math3D.VectorMA(vec, 0, self.enemy.velocity, vec);
				vec[2] += self.enemy.viewheight;
				Math3D.VectorSubtract(vec, start, forward);
				Math3D.VectorNormalize(forward);
			}

			Monster.monster_fire_bullet(self, start, forward, 6, 4, Defines.DEFAULT_BULLET_HSPREAD, Defines.DEFAULT_BULLET_VSPREAD, flash_number);

			return true;
		});

		private static readonly EntThinkAdapter supertank_attack = new("supertank_attack", self =>
		{
			float[] vec = { 0, 0, 0 };
			float range;

			//float r;

			Math3D.VectorSubtract(self.enemy.s.origin, self.s.origin, vec);
			range = Math3D.VectorLength(vec);

			//r = random();

			// Attack 1 == Chaingun
			// Attack 2 == Rocket Launcher

			if (range <= 160)
				self.monsterinfo.currentmove = M_Supertank.supertank_move_attack1;
			else
			{
				// fire rockets more often at distance
				if (Lib.random() < 0.3)
					self.monsterinfo.currentmove = M_Supertank.supertank_move_attack1;
				else
					self.monsterinfo.currentmove = M_Supertank.supertank_move_attack2;
			}

			return true;
		});

		private static readonly mframe_t[] supertank_frames_turn_right =
		{
			new(GameAI.ai_move, 0, M_Supertank.TreadSound),
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

		private static mmove_t supertank_move_turn_right =
			new(M_Supertank.FRAME_right_1, M_Supertank.FRAME_right_18, M_Supertank.supertank_frames_turn_right, M_Supertank.supertank_run);

		private static readonly mframe_t[] supertank_frames_turn_left =
		{
			new(GameAI.ai_move, 0, M_Supertank.TreadSound),
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

		private static mmove_t supertank_move_turn_left =
			new(M_Supertank.FRAME_left_1, M_Supertank.FRAME_left_18, M_Supertank.supertank_frames_turn_left, M_Supertank.supertank_run);

		private static readonly mframe_t[] supertank_frames_pain3 =
		{
			new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null)
		};

		private static readonly mmove_t supertank_move_pain3 =
			new(M_Supertank.FRAME_pain3_9, M_Supertank.FRAME_pain3_12, M_Supertank.supertank_frames_pain3, M_Supertank.supertank_run);

		private static readonly mframe_t[] supertank_frames_pain2 =
		{
			new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null)
		};

		private static readonly mmove_t supertank_move_pain2 =
			new(M_Supertank.FRAME_pain2_5, M_Supertank.FRAME_pain2_8, M_Supertank.supertank_frames_pain2, M_Supertank.supertank_run);

		private static readonly mframe_t[] supertank_frames_pain1 =
		{
			new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null), new(GameAI.ai_move, 0, null)
		};

		private static readonly mmove_t supertank_move_pain1 =
			new(M_Supertank.FRAME_pain1_1, M_Supertank.FRAME_pain1_4, M_Supertank.supertank_frames_pain1, M_Supertank.supertank_run);

		private static readonly mframe_t[] supertank_frames_death1 =
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
			new(GameAI.ai_move, 0, M_Supertank.BossExplode)
		};

		private static readonly mmove_t supertank_move_death =
			new(M_Supertank.FRAME_death_1, M_Supertank.FRAME_death_24, M_Supertank.supertank_frames_death1, M_Supertank.supertank_dead);

		private static readonly mframe_t[] supertank_frames_backward =
		{
			new(GameAI.ai_walk, 0, M_Supertank.TreadSound),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null),
			new(GameAI.ai_walk, 0, null)
		};

		private static mmove_t supertank_move_backward =
			new(M_Supertank.FRAME_backwd_1, M_Supertank.FRAME_backwd_18, M_Supertank.supertank_frames_backward, null);

		private static readonly mframe_t[] supertank_frames_attack4 =
		{
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null)
		};

		private static mmove_t supertank_move_attack4 =
			new(M_Supertank.FRAME_attak4_1, M_Supertank.FRAME_attak4_6, M_Supertank.supertank_frames_attack4, M_Supertank.supertank_run);

		private static readonly mframe_t[] supertank_frames_attack3 =
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
			new(GameAI.ai_move, 0, null)
		};

		private static mmove_t supertank_move_attack3 =
			new(M_Supertank.FRAME_attak3_1, M_Supertank.FRAME_attak3_27, M_Supertank.supertank_frames_attack3, M_Supertank.supertank_run);

		private static readonly mframe_t[] supertank_frames_attack2 =
		{
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, null),
			new(GameAI.ai_charge, 0, M_Supertank.supertankRocket),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, M_Supertank.supertankRocket),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, null),
			new(GameAI.ai_move, 0, M_Supertank.supertankRocket),
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

		private static readonly mmove_t supertank_move_attack2 =
			new(M_Supertank.FRAME_attak2_1, M_Supertank.FRAME_attak2_27, M_Supertank.supertank_frames_attack2, M_Supertank.supertank_run);

		private static readonly EntThinkAdapter supertank_reattack1 = new("supertank_reattack1", self =>
		{
			if (GameUtil.visible(self, self.enemy))
			{
				if (Lib.random() < 0.9)
					self.monsterinfo.currentmove = M_Supertank.supertank_move_attack1;
				else
					self.monsterinfo.currentmove = M_Supertank.supertank_move_end_attack1;
			}
			else
				self.monsterinfo.currentmove = M_Supertank.supertank_move_end_attack1;

			return true;
		});

		private static readonly mframe_t[] supertank_frames_attack1 =
		{
			new(GameAI.ai_charge, 0, M_Supertank.supertankMachineGun),
			new(GameAI.ai_charge, 0, M_Supertank.supertankMachineGun),
			new(GameAI.ai_charge, 0, M_Supertank.supertankMachineGun),
			new(GameAI.ai_charge, 0, M_Supertank.supertankMachineGun),
			new(GameAI.ai_charge, 0, M_Supertank.supertankMachineGun),
			new(GameAI.ai_charge, 0, M_Supertank.supertankMachineGun)
		};

		private static readonly mmove_t supertank_move_attack1 =
			new(M_Supertank.FRAME_attak1_1, M_Supertank.FRAME_attak1_6, M_Supertank.supertank_frames_attack1, M_Supertank.supertank_reattack1);

		private static readonly mframe_t[] supertank_frames_end_attack1 =
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
			new(GameAI.ai_move, 0, null)
		};

		private static readonly mmove_t supertank_move_end_attack1 =
			new(M_Supertank.FRAME_attak1_7, M_Supertank.FRAME_attak1_20, M_Supertank.supertank_frames_end_attack1, M_Supertank.supertank_run);

		private static readonly EntPainAdapter supertank_pain = new("supertank_pain", (self, other, kick, damage) =>
		{
			if (self.health < self.max_health / 2)
				self.s.skinnum = 1;

			if (GameBase.level.time < self.pain_debounce_time)
				return;

			// Lessen the chance of him going into his pain frames
			if (damage <= 25)
			{
				if (Lib.random() < 0.2)
					return;
			}

			// Don't go into pain if he's firing his rockets
			if (GameBase.skill.value >= 2)
			{
				if (self.s.frame >= M_Supertank.FRAME_attak2_1 && self.s.frame <= M_Supertank.FRAME_attak2_14)
					return;
			}

			self.pain_debounce_time = GameBase.level.time + 3;

			if (GameBase.skill.value == 3)
				return; // no pain anims in nightmare

			if (damage <= 10)
			{
				GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Supertank.sound_pain1, 1, Defines.ATTN_NORM, 0);
				self.monsterinfo.currentmove = M_Supertank.supertank_move_pain1;
			}
			else if (damage <= 25)
			{
				GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Supertank.sound_pain3, 1, Defines.ATTN_NORM, 0);
				self.monsterinfo.currentmove = M_Supertank.supertank_move_pain2;
			}
			else
			{
				GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Supertank.sound_pain2, 1, Defines.ATTN_NORM, 0);
				self.monsterinfo.currentmove = M_Supertank.supertank_move_pain3;
			}
		});

		private static readonly EntDieAdapter supertank_die = new("supertank_die", (self, inflictor, attacker, damage, point) =>
		{
			GameBase.gi.sound(self, Defines.CHAN_VOICE, M_Supertank.sound_death, 1, Defines.ATTN_NORM, 0);
			self.deadflag = Defines.DEAD_DEAD;
			self.takedamage = Defines.DAMAGE_NO;
			self.count = 0;
			self.monsterinfo.currentmove = M_Supertank.supertank_move_death;
		});

		//
		// monster_supertank
		//

		/*
		 * QUAKED monster_supertank (1 .5 0) (-64 -64 0) (64 64 72) Ambush
		 * Trigger_Spawn Sight
		 */
		public static EntThinkAdapter SP_monster_supertank = new("SP_monster_supertank", self =>
		{
			if (GameBase.deathmatch.value != 0)
			{
				GameUtil.G_FreeEdict(self);

				return true;
			}

			M_Supertank.sound_pain1 = GameBase.gi.soundindex("bosstank/btkpain1.wav");
			M_Supertank.sound_pain2 = GameBase.gi.soundindex("bosstank/btkpain2.wav");
			M_Supertank.sound_pain3 = GameBase.gi.soundindex("bosstank/btkpain3.wav");
			M_Supertank.sound_death = GameBase.gi.soundindex("bosstank/btkdeth1.wav");
			M_Supertank.sound_search1 = GameBase.gi.soundindex("bosstank/btkunqv1.wav");
			M_Supertank.sound_search2 = GameBase.gi.soundindex("bosstank/btkunqv2.wav");

			//	self.s.sound = gi.soundindex ("bosstank/btkengn1.wav");
			M_Supertank.tread_sound = GameBase.gi.soundindex("bosstank/btkengn1.wav");

			self.movetype = Defines.MOVETYPE_STEP;
			self.solid = Defines.SOLID_BBOX;
			self.s.modelindex = GameBase.gi.modelindex("models/monsters/boss1/tris.md2");
			Math3D.VectorSet(self.mins, -64, -64, 0);
			Math3D.VectorSet(self.maxs, 64, 64, 112);

			self.health = 1500;
			self.gib_health = -500;
			self.mass = 800;

			self.pain = M_Supertank.supertank_pain;
			self.die = M_Supertank.supertank_die;
			self.monsterinfo.stand = M_Supertank.supertank_stand;
			self.monsterinfo.walk = M_Supertank.supertank_walk;
			self.monsterinfo.run = M_Supertank.supertank_run;
			self.monsterinfo.dodge = null;
			self.monsterinfo.attack = M_Supertank.supertank_attack;
			self.monsterinfo.search = M_Supertank.supertank_search;
			self.monsterinfo.melee = null;
			self.monsterinfo.sight = null;

			GameBase.gi.linkentity(self);

			self.monsterinfo.currentmove = M_Supertank.supertank_move_stand;
			self.monsterinfo.scale = M_Supertank.MODEL_SCALE;

			GameAI.walkmonster_start.think(self);

			return true;
		});

		/** Common Boss explode animation. */
		public static EntThinkAdapter BossExplode = new("BossExplode", self =>
		{
			float[] org = { 0, 0, 0 };

			int n;

			self.think = M_Supertank.BossExplode;
			Math3D.VectorCopy(self.s.origin, org);
			org[2] += 24 + (Lib.rand() & 15);

			switch (self.count++)
			{
				case 0:
					org[0] -= 24;
					org[1] -= 24;

					break;

				case 1:
					org[0] += 24;
					org[1] += 24;

					break;

				case 2:
					org[0] += 24;
					org[1] -= 24;

					break;

				case 3:
					org[0] -= 24;
					org[1] += 24;

					break;

				case 4:
					org[0] -= 48;
					org[1] -= 48;

					break;

				case 5:
					org[0] += 48;
					org[1] += 48;

					break;

				case 6:
					org[0] -= 48;
					org[1] += 48;

					break;

				case 7:
					org[0] += 48;
					org[1] -= 48;

					break;

				case 8:
					self.s.sound = 0;

					for (n = 0; n < 4; n++)
						GameMisc.ThrowGib(self, "models/objects/gibs/sm_meat/tris.md2", 500, Defines.GIB_ORGANIC);

					for (n = 0; n < 8; n++)
						GameMisc.ThrowGib(self, "models/objects/gibs/sm_metal/tris.md2", 500, Defines.GIB_METALLIC);

					GameMisc.ThrowGib(self, "models/objects/gibs/chest/tris.md2", 500, Defines.GIB_ORGANIC);
					GameMisc.ThrowHead(self, "models/objects/gibs/gear/tris.md2", 500, Defines.GIB_METALLIC);
					self.deadflag = Defines.DEAD_DEAD;

					return true;
			}

			GameBase.gi.WriteByte(Defines.svc_temp_entity);
			GameBase.gi.WriteByte(Defines.TE_EXPLOSION1);
			GameBase.gi.WritePosition(org);
			GameBase.gi.multicast(self.s.origin, Defines.MULTICAST_PVS);

			self.nextthink = GameBase.level.time + 0.1f;

			return true;
		});
	}
}

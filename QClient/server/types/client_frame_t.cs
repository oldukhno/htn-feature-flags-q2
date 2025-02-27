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
namespace QClient.server.types;

using game.types;

public class client_frame_t
{
	public int areabytes;
	public byte[] areabits = new byte[Defines.MAX_MAP_AREAS / 8]; // portalarea visibility bits
	public player_state_t ps = new();
	public int num_entities;
	public int first_entity; // into the circular sv_packet_entities[]
	public int senttime; // for ping calculations
}
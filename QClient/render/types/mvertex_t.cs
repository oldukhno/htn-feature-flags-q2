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
namespace QClient.render.types;

public class mvertex_t
{
	public static readonly int DISK_SIZE = 3 * Defines.SIZE_OF_FLOAT;
	public static readonly int MEM_SIZE = 3 * Defines.SIZE_OF_FLOAT;
	public float[] position = { 0, 0, 0 };

	public mvertex_t(BinaryReader b)
	{
		this.position[0] = b.ReadSingle();
		this.position[1] = b.ReadSingle();
		this.position[2] = b.ReadSingle();
	}
}
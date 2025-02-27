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
namespace QClient.game.types;

using util;

public class cplane_t
{
	public float[] normal = new float[3];
	public float dist;

	/** This is for fast side tests, 0=xplane, 1=yplane, 2=zplane and 3=arbitrary. */
	public byte type;

	/** This represents signx + (signy<<1) + (signz << 1). */
	public byte signbits; // signx + (signy<<1) + (signz<<1)

	public byte[] pad = { 0, 0 };

	public void set(cplane_t c)
	{
		Math3D.set(this.normal, c.normal);
		this.dist = c.dist;
		this.type = c.type;
		this.signbits = c.signbits;
		this.pad[0] = c.pad[0];
		this.pad[1] = c.pad[1];
	}

	public void clear()
	{
		Math3D.VectorClear(this.normal);
		this.dist = 0;
		this.type = 0;
		this.signbits = 0;
		this.pad[0] = 0;
		this.pad[1] = 0;
	}
}
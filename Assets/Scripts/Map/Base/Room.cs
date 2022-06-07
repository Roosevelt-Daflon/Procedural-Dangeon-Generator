using System;
using UnityEngine;

[Serializable]
public class Room
{
	public int TypeR = 0;
	public Vector2 Position;

	public Room(Vector2 position)
	{
		Position = position;
	}
}

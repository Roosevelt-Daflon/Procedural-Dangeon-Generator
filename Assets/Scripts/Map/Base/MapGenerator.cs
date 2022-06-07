using System;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{
	//Funções geradora do mapa
	public List<Room> GenMap(int roomAmount)
	{
		List<Room> map = new List<Room>();
		Vector2 index = new Vector2(0, 0);
		int ErrorPreviner = 0;
		Func<Vector2, List<Room>, Room> GetRoom = (index, map) =>
		{
			foreach (var item in map)
			{
				if (item.Position.Equals(index)) return item;
			}
			return null;
		};

		map.Add(new Room(new Vector2(0, 0)));

		while (roomAmount != map.Count)
		{
			if (ErrorPreviner > 15) break;
			int side = UnityEngine.Random.Range(1, 5);
			Room TRoomNow, TRoomNext;
			switch (side)
			{
				//Gera uma sala a esquerda do index atual
				case 1:
					TRoomNext = GetRoom(new Vector2(index.x - 1, index.y), map);
					if (TRoomNext == null)
					{
						TRoomNow = GetRoom(index, map);
						if (TRoomNow.TypeR + 1 > 15) break;
						map[map.IndexOf(TRoomNow)].TypeR += 1;
						index = new Vector2(index.x - 1, index.y);
						map.Add(new Room(index) { TypeR = 2 });
						ErrorPreviner = 0;
						index = map[UnityEngine.Random.Range(0, map.Count)].Position;
					}
					else
					{
						ErrorPreviner += 1;
						index = new Vector2(index.x - 1, index.y);
					}

					
					break;

				//Gera uma sala a direita do index atual
				case 2:

					TRoomNext = GetRoom(new Vector2(index.x + 1, index.y), map);
					if (TRoomNext == null)
					{
						TRoomNow = GetRoom(index, map);
						if (TRoomNow.TypeR + 2 > 15) break;
						map[map.IndexOf(TRoomNow)].TypeR += 2;
						index = new Vector2(index.x + 1, index.y);
						map.Add(new Room(index) { TypeR = 1 });
						ErrorPreviner = 0;
						index = map[UnityEngine.Random.Range(0, map.Count)].Position;
					}
					else
					{
						ErrorPreviner += 2;
						index = new Vector2(index.x + 1, index.y);
					}
					
					break;

				//Gera uma sala a cima do index atural
				case 3:
					TRoomNext = GetRoom(new Vector2(index.x, index.y + 1), map);
					if (TRoomNext == null)
					{
						TRoomNow = GetRoom(index, map);
						if (TRoomNow.TypeR + 4 > 15) break;
						map[map.IndexOf(TRoomNow)].TypeR += 4;
						index = new Vector2(index.x, index.y + 1);
						map.Add(new Room(index) { TypeR = 8 });
						ErrorPreviner = 0;
						index = map[UnityEngine.Random.Range(0, map.Count)].Position;
					}
					else
					{
						ErrorPreviner += 4;
						index = new Vector2(index.x, index.y + 1);
					}
					break;

				//Gera uma sala a abaixo do index atual
				case 4:
					TRoomNext = GetRoom(new Vector2(index.x, index.y - 1), map);
					if (TRoomNext == null)
					{
						TRoomNow = GetRoom(index, map);
						if (TRoomNow.TypeR + 8 > 15) break;
						map[map.IndexOf(TRoomNow)].TypeR += 8;
						index = new Vector2(index.x, index.y - 1);
						map.Add(new Room(index) { TypeR = 4 });
						ErrorPreviner = 0;
						index = map[UnityEngine.Random.Range(0, map.Count)].Position;
					}
					else
					{
						ErrorPreviner += 8;
						index = new Vector2(index.x, index.y - 1);
					}
					break;
			}
		}


		return map;


	}


}

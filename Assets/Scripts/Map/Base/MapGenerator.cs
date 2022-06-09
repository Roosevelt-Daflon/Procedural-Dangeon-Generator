using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{
	//Função geradora do mapa.
	public List<Room> GenMap(int roomMaxAmount)
	{
		
		List<Room> map = new List<Room>();
		Vector2 index = new Vector2(0, 0);
		int errorPreviner = 0;

		map.Add(new Room(new Vector2(0, 0)));

		while (roomMaxAmount > map.Count && errorPreviner <= 100)
		{
			int indexSide = Random.Range(0, 4);
			//cria sala no mapa
			CreteRoom(indexSide, ref index, in map,ref errorPreviner);
		}

		return map;
	}
	
	//criar sala
	void CreteRoom(int indexSide, ref Vector2 index, in List<Room> map, ref int errorPreviner)
	{
		int[] BaseTypesList = new int[4] { 1, 2, 8, 4 };
		int[] BaseTypesReverseList = new int[4] { 2, 1, 4, 8 };
		Vector2[] sideIndexList = new Vector2[4] { new Vector2(-1, 0), new Vector2(1, 0), new Vector2(0, -1), new Vector2(0, 1) };

		Room TRoomNext = GetRoom(index+ sideIndexList[indexSide], map);
		Room TRoomNow = GetRoom(index, map);

		//verifica o lado do index já possui uma sala
		if (TRoomNext == null && TRoomNow.TypeR + BaseTypesList[indexSide] <= 15)
		{
			map[map.IndexOf(TRoomNow)].TypeR += BaseTypesList[indexSide];
			index = index + sideIndexList[indexSide];
			map.Add(new Room(index) { TypeR = BaseTypesReverseList[indexSide]});
			index = map[Random.Range(0, map.Count)].Position;
			errorPreviner = 0;
		}
		else
		{
			errorPreviner += BaseTypesList[indexSide];
		}
	}

	//Função para pegar uma sala a partir de sua posição no mapa.
	Room GetRoom(Vector2 index, List<Room> map)
	{
		foreach (var item in map)
		{
			if (item.Position.Equals(index)) return item;
		}
		return null;
	}



}

using UnityEngine;

[CreateAssetMenu(fileName = "RoomsData", menuName = "Data/RoomsScriptableObject", order = 1)]
public class RoomsDataAsset : ScriptableObject
{
	public GameObject[] Rooms;
}

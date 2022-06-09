using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
	[SerializeField] int roomMaxAmount = 10;
	[SerializeField] RoomsDataAsset roomsData;
	[SerializeField] Transform Parent;
	[SerializeField] float Delay = 0.5f;
	[SerializeField] GameObject Text;
	[SerializeField] TMP_InputField InputField;
	[SerializeField] Slider slider;
	MapGenerator Generator = new MapGenerator();

	private void Start()
	{
		RenderMap();
	}


	public void RenderMap()
	{
		DelMap();
		StartCoroutine(Create());
	}

	public void SetMaxRooms() 
	{
		roomMaxAmount = int.Parse(InputField.text);
	}

	void DelMap()
	{
		foreach (Transform item in Parent)
		{
			Destroy(item.gameObject);
		}
	}

	IEnumerator Create() 
	{
		foreach (var item in Generator.GenMap(roomMaxAmount))
		{
			yield return new WaitForSeconds(slider.value);
			GameObject room = Instantiate(roomsData.Rooms[item.TypeR - 1], new Vector2(item.Position.x * 21, item.Position.y * 12), Quaternion.identity, Parent);
			GameObject text = Instantiate(Text, room.transform.position, Quaternion.identity, room.transform);
			text.GetComponent<TextMeshPro>().text = item.TypeR.ToString();
			text.transform.localPosition = new Vector3(0, 0, -5);


		}
	}

}

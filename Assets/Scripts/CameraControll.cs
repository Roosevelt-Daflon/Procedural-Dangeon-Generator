using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
	Rigidbody rigidbody;
	[SerializeField] float Speed = 10;
	[SerializeField] float ScrollSpeed = 10;
	float Scrool = 10;
	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
    {
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Scrool += Input.mouseScrollDelta.y * ScrollSpeed;

		Debug.Log(Input.mouseScrollDelta);

		rigidbody.velocity = new Vector3(input.x, input.y) * Speed;
		Camera.main.orthographicSize = Mathf.Abs(Scrool);

    }
}

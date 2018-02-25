using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public Camera MainCamera;
	public float Speed;
	public Rigidbody RBD;
	public float JumpHeight = 400;

	// Use this for initialization
	void Start () 
	{
		RBD = GetComponent<Rigidbody> ();
		MainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
		RegisterInput ();
		MainCamera.transform.position = new Vector3 (transform.position.x, transform.position.y + 8, transform.position.z - 14);

		MainCamera.transform.rotation = Quaternion.AngleAxis (24, transform.right);
	}

	private void RegisterInput ()
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (0, 0, Speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (0, 0, Speed * -Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Speed * -Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space) && RBD.velocity.y == 0f && transform.position.y == 1.25) {
			RBD.AddForce (0, JumpHeight, 0);
		}
	}
}

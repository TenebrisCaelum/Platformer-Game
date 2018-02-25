using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	public float xPosition;
	public Platform[] PlatformPrefabs;
	public Platform[] Platforms;
	public float SpawnIncrement = 13.25f;
	public float SpawnTime;
	private float SpawnPosition;
	private float Timer = 0f;

	// Use this for initialization
	void Start () {
		int idx = Random.Range (0, PlatformPrefabs.Length-1);
		SpawnPosition = SpawnIncrement;
		Platform p1 = Instantiate (PlatformPrefabs[idx], new Vector3 (xPosition, PlatformPrefabs[idx].transform.position.y, 0), new Quaternion());
		idx = Random.Range (0, PlatformPrefabs.Length);
		Platform p2 = Instantiate (PlatformPrefabs[idx], new Vector3 (xPosition, PlatformPrefabs[idx].transform.position.y, SpawnPosition), new Quaternion());
		Platforms = new Platform[] {
			p1,
			p2
		};
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Timer += Time.deltaTime;
		if (Timer >= SpawnTime) {
			Timer -= SpawnTime;
			AddNewPlatform ();
		}
	}

	private void AddNewPlatform()
	{
		SpawnPosition += SpawnIncrement;
		Destroy (Platforms [0].gameObject);
		Platforms [0] = Platforms [1];
		int idx = Random.Range (0, PlatformPrefabs.Length);
		Platforms[1] = Instantiate (PlatformPrefabs[idx], new Vector3 (xPosition, PlatformPrefabs[idx].transform.position.y, SpawnPosition), new Quaternion());
	}
}

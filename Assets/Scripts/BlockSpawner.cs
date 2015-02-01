using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

	public int spawnTime = 0;
	public GameObject[] blocks;

	void Start () {
		SpawnBlocks ();
		InvokeRepeating("CheckBlocks", 0, 1);
	}

	void CheckBlocks () {
		Vector3 playerPos = GameObject.Find ("Player").transform.position;
		if(playerPos.x > 80 * spawnTime) {
			SpawnBlocks ();
		}
	}

	void SpawnBlocks () {
		int from = spawnTime * 10 + 1;
		int end = from + 10;
		for(int i=from;i<end;i++) {
			GameObject obj = (GameObject)Instantiate (
				blocks[Random.Range (0, blocks.Length)], 
				new Vector3(10*i, 0, 0), 
				Quaternion.identity
			);
			obj.transform.parent = transform;
		}
		spawnTime ++;
	}
}

using UnityEngine;
using System.Collections;


public class PlainSpawner : MonoBehaviour {

	public Transform plane;
	private int planeScale = 3;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 10; i ++) {
			for (int j = 0; j < 10; j ++) {
				Transform p = Instantiate (plane) as Transform;
				p.transform.position = new Vector3 (i*planeScale*10-150, 0.5f, j*planeScale*10-150);
				p.transform.parent = gameObject.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

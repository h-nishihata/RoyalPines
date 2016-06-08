using UnityEngine;
using System.Collections;


public class PlainSpawner : MonoBehaviour {

	public Transform plane;
	private int planeScale = 1;

	// Use this for initialization
	void Start () {

		int numPlanes = 4;
		float offset = (planeScale*10*(numPlanes-1))/2;

		for (int i = 0; i < numPlanes; i ++) {
			for (int j = 0; j < numPlanes; j ++) {
				Transform p = Instantiate (plane) as Transform;
				p.transform.position = new Vector3 (i*planeScale*10-offset, 0.1f, j*planeScale*10-offset);
				p.transform.parent = gameObject.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

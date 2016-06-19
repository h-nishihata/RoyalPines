using UnityEngine;
using System.Collections;

public class AsteroidField : MonoBehaviour {

	float pos = 3.0f;

	void Update () {

		transform.Translate(new Vector3(pos,0,0) * Time.deltaTime);

		if (transform.position.z < -50.0f) {
			transform.position = new Vector3(0,0,50);
		}

	}

}

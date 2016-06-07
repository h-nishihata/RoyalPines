using UnityEngine;
using System.Collections;

public class FlowingClouds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RenderSettings.fog = false;
	}

	void Update() {
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * -3.0f);
	}

}
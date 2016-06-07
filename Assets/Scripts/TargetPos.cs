using UnityEngine;
using System.Collections;

public class TargetPos : MonoBehaviour
{

	public float interval = 1f;
	public float minDistance = 1f;
	public float maxDistance = 10f;


	// Use this for initialization
	void Start ()
	{

		InvokeRepeating ("UpdatePosition", 0, interval);
	
	}


	void UpdatePosition ()
	{
		Vector3 pos = Vector3.right * Random.value + Vector3.up * Random.Range (0.4f, 1);
		pos.z = Random.Range (minDistance, maxDistance);
		transform.position = pos;
	}

}
using UnityEngine;
using System.Collections;

public class AnimalMovement : MonoBehaviour
{
	float objScale;
	int rotAng;
	
	Animation anm;
	AnimationState fly;
	
	public Transform target;
	public float speed = 1.0f;
	public float maxDeltaRotate = 100f;
	
	
	void Start ()
	{
		objScale = Random.Range (2f, 5f);
		rotAng = Random.Range (0, 360);
		transform.rotation = Quaternion.Euler (rotAng, 0, rotAng);
		
		anm = GetComponentInChildren<Animation> ();

		if (gameObject.name == "Sparrow(Clone)") {
			fly = anm ["fly"];		
			fly.speed = 1.2f;
		}
		
		target = Instantiate<Transform> (target);
//		target.transform.parent = gameObject.transform;
		var targetPos = target.GetComponent<TargetPos> ();

		if ((gameObject.name == "Sparrow(Clone)") || (gameObject.name == "Nemo(Clone)")) {
			targetPos.interval = 5.0f;
//			targetPos.minDistance = 10.0f;
//			targetPos.maxDistance = 10.0f;
		} else {
			targetPos.interval = 30.0f;
//			targetPos.minDistance = 1.0f;
//			targetPos.maxDistance = 10.0f;
		}

	}
	
	
	void Update ()
	{
		
		Vector3 to = target.transform.position - transform.position;
		Quaternion toRot = Quaternion.LookRotation (to, Vector3.up);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, toRot, maxDeltaRotate * Time.deltaTime);
		transform.position += transform.forward * speed * Time.deltaTime;

	}
	
}
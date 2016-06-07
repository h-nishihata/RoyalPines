using UnityEngine;
using System.Collections;

public class Rabbit : MonoBehaviour {

	float walkSpeed = 0.5f;		//　進む速さ
	public float interval = 3.0f;
	int nextPoint;
	Vector3 target;
	public Transform[] places;
	private GameObject flow_tgt;
	float flow_speed = 0.01f;



	// Use this for initialization
	void Start () {

		InvokeRepeating ("UpdatePosition", 0, interval);
		flow_tgt = new GameObject();
		flow_tgt.transform.position = target;

	}
		

	// Update is called once per frame
	void Update () {

		if(flow_tgt){
			flow_tgt.transform.position = Vector3.Lerp(flow_tgt.transform.position, target, flow_speed);
		}

		transform.LookAt(flow_tgt.transform);
		transform.position = Vector3.MoveTowards(transform.position, target, walkSpeed * Time.deltaTime);

	}

	void UpdatePosition(){
		target = places [nextPoint].transform.position;
//		Debug.Log (nextPoint);
		if(nextPoint < 4){
			nextPoint++;
		}else{
			nextPoint = 0;
		}
	}

}

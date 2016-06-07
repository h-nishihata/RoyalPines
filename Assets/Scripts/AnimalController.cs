using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {

	public Sparrow[] sp;

	// Use this for initialization
	void Start () {
		Sparrow[] s = new Sparrow[sp.Length];
		for (int i = 0; i < sp.Length; i++) {
			sp [i] = (Sparrow)Instantiate (sp [i], transform.position + Random.onUnitSphere * 3f, sp[i].transform.rotation);
			sp [i].transform.parent = transform;
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {

	public AnimalMovement[] Creatures;

	// Use this for initialization
	void Start () {
		AnimalMovement[] animMove = new AnimalMovement[Creatures.Length];
		for (int i = 0; i < Creatures.Length; i++) {
			Creatures [i] = (AnimalMovement)Instantiate (Creatures [i], transform.position + new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)), Creatures[i].transform.rotation);
			Creatures [i].transform.parent = transform;
		}	
	}

}

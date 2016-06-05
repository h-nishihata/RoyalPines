using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	[SerializeField] Transform[] scenes;

	// Use this for initialization
	void Start () {
		scenes[0].gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			SwitchScene (1);
		}else if (Input.GetKeyDown ("2")) {
			SwitchScene (2);
		}else if (Input.GetKeyDown ("3")) {
			SwitchScene (3);
		}else if (Input.GetKeyDown ("4")) {
			SwitchScene (4);
		}else if (Input.GetKeyDown ("5")) {
			SwitchScene (5);
		}
	}

	void SwitchScene(int num){

		int _num = num - 1;

		scenes[_num].gameObject.SetActive (true);

		for (int i = 0; i < scenes.Length; i++) {
			if (i != _num) {
				scenes[i].gameObject.SetActive (false);
			}
		}

	}

}

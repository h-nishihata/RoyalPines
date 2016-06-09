using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	[SerializeField] Transform[] scenes;
	public int currentScene;
	[SerializeField] Reaktion.ConstantMotion camRoot;
	Reaktion.JitterMotion jitter;
	Camera cam;


	// Use this for initialization
	void Start () {
		scenes[0].gameObject.SetActive (true);
		cam = Camera.main;
		jitter = cam.GetComponent<Reaktion.JitterMotion> ();
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


		//	cam motion
		if (currentScene == 0) {
			if (!camRoot.rotateMode) {
				camRoot.position.mode = Reaktion.ConstantMotion.TransformMode.ZAxis;
				camRoot.rotation.randomness = 1;

				jitter.positionFrequency = jitter.rotationFrequency = 0.1f;
				jitter.positionAmount = 2.0f;
				jitter.rotationAmount = 5.0f;
				jitter.positionComponents = new Vector3 (1, 0.1f, 1);
				jitter.rotationComponents = new Vector3 (1, 1, 0);
				jitter.positionOctave = jitter.rotationOctave = 1;
			}

		} else if (currentScene == 1) {
			
			camRoot.position.mode = Reaktion.ConstantMotion.TransformMode.Off;
			camRoot.rotation.mode = Reaktion.ConstantMotion.TransformMode.YAxis;
			camRoot.rotation.velocity = 30.0f;
			camRoot.rotation.randomness = 0;

			jitter.positionFrequency = jitter.rotationFrequency = 0.2f;
			jitter.positionAmount = 5.0f;
			jitter.rotationAmount = 8.0f;
			jitter.positionComponents = jitter.rotationComponents = new Vector3 (1,1,1);
			jitter.positionOctave = jitter.rotationOctave = 3;
		
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

		currentScene = _num;

		camRoot.transform.position = new Vector3 (0,1,-5);
		camRoot.transform.rotation = Quaternion.Euler (0,0,0);

	}

}

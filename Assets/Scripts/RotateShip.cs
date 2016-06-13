using UnityEngine;
using System.Collections;

public class RotateShip : MonoBehaviour {

	float targetAng;
	float currentAng;
	float step;
	float waiting;
	bool rollDir;

	// Use this for initialization
	void Start () {
//		InvokeRepeating ("roll", 0, interval);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.rotation = Quaternion.Euler (0,0,currentAng);

		if(rollDir == true){
			if (currentAng < targetAng) {
				currentAng++;
			} else {
				waitForWhile (false);
//				if(step < waiting){
//					step++;
//				}else{
//					step = 0;
//					waiting = Random.Range (0.5f,3.0f);
//					targetAng = Random.Range (0,100);
//					rollDir = false;
//				}
			}
		}else if(rollDir == false){
			if (currentAng > targetAng*-1) {
				currentAng--;
			} else {
				waitForWhile (true);
//				if(step < waiting){
//					step++;
//				}else{
//					step = 0;
//					targetAng = Random.Range (0,100);
//					rollDir = true;
//				}
			}
		}

	}


	void waitForWhile(bool dir){		
		if(step < waiting){
			step += Time.deltaTime;
		}else{
			step = 0;
			waiting = Random.Range (0.5f,3.0f);
			targetAng = Random.Range (0,100);
			rollDir = dir;
		}
	}

}

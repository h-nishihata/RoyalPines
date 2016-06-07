//
// Reaktion - An audio reactive animation toolkit for Unity.
//
// Copyright (C) 2013, 2014 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using UnityEngine;

namespace Reaktion {

public class ConstantMotion : MonoBehaviour
{
    public enum TransformMode {
        Off, XAxis, YAxis, ZAxis, Arbitrary, Random
    };

    // A class for handling each transformation.
    [System.Serializable]
    public class TransformElement
    {
        public TransformMode mode = TransformMode.Off;
        public float velocity = 1;

        // Used only in the arbitrary mode.
        public Vector3 arbitraryVector = Vector3.up;

        // Affects velocity.
        public float randomness = 0;

        // Randomizer states.
        Vector3 randomVector;
        float randomScalar;

        public void Initialize()
        {
            randomVector = Random.onUnitSphere;
            randomScalar = Random.value;
        }

        // Get a vector corresponds to the current transform mode.
        public Vector3 Vector {
            get {
                switch (mode)
                {
                    case TransformMode.XAxis:     return Vector3.right;
                    case TransformMode.YAxis:     return Vector3.up;
                    case TransformMode.ZAxis:     return Vector3.forward;
                    case TransformMode.Arbitrary: return arbitraryVector;
                    case TransformMode.Random:    return randomVector;
                }
                return Vector3.zero;
            }
        }

        // Get the current delta value.
        public float Delta {
            get {
                var scale = (1.0f - randomness * randomScalar);
                return velocity * scale * Time.deltaTime;
            }
        }
    }

    public TransformElement position = new TransformElement();
    public TransformElement rotation = new TransformElement{ velocity = 30 };
    public bool useLocalCoordinate = true;

    void Awake()
    {
        position.Initialize();
        rotation.Initialize();
    }

    void Update()
    {
        if (position.mode != TransformMode.Off)
        {
            if (useLocalCoordinate)
                transform.localPosition += position.Vector * position.Delta;
            else
                transform.position += position.Vector * position.Delta;
        }

        if (rotation.mode != TransformMode.Off)
        {
            var delta = Quaternion.AngleAxis(rotation.Delta, rotation.Vector);
            if (useLocalCoordinate)
                transform.localRotation = delta * transform.localRotation;
            else
                transform.rotation = delta * transform.rotation;
        }

		
		//	if(currentScene == 0){

			if (transform.position.z >= 80.0f) {
//				Rotate (-1);
				if (transform.localEulerAngles.y >= 180.0f) {
					rotation.mode = TransformMode.Off;
					transform.rotation = Quaternion.Euler (0, 180, 0);

					position.velocity = -1.0f;
				} else {
					rotation.mode = TransformMode.YAxis;
					rotation.velocity = 20.0f;
					rotation.randomness = 0.0f;
				}
			} else if (transform.position.z <= 60.0f) {
//				Rotate (1);
				if ((transform.localEulerAngles.y > 359.0f)) {
					rotation.mode = TransformMode.Off;
					transform.rotation = Quaternion.Euler (0, 0, 0);

					position.velocity = 1.0f;
				} else {
					rotation.mode = TransformMode.YAxis;
					rotation.velocity = -20.0f;
					rotation.randomness = 0.0f;
				}
			}


    }

	//　あとでリファクタリング
	void Rotate(int dir){
			
			int yRot;
			if (dir < 0) { yRot = 180; } else {	yRot = 0; }

//			Debug.Log ("dir : " + dir + "yRot : " + yRot);

			if (transform.localEulerAngles.y > 359.0f - yRot) {
				
				rotation.mode = TransformMode.YAxis;
				rotation.velocity = 20.0f * dir;
				rotation.randomness = 0.0f;

			} else {
				
				rotation.mode = TransformMode.Off;
				transform.rotation = Quaternion.Euler (0, yRot, 0);
				position.velocity = 1.0f * dir;

			}

	}


}


} // namespace Reaktion

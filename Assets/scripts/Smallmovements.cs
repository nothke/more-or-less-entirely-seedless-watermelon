using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smallmovements : MonoBehaviour {
    Vector3 origin;
    // Use this for initialization
    public float distance = 0.1f;
	void Start () {
        origin = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = (Vector3)Random.insideUnitCircle * distance+ origin;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMelons : MonoBehaviour {

	void Start () {
		
	}

    public GameObject melonPrefab;



	void Update () {
        if (Random.value < 0.5f)
            Instantiate(melonPrefab, transform.position + Random.insideUnitSphere * 10, Quaternion.identity);
    }
}

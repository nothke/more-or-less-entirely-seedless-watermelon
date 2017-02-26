using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Eater : MonoBehaviour {

    public Bite prefab;

	void Start () {
		
	}
	
	void Update () {

        Touch[] touches = Input.touches;
        touches = touches.Where((e) => { return e.phase == TouchPhase.Began; }).ToArray();
        for (int i = 0; i < touches.Length; i++)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touches[i].position);
            Instantiate(prefab, (Vector3)touchPosition,Quaternion.identity);
        }
    }
}

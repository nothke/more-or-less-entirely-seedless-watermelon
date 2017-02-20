using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class Walls : MonoBehaviour {
    public Transform wallPrefab;
    Camera c;
	
	// Update is called once per frame
	void Awake () {

        c = GetComponent<Camera>();
        Transform w = Instantiate<Transform>(wallPrefab);
        w.SetParent(transform);
        w.localPosition = new Vector3(0, c.orthographicSize+0.5f);
        w.localScale = new Vector3(c.orthographicSize * c.aspect*2, 1,1);
        w = Instantiate<Transform>(wallPrefab);
        w.SetParent(transform);
        w.localPosition = new Vector3(0, -c.orthographicSize - 0.5f);
        w.localScale = new Vector3(c.orthographicSize * c.aspect * 2, 1, 1);
        w = Instantiate<Transform>(wallPrefab);
        w.SetParent(transform);
        w.localPosition = new Vector3(-c.orthographicSize*c.aspect - 0.5f,0);
        w.localScale = new Vector3( 1, c.orthographicSize * 2,1);
        w = Instantiate<Transform>(wallPrefab);
        w.SetParent(transform);
        w.localPosition = new Vector3(c.orthographicSize * c.aspect + 0.5f,0);
        w.localScale = new Vector3(1, c.orthographicSize * 2, 1);
    }
}

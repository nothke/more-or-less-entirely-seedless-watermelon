using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour {
    public static bool gameover;
    public List<Transform> points;
    public GameObject gameoverScreenPrefab;
	void Start () {
        gameover = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (gameover) return;
        List<Transform> toRemove = new List<Transform>();
        for (int i = 0; i < points.Count; i++)
        {
            if (!ExtraDrag.IsNotInBite(points[i].position))
            {
                toRemove.Add(points[i]);
            }
        }
        for (int i = 0; i < toRemove.Count; i++)
        {
            points.Remove(toRemove[i]);
            Destroy(toRemove[i].gameObject);
        }
        if (points.Count == 0)
        {
            Win();
        }
	}
    void Win()
    {
        gameover = true;
        Instantiate(gameoverScreenPrefab);
    }
}

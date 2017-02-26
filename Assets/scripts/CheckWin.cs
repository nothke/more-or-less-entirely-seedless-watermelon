using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckWin : MonoBehaviour {
    public static bool gameover;
    public List<Transform> points;
    public GameObject gameoverScreenPrefab;
    public Transform againButton;

	void Start () {
        gameover = false;
        againButton.localScale = Vector3.zero;
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
        againButton.DOScale(Vector3.one, 0.2f);

    }
}

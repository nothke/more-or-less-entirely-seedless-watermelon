using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bite : MonoBehaviour {
    public static List<Bite> bites;
    public float closenessRadius;
    public AudioClip sound;
    private void Awake()
    {
        bool valid = false;
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, closenessRadius);
        for (int i = 0; i < cols.Length; i++)
        {
            if (valid) break;
            valid |= cols[i].GetComponent<Bite>();
        }
        cols = Physics2D.OverlapPointAll(transform.position);
        for (int i = 0; i < cols.Length; i++)
        {
            if (!valid) break;
            valid &= cols[i].GetComponent<Bite>();
        }
        valid &= cols.Any((e) => { return e.GetComponent<ExtraDrag>() ; });

        if (valid)
        {
            bites.Add(this);
            if (sound) {
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            }
        }else
        {
            Destroy(gameObject);
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

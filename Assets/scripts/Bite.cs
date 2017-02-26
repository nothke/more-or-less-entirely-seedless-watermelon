﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bite : MonoBehaviour {
    public static List<Bite> bites;
    public float closenessRadius;
    public AudioClip sound;
    public bool ignoreCheck;
    private void Awake()
    {
        if (ignoreCheck) return;
        bool valid = false;
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, closenessRadius);
        for (int i = 0; i < cols.Length; i++)//check if there is a bitnearby (surface)
        {
            if (valid) break;
            valid |= cols[i].GetComponent<Bite>() && cols[i].GetComponent<Bite>() != this;
        }
        Debug.Log("1:" + valid);
        cols = Physics2D.OverlapPointAll(transform.position);
        for (int i = 0; i < cols.Length; i++)//check if your press melon
        {
            if (!valid) break;
            valid &= !(cols[i].GetComponent<Bite>() && cols[i].GetComponent<Bite>() != this); 
        }

        Debug.Log("2:" + valid);
        valid &= cols.Any((e) => { return e.GetComponent<ExtraDrag>() ; });

        Debug.Log("3:" + valid);
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

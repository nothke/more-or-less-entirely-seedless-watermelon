using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Bite : MonoBehaviour
{
    public static List<Bite> bites;
    public float closenessRadius;
    public float seedlessRadius;
    public AudioClip[] biteSounds;
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
        //Debug.Log("1:" + valid);
        cols = Physics2D.OverlapPointAll(transform.position);
        for (int i = 0; i < cols.Length; i++)//check if you don't press a bit
        {
            if (!valid) break;
            valid &= !(cols[i].GetComponent<Bite>() && cols[i].GetComponent<Bite>() != this);
        }

        //Debug.Log("2:" + valid);
        valid &= cols.Any((e) => { return e.GetComponent<ExtraDrag>(); });//check if you don't press the melon

        //Debug.Log("3:" + valid);
        cols = Physics2D.OverlapCircleAll(transform.position, seedlessRadius);
        for (int i = 0; i < cols.Length; i++)//check if you don't press a bit
        {
            if (!valid) break;
            valid &= !(cols[i].GetComponent<Seed>());
        }
        //Debug.Log("4:" + valid);

        if (valid)
        {
            biteSounds.Play(Vector3.zero, minDistance: 10, volume: 1);
            Camera.main.DOShakePosition(0.5f, 0.3f, 7);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

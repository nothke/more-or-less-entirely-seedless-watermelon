using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {

    public Collider2D col;
    public Rigidbody2D rb;
    public bool inFlesh = true;
    public void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.drag = 0.5f;
        rb.angularDrag = 10;
    }
}

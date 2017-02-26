using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDrag : MonoBehaviour
{
    public float dragProcent = 1;

    public void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().AddForce(dragProcent * -collision.GetComponent<Rigidbody2D>().velocity* Time.deltaTime);
    }
}

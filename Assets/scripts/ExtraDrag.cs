using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDrag : MonoBehaviour
{
    public float dragProcent = 1;
    public ParticleSystem melonParticles;

    public void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        rb.AddForce(dragProcent * -collision.GetComponent<Rigidbody2D>().velocity * Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time < 1) return;


        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (!rb) return;

        melonParticles.transform.position = (Vector3) rb.position - (2 * Vector3.forward);
        melonParticles.transform.rotation = Quaternion.LookRotation(-rb.velocity);

        melonParticles.Emit(10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExtraDrag : MonoBehaviour
{
    public float dragProcent = 1;
    public ParticleSystem melonParticles;

    public AudioClip[] splashClips;
    public static bool IsNotInBite(Vector2 pos)
    {
        return !Physics2D.OverlapPointAll(pos).Any(e => { return e.GetComponent<Bite>(); });
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (!rb) return;

        Seed s = collision.GetComponent<Seed>();

        if (!IsNotInBite(collision.transform.position)) {
            if (s)
            {
                s.inFlesh = false;
            }
            return;
        }
        if (s && !s.inFlesh) makeParticles(rb);
        s.inFlesh = true;
        rb.AddForce(dragProcent * -rb.velocity * Time.deltaTime);

    }
    
    public void makeParticles(Rigidbody2D rb) { 
        melonParticles.transform.position = (Vector3) rb.position - (2 * Vector3.forward);
        melonParticles.transform.rotation = Quaternion.LookRotation(-rb.velocity);

        splashClips.Play(rb.position, minDistance: 10, volume: rb.velocity.magnitude * 0.1f);

        melonParticles.Emit(10);
    }
}

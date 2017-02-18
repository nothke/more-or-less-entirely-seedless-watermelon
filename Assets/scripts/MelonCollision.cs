using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonCollision : MonoBehaviour {

    public ParticleSystem ps;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
            ps.Emit(10);
    }
}

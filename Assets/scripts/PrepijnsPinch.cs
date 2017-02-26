using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepijnsPinch : MonoBehaviour {

    Seed[] seeds;
    public float force = 5000;
    //public float maxFingerRadius = 1;
    public float maxPinchRadius = 3;
    void Awake()
    {
        // Get all seeds in scene
        seeds = FindObjectsOfType<Seed>();
        Debug.Log("Found " + seeds.Length + " seeds");
    }

    void FixedUpdate()
    {
        int divider = Screen.currentResolution.width / 2;

        bool isDown = Input.touchCount > 0;

        Vector2[] touchPositions = null;

#if UNITY_EDITOR
        isDown |= Input.GetMouseButton(0);
#endif

        // if on android device
        if (isDown)
        {
            int count = Input.touchCount;

#if UNITY_EDITOR
            /*
            if (Input.GetMouseButton(0))
                count++;*/
#endif

            touchPositions = new Vector2[count];

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];

                // convert pixel position to world
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                touchPositions[i] = touchPosition;
            }

#if UNITY_EDITOR
            /*
            if (Input.GetMouseButton(0))
                touchPositions[Input.touchCount] = Camera.main.ScreenToWorldPoint(Input.mousePosition);*/
#endif
        }

        // if in Unity just override the position array to mouse, no pinching for now


        if (isDown && touchPositions != null)
        {


            for (int i =0; i< touchPositions.Length;i++)
            {
                for (int j = 0; j < touchPositions.Length; j++)
                {
                    if (i == j) continue;

                    float fingerDistance;
                    if ((fingerDistance = Vector2.Distance(touchPositions[i], touchPositions[j])) < maxPinchRadius)
                    {
                        //Debug.DrawLine(touchPositions[i], touchPositions[j]);
                        Vector2 middle = (touchPositions[i] + touchPositions[j]) / 2;
                        foreach (var seed in seeds)
                        {
                            // just add force to every seed for every touch for now
                            if (Vector2.Distance(seed.transform.position, middle) < fingerDistance / 2)
                            {

                                Vector2 direction =- Vector3.Cross(touchPositions[i] - touchPositions[j], ((Vector2)seed.transform.position) - touchPositions[j]).z * Vector3.Cross(touchPositions[i] - touchPositions[j], Vector3.forward);
                                //Debug.DrawLine(middle,middle+direction.normalized);
                                seed.rb.AddForce( direction.normalized * (1-fingerDistance/maxPinchRadius)  * force);
                            }
                        }
                    }
                }
            }
        }
    }
}

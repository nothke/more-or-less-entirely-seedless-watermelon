using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch : MonoBehaviour
{
    Seed[] seeds;
    public float force = 100;
    public float fingerRadius = 1;
    void Awake()
    {
        // Get all seeds in scene
        seeds = FindObjectsOfType<Seed>();
        Debug.Log("Found " + seeds.Length + " seeds");
    }

    void Update()
    {
        int divider = Screen.currentResolution.width / 2;

        bool isDown = Input.touchCount > 0;

        Vector2[] touchPositions = null;

#if UNITY_EDITOR
        //isDown |= Input.GetMouseButton(0);
#endif

        // if on android device
        if (isDown)
        {
            int count = Input.touchCount;

#if UNITY_EDITOR
            //if(Input.GetMouseButton(0))
                //count++;      
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

            //if (Input.GetMouseButton(0))
                //touchPositions[Input.touchCount] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#endif
        }

        // if in Unity just override the position array to mouse, no pinching for now


        if (isDown && touchPositions != null)
        {
            foreach (var touchPosition in touchPositions)
            {
                Debug.DrawLine(touchPosition -Vector2.up/2, touchPosition + Vector2.up /2, Color.green);
                Debug.DrawLine(touchPosition - Vector2.left / 2, touchPosition + Vector2.left / 2, Color.green);

                foreach (var seed in seeds)
                {
                    // just add force to every seed for every touch for now
                    if (Vector2.Distance(seed.transform.position, touchPosition) < fingerRadius)
                        seed.rb.AddForce(((Vector2)seed.transform.position - touchPosition) * force);
                }
            }
        }
    }
}
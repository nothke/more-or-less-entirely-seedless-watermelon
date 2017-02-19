using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch : MonoBehaviour
{
    Seed[] seeds;

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

        Vector2[] touchPositions;

        // if on android device
        if (Input.touchCount > 0)
        {
            touchPositions = new Vector2[Input.touchCount];

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];

                // convert pixel position to world
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                touchPositions[i] = touchPosition;
            }
        }

        // if in Unity just override the position array to mouse, no pinching for now
#if UNITY_EDITOR
        Vector2 mouseScreenPosition = Input.mousePosition;

        touchPositions = new Vector2[1];
        touchPositions[0] = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        isDown = Input.GetMouseButton(0);
#endif

        if (isDown)
        {
            foreach (var touchPosition in touchPositions)
            {
                Debug.DrawLine(touchPosition, touchPosition + Vector2.up * 1, Color.white);

                foreach (var seed in seeds)
                {
                    // just add force to every seed for every touch for now
                    if (Vector2.Distance(seed.transform.position, touchPosition) < 1)
                        seed.rb.AddForce(((Vector2)seed.transform.position - touchPosition) * 100);
                }
            }
        }
    }
}
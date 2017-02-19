using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch : MonoBehaviour
{
    public List<Seed> seeds;

    void Start()
    {
        // get touch from both sides
    }

    void Update()
    {
        int divider = Screen.currentResolution.width / 2;

        Vector2 mouseP = Input.mousePosition;

        bool isDown = Input.touchCount > 0;

        Vector2 touchPos = Vector2.zero;

        //Vector2 touchPositions = new Vector2();

        //if (Input.touchCount > 0)

        /*
        Touch t = Input.GetTouch(0);

        int player = t.position.x < divider ? 1 : 2;

        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //Vector2 touchPos = new Vector2(wp.x, wp.y);
        */

#if UNITY_EDITOR
        touchPos = mouseP;
        isDown = Input.GetMouseButton(0);
#endif
        Vector3 wp = Camera.main.ScreenToWorldPoint(touchPos);

        Debug.DrawLine(touchPos, touchPos + Vector2.up * 10, Color.white);
        
        if (isDown)
        {
            Debug.Log("DOWN! " + touchPos);

            foreach (var seed in seeds)
            {
                if (Vector2.Distance(seed.transform.position, wp) < 1)
                    seed.rb.AddForce((seed.transform.position - wp) * 100);
            }
        }
    }
}

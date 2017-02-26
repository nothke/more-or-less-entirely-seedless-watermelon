using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public float punchSize = 2;
    public float punchAngle = 10;

    public Transform pivot;

    public float startDelay = 2;


    [System.Serializable]
    public class SpriteAppear
    {
        public string name;
        public float afterTime;
        public SpriteRenderer sprite;
    }

    public SpriteAppear[] spriteAppears;

    void Start()
    {
        foreach (SpriteAppear SA in spriteAppears)
        {
            SA.sprite.enabled = false;
        }

        StartCoroutine(AppearCo());
    }

    IEnumerator AppearCo()
    {
        yield return new WaitForSeconds(startDelay);
        GetComponent<AudioSource>().Play();

        foreach (SpriteAppear SA in spriteAppears)
        {
            yield return new WaitForSeconds(SA.afterTime);

            SA.sprite.enabled = true;
            SA.sprite.transform.DOPunchScale(Vector3.one * punchSize, 0.2f);
            SA.sprite.transform.DOPunchRotation(Random.onUnitSphere * punchAngle, 0.2f);

            pivot.transform.DOPunchRotation(Random.onUnitSphere * punchAngle, 0.1f);
        }
    }
}

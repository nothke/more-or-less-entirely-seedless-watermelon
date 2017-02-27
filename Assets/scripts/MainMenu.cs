using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float punchSize = 2;
    public float punchAngle = 10;

    public Transform pivot;

    public float startDelay = 2;

    public Transform PREEPS;
    public Transform present;

    [System.Serializable]
    public class SpriteAppear
    {
        public string name;
        public float afterTime;
        public SpriteRenderer sprite;
    }

    public SpriteAppear[] spriteAppears;

    bool splashEnded;
    bool moleswEnded;

    public AudioClip preepsClip;
    public AudioClip presentClip;
    public GameObject musicPrefab;

    void Start()
    {
        foreach (SpriteAppear SA in spriteAppears)
        {
            SA.sprite.enabled = false;
        }

        PREEPS.localScale = Vector3.zero;
        present.localScale = Vector3.zero;

        creditsButton.localScale = Vector3.zero;
        playButton.localScale = Vector3.zero;

        StartCoroutine(AppearCo());
    }

    IEnumerator AppearCo()
    {
        yield return new WaitForSeconds(1);

        // SPLASH!
        PREEPS.transform.localScale = Vector3.zero;

        preepsClip.Play(Vector3.zero, minDistance: 1000);

        PREEPS.transform.DOScale(Vector3.one * 0.69f, 0.3f);

        PREEPS.transform.DOPunchRotation(Vector3.forward * 10, 1, 20);


        yield return new WaitForSeconds(1);

        // PRESENT
        present.DOScale(Vector3.one * 1.448438f, 0.1f);
        presentClip.Play(Vector3.zero, minDistance: 1000, volume: 0.5f);

        yield return new WaitForSeconds(1);



        PREEPS.transform.DOScale(Vector3.zero, 0.3f);

        // MOLESW!
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

        moleswEnded = true;

        yield return new WaitForSeconds(0.2f);


        playButton.DOScale(1, 0.2f);
        creditsButton.DOScale(1, 0.2f);

        yield return new WaitForSeconds(0.8f);
        DontDestroyOnLoad(Instantiate(musicPrefab));
    }

    private void Update()
    {
        /*
        if (moleswEnded)
            if (Input.touchCount > 0)
                SceneManager.LoadScene(1);*/
    }

    public Transform credits;

    public Transform playButton;
    public Transform creditsButton;
    bool creditsEnabled = false;
    public void ShowCredits()
    {
        creditsEnabled = !creditsEnabled;
        if (creditsEnabled)
        {
            pivot.DOMoveX(10, 0.3f);
            credits.DOMoveX(0.14f, 0.3f);
        }
        else
        {
            pivot.DOMoveX(0, 0.3f);
            credits.DOMoveX(-10f, 0.3f);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}

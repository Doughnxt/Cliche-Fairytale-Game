using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject button;
    [SerializeField] GameObject titleText;
    [SerializeField] TypewritterEffect pageText1;
    [SerializeField] TypewritterEffect pageText2;
    [SerializeField] TypewritterEffect pageText3;
    [SerializeField] private float pageDelay = 5f;
    [SerializeField] private float readingDelay = 4f;
    [SerializeField] private SceneManagerObject sceneManager;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject table;
    [SerializeField] private AudioSource music;
    [SerializeField] private bool endText;
    private bool turnDownVolume;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (endText)
        {
            anim.SetTrigger("Start_Open");
            StartCoroutine(WaitForText2());
        }
    }

    public void StartButtonPress()
    {
        anim.SetTrigger("Open");
        button.SetActive(false);
        titleText.SetActive(false);
        Cursor.visible = false;
    }
    public void StartText()
    {
        StartCoroutine(WaitForText());
    }

    private IEnumerator WaitForText()
    {
        pageText1.EndCheck();
        yield return new WaitForSeconds(pageDelay);
        pageText2.EndCheck();
        turnDownVolume = true;
        yield return new WaitForSeconds(readingDelay);
        sceneManager.LoadTheNextScene();
    }

    private IEnumerator WaitForText2()
    {
        yield return new WaitForSeconds(1f);
        pageText1.EndCheck();
        yield return new WaitForSeconds(pageDelay);
        pageText2.EndCheck();
        yield return new WaitForSeconds(readingDelay);
        pageText1.gameObject.SetActive(false);
        pageText2.gameObject.SetActive(false);
        turnDownVolume = true;
        anim.SetTrigger("Flip");
        yield return new WaitForSeconds(2f);
        pageText3.EndCheck();
        yield return new WaitForSeconds(readingDelay);
        player.SetActive(true);
        table.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (turnDownVolume)
        {
            music.volume -= .001f;
        }
    }
}

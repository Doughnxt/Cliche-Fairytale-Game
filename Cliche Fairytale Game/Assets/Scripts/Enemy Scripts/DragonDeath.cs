using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDeath : MonoBehaviour
{
    [SerializeField] private EnemyHealth dragonHeath;
    private SceneManagerObject sceneManager;
    [SerializeField] private GameObject player;
    [SerializeField] private bool isQuill;
    private bool isDead;

    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManagerObject>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        if (dragonHeath.dead && !isDead)
        {
            isDead = true;
            player.SetActive(false);
            dragonHeath.gameObject.SetActive(false);
            sceneManager.LoadTheNextScene();
            if (isQuill)
            {
                GameManager.timerGoing = false;
            }
        }
    }


}

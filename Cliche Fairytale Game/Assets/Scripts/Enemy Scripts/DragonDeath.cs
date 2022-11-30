using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDeath : MonoBehaviour
{
    [SerializeField] private EnemyHealth dragonHeath;
    private SceneManagerObject sceneManager;
    private GameObject player;
    private bool isDead;

    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManagerObject>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (dragonHeath.dead && !isDead)
        {
            isDead = true;
            player.SetActive(false);
            dragonHeath.gameObject.SetActive(false);
            sceneManager.LoadTheNextScene();
        }
    }


}

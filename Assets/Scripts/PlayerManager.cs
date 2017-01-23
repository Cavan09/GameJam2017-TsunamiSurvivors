using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using System.Linq;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance { get; private set; }
    public GameObject playerObject;
    Scene m_GameScene;
    List<PlatformerCharacter2D> Players = new List<PlatformerCharacter2D>();
    
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        m_GameScene = SceneManager.GetActiveScene();
        SpawnPlayers();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_GameScene.ToString() == "SplashSceen")
        {
            if (Input.anyKeyDown)
            {
                InitalizeGame();
            }
        }
        else if(m_GameScene.ToString() == "GameScene")
        {
            UpdateGameScene();
        }
	}

    static void UpdateGameScene()
    {

    }

    void InitalizeGame()
    {
        SceneManager.LoadScene("GameScene");
        SpawnPlayers();
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 0)
        {
            SpawnPlayers();
        }
    }

    void SpawnPlayers()
    {
        for (int i = 0; i < 4; i++)
        {
            var player = GameObject.Instantiate(playerObject);
            Players.Add(player.GetComponent<PlatformerCharacter2D>());
        }
    }
}

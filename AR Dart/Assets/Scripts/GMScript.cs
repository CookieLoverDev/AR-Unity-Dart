using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour
{
    //Declaring 
    public GameObject DartPrefab;
    private float speed = 25.0f;
    private Rigidbody dartRB;

    private int playerScore;
    public Text scoreText;

    public Transform spawnLoc;

    public GameObject WinScreen;
    public GameObject shootBtnObject;

    private void Awake()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();

        shootBtnObject.SetActive(true);

        SpawnDart();
    }

    private void Update()
    {
        if (playerScore >= 5)
        {
            GameWon();
        }
    }

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void ShootBtn()
    {
        ShootDart(dartRB);
    }

    public void ShootDart(Rigidbody dartRB)
    {
        Vector3 shootTarget = Camera.main.transform.forward;

        dartRB.AddForce(shootTarget *  speed, ForceMode.Impulse);
        SpawnDart();
    }

    public void SpawnDart()
    {
        GameObject newDart = Instantiate(DartPrefab, spawnLoc);
        dartRB = newDart.GetComponent<Rigidbody>();
    }

    private void GameWon()
    {
        WinScreen.SetActive(true);
        shootBtnObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

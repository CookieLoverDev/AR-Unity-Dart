using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This is the main game script, which is responsible for the game's logic
/// </summary>

public class GMScript : MonoBehaviour
{
    //Game elements regarding the Dart(its prefab, speed and physical body)
    public GameObject DartPrefab;
    private float speed = 25.0f;
    private Rigidbody dartRB;

    //Game elements regarding Player Score
    private int playerScore;
    public Text scoreText;

    //Spawn Location for the dart
    public Transform spawnLoc;

    //Win screen and Shoot button UI elements
    public GameObject WinScreen;
    public GameObject shootBtnObject;

    //Setting player score to 0, activating the Shoot button and spawning the first dart in Awake method, which is called before any other method
    //automatically
    private void Awake()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();

        shootBtnObject.SetActive(true);

        SpawnDart();
    }

    //Checking in the Update method(called every frame) if player score reached and/or exceeded 5 points, if so calling GameWon method
    private void Update()
    {
        if (playerScore >= 5)
        {
            GameWon();
        }
    }

    //A method that adds 1 point to player score and changes the UI score text
    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    //A method for the shoot button, which calls ShootDart mathod, that launches the dart
    //Reason why it wasn't all done in one method, button press cannot pass an argument
    public void ShootBtn()
    {
        ShootDart(dartRB);
    }

    //A method that launches the dart at the location where the camera is looking.
    //We take position that is forward to the game camera and give the dart's body an impulse towards that position
    public void ShootDart(Rigidbody dartRB)
    {
        Vector3 shootTarget = Camera.main.transform.forward;

        dartRB.AddForce(shootTarget *  speed, ForceMode.Impulse);
        SpawnDart();
    }

    //This method spawns a new dart on the spawn location
    //It is called after the previous dart is launched
    public void SpawnDart()
    {
        GameObject newDart = Instantiate(DartPrefab, spawnLoc);
        dartRB = newDart.GetComponent<Rigidbody>();
    }

    //A method that activates a Winning Screen and deactivates a button to shoot darts
    private void GameWon()
    {
        WinScreen.SetActive(true);
        shootBtnObject.SetActive(false);
    }

    //This method restarts the scene(in our case the whole game)
    //The button to call this method is activated only after winning the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    public GameObject DartPrefab;
    private float speed = 25.0f;
    private Rigidbody dartRB;

    private int playerScore;
    public Text scoreText;

    public Transform spawnLoc;

    private void Start()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        SpawnDart();
    }

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void ShootBtn()
    {
        ShootDart(dartRB);
        StartCoroutine(WaitToSpawn());
    }

    public void ShootDart(Rigidbody dartRB)
    {
        Vector3 shootTarget = Camera.main.transform.forward;

        dartRB.AddForce(shootTarget *  speed, ForceMode.Impulse);
    }

    public void SpawnDart()
    {
        GameObject newDart = Instantiate(DartPrefab, spawnLoc);
        dartRB = newDart.GetComponent<Rigidbody>();
    }

    private IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(2);
        SpawnDart();
    }
}

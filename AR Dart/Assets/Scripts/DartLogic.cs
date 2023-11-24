using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This code is responsible for the Dart's behaviour
/// </summary>

public class DartLogic : MonoBehaviour
{
    //Declaring the GMScript(Game Manager's Script)
    private GMScript mainLogic;

    //In awake, we are looking for object in game with tag "GameManager" and getting script component, which we are assigning to "mainLogic"
    private void Awake()
    {
        mainLogic = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GMScript>();
    }

    //This method is only called when the Dart's body collides into other game object
    //When the dart collides into something, the method checks if it is the Dartboard, if so, it calls the AddScore method from the GMScript
    //After that, it destroys the dart
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dartboard")
        {
            mainLogic.AddScore();
        }

        Destroy(gameObject);
    }
}

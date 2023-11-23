using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartLogic : MonoBehaviour
{
    private Rigidbody dartRB;
    private GMScript mainLogic;
    public float shootForce = 25.0f;

    private void Start()
    {
        mainLogic = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GMScript>();
        dartRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dartboard")
        {
            dartRB.constraints = RigidbodyConstraints.FreezeAll;
            mainLogic.AddScore();
        }
    }
}

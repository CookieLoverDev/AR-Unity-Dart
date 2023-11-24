using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocScript : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.position = Camera.main.transform.position;
        gameObject.transform.rotation = Camera.main.transform.rotation;
    }
}

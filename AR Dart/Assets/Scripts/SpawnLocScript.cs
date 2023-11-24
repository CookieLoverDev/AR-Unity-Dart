using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocScript : MonoBehaviour
{
    /// <summary>
    /// This code makes the dart's spawn location follow the camera(of device) and rotate towards where camera is looking
    /// </summary>

    //In update we are changing the gameObject's(spawn point's) position and rotation the same as camera every frame
    void Update()
    {
        gameObject.transform.position = Camera.main.transform.position;
        gameObject.transform.rotation = Camera.main.transform.rotation;
    }
}

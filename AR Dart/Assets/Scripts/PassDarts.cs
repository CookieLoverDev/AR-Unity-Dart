using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassDarts : MonoBehaviour
{
    //In this piece of code we are just making the darts not collide with other darts, because it can cause several bugs
    private void Awake()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Dart"), LayerMask.NameToLayer("Dart"), true);
    }
}

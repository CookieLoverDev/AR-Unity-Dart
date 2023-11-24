using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassDarts : MonoBehaviour
{
    private void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Dart"), LayerMask.NameToLayer("Dart"), true);
    }
}

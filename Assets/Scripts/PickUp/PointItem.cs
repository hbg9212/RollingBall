using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointItem : PickUp
{
    protected override void OnPickedUp(GameObject receiver)
    {
        Debug.Log("Ãæµ¹");
    }

}

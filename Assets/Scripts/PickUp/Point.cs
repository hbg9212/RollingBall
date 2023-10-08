using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : PickUp
{
    protected override void OnPickedUp(GameObject receiver)
    {
        RoomManager.Instance._topUi.UpdateSlot();
    }

}

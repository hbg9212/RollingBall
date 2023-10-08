using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;

    private void OnTriggerEnter(Collider other)
    {
        if (canBePickupBy.value == (canBePickupBy.value | (1 << other.gameObject.layer)))
        {
            OnPickedUp(other.gameObject);
            if (destroyOnPickup)
            {
                Destroy(gameObject);
            }
        }
    }

    protected abstract void OnPickedUp(GameObject receiver);
}
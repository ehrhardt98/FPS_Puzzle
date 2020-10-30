using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    Rigidbody rb;
    public int boxId;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetPickedUpState(Transform holder)
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = holder.position;
        transform.parent = holder;
    }

    public void SetDroppedState()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.parent = null;
    }

    public int ReturnBoxId()
    {
        return boxId;
    }

}

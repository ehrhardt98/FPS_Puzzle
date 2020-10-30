using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickup : MonoBehaviour
{
    public Transform holdPosition;
    bool hasObj = false;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50.0f, Color.red);
        CheckForObjPickup();
    }

    private void CheckForObjPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20.0f))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!hasObj)
                {
                    if (hit.transform.gameObject.GetComponent<Pickupable>())
                    {
                        hit.transform.gameObject.GetComponent<Pickupable>().SetPickedUpState(holdPosition);
                        StartCoroutine(wait1());
                    }
                }
                else if (hasObj)
                {
                    if (hit.transform.gameObject.GetComponent<Pickupable>())
                    {
                        hit.transform.gameObject.GetComponent<Pickupable>().SetDroppedState();
                        StartCoroutine(wait2());
                    }
                }
            }
        }
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(0.2f);
        hasObj = true;
    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(0.2f);
        hasObj = false;
    }
}

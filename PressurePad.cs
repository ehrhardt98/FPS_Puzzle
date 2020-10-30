using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    public int padId;
    int objectsOnPad = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pickupable>() != null)
        {
            objectsOnPad++;

            if (other.gameObject.GetComponent<Pickupable>().ReturnBoxId() == padId)
            {
                ColorPadManager.instance.IncreaseCorrectPlacements();
            }

            ColorPadManager.instance.IncreasePlacements();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Pickupable>() != null)
        {
            objectsOnPad--;

            ColorPadManager.instance.DecreasePlacement();

            if (other.gameObject.GetComponent<Pickupable>().ReturnBoxId() == padId)
            {
                ColorPadManager.instance.DecreaseCorrectPlacement();
            }
        }
    }
}

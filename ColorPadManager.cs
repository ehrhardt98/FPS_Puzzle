using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ColorPadManager : MonoBehaviour
{
    public static ColorPadManager instance;
    public List<GameObject> pressurePads;
    public List<GameObject> boxes;
    public List<Color> possibleColors;

    public int totalCorrectPlacementsNeeded;
    public int currentCorrectPlacements;
    public int placements;

    public Text canvasText;
    public UnityEvent completeEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        totalCorrectPlacementsNeeded = pressurePads.Count;
        currentCorrectPlacements = 0;
        RandomizeColorList();
        AssignColorsToListObjects(boxes);
        RandomizeColorList();
        AssignColorsToListObjects(pressurePads);
        ShuffleBoxOrder();
    }

    public void IncreasePlacements()
    {
        placements++;

        if (placements == totalCorrectPlacementsNeeded)
        {
            canvasText.text = currentCorrectPlacements.ToString();
        }
    }

    public void DecreasePlacement()
    {
        placements--;
    }

    public void IncreaseCorrectPlacements()
    {
        currentCorrectPlacements++;

        if (currentCorrectPlacements == totalCorrectPlacementsNeeded)
        {
            Debug.Log("all boxes placed correctly!");
            completeEvent.Invoke();
        }
    }

    public void DecreaseCorrectPlacement()
    {
        currentCorrectPlacements--;
    }

    void Update()
    {
        
    }

    void AssignColorsToListObjects(List<GameObject> objs)
    {
        for (int i=0; i<objs.Count;i++)
        {
            objs[i].GetComponent<Renderer>().material.color = possibleColors[i];
        }
    }

    void RandomizeColorList()
    {
        List<Color> tempColors = new List<Color>();

        for (int i=0; i<possibleColors.Count; i++)
        {
            tempColors.Add(possibleColors[i]);
        }

        for (int i=0; i<possibleColors.Count; i++)
        {
            Color tempColor = possibleColors[i];
            int randomIndex = UnityEngine.Random.Range(i, possibleColors.Count);
            possibleColors[i] = possibleColors[randomIndex];
            possibleColors[randomIndex] = tempColor;
        }
    }

    void ShuffleBoxOrder()
    {
        int idNumber = 0;
        
        for(int i=0; i<boxes.Count; i++)
        {
            GameObject temp = boxes[i];
            int randomIndex = UnityEngine.Random.Range(i, boxes.Count);
            boxes[i] = boxes[randomIndex];
            boxes[randomIndex] = temp;

            boxes[i].GetComponent<Pickupable>().boxId = idNumber;
            pressurePads[i].GetComponent<PressurePad>().padId = idNumber;
            idNumber++;
        }
    }
}

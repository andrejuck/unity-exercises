using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimalInput();
    }

    private void AnimalInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckAnimal(Animal.Eagle);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CheckAnimal(Animal.Cat);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            CheckAnimal(Animal.Dolphin);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckAnimal(Animal.Spider);
        }
    }

    private void CheckAnimal(Animal animal)
    {
        switch (animal)
        {
            case Animal.Eagle:
                Debug.Log("Eagle");
                break;
            case Animal.Dolphin:
                Debug.Log("Dolphin");
                break;
            case Animal.Cat:
                Debug.Log("Cat");
                break;
            case Animal.Spider:
                Debug.Log("Spider");
                break;
            default:
                Debug.Log("Unknow animal");
                break;
        }
    }
}

public enum Animal
{
    Eagle,
    Dolphin,
    Cat,
    Spider
}

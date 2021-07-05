using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AnimatedPanel inventoryPanel;
    public AnimatedPanel characterPanel;
    public AnimatedPanel settingsPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.Toggle();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            characterPanel.Toggle();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPanel.Toggle();
        }
    }
}

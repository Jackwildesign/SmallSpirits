using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{

    public bool placingMode = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForRayCollision();
    }

    private void CheckForRayCollision()
    {
        Ray placementRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (placingMode == true)
        {
            if (Physics.Raycast(placementRay, out hitInfo, 15))
            {
                print("There is something in front of the object!");
            }

        }
    }

    public void TogglePlacingMode(bool modeSelected)
    {
        placingMode = modeSelected;
        CheckPlacingModeState();
    }

    private void CheckPlacingModeState()
    {
        if (placingMode)
        {

            //find out which object we selected to place
            //show visual represnetation of this
            //Allow the player to click to place items
        }
    }
}

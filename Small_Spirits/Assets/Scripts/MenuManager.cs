using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] PlacementMenuUI placementMenu;
    public bool placementUIOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenPlacementMenu(true);
        }
    }

    
    //IS called true via button press but we have a close button to call false when closing the menu.
    public void OpenPlacementMenu(bool menuState)
    {
        placementMenu.gameObject.SetActive(menuState);

        if (menuState == true)
        {
            Cursor.lockState = CursorLockMode.None;
            placementUIOpen = true;
        }
        else if (menuState == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            placementUIOpen = false;
        }
    }
}

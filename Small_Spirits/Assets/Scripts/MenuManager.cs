using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] PlacementMenuUI placementMenu;
    [SerializeField] GameObject journal;
    public bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (journal.activeSelf == false)
            {
                AlterMenuStateMenu(true, journal);
            }
            else
            {
                AlterMenuStateMenu(false, journal);
            }
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePlacementMenu();
        }
    }

    public void TogglePlacementMenu()
    {
        if (placementMenu.gameObject.activeSelf == false)
        {
            AlterMenuStateMenu(true, placementMenu.gameObject);
        }
        else
        {
            AlterMenuStateMenu(false, placementMenu.gameObject);
        }
    }


    //IS called true via button press but we have a close button to call false when closing the menu.
    public void AlterMenuStateMenu(bool menuState, GameObject menuToChange)
    {
        menuToChange.gameObject.SetActive(menuState);

        if (menuState == true)
        {
            Cursor.lockState = CursorLockMode.None;
            menuOpen = true;
        }
        else if (menuState == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            menuOpen = false;
        }
    }
}

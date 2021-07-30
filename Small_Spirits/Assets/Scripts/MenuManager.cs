using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] PlacementMenuUI placementMenu;

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

    public void OpenPlacementMenu(bool menuState)
    {
        print("Running open menu script");

        placementMenu.gameObject.SetActive(menuState);

        if (menuState == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (menuState == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

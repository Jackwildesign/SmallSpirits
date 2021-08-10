using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlacementMenuUI : MonoBehaviour
{
    [SerializeField] GameObject placementMenu;

    [SerializeField] ScrollRect plantMenu;
    [SerializeField] ScrollRect rockMenu;
    [SerializeField] ScrollRect miscMenu;
    [SerializeField] TMP_Text exitUIButtonPrompts;
    
    public List<ScrollRect> subMenus = new List<ScrollRect>();

    void Start()
    {
        placementMenu.gameObject.SetActive(false);
        rockMenu.gameObject.SetActive(false);
        miscMenu.gameObject.SetActive(false);

        subMenus.Add(plantMenu);
        subMenus.Add(rockMenu);
        subMenus.Add(miscMenu);
    }

    public void SelectSubMenus(ScrollRect selectedMenu)
    {
        foreach (ScrollRect subMenu in subMenus)
        {
            if (subMenu == selectedMenu)
            {
                subMenu.gameObject.SetActive(true);
            }
            else if (subMenu != selectedMenu)
            {
                subMenu.gameObject.SetActive(false);
            }
            else
            {
                print("Invalid submenu passed to select sub menu function");
            }
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceClensingTool : MonoBehaviour
{

    [SerializeField] Camera fpsCamera;
    [SerializeField] ClensingTool clensingTool;
    [SerializeField] PlayerCurrencyManager playerCurencyRef;
    [SerializeField] PlacementManager placementManagerRef;
    [SerializeField] MenuManager menuManagerRef;

    ClensingTool clensingToolToPlace;

    bool clensingToolIsPlaced;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckForLeftClick();
        CheckForRightClick();

    }

    private void CheckForLeftClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnClensingTool();
        }
    }

    private void CheckForRightClick()
    {
        //todo - Change this to be based on a keyboard press?
        if (Input.GetButtonDown("Fire2"))
        {
            ReturnClensingTool();
        }
    }

    private void ReturnClensingTool()
    {
        if (clensingToolIsPlaced == true && placementManagerRef.gameObject.activeSelf == false && menuManagerRef.placementUIOpen == false)
        {
            CollectCurrencyFromClensingTool();
            clensingToolIsPlaced = false;
            Destroy(clensingToolToPlace.gameObject);
        }
    }

    private void CollectCurrencyFromClensingTool()
    {
        int collectedCurrency = clensingToolToPlace.currency;
        playerCurencyRef.StringCurrencyTotal(collectedCurrency);
    }

    void SpawnClensingTool()
    {
        if(clensingToolIsPlaced == false && placementManagerRef.gameObject.activeSelf == false && menuManagerRef.placementUIOpen == false)
            
        {
            clensingToolToPlace =  Instantiate(clensingTool, transform.position, transform.rotation);
            clensingToolIsPlaced = true;
        }
        else
        {
            //Show text and play audio
            Debug.Log("Clensing Tool Placed already");
        }
    }
}

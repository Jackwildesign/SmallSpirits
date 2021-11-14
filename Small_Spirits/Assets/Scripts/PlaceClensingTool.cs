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
    [SerializeField] GameObject fakeClensingTool;

    ClensingTool clensingToolToPlace;

    public bool clensingToolIsPlaced;
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
        if (Input.GetButtonDown("Fire1") && fakeClensingTool.activeSelf)
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

    public void ReturnClensingTool()
    {
        if (clensingToolIsPlaced == true && placementManagerRef.gameObject.activeSelf == false && menuManagerRef.menuOpen == false)
        {
            CollectCurrencyFromClensingTool();
            clensingToolIsPlaced = false;

            //while (Vector3.Distance(transform.position, clensingTool.transform.position) >= 0.5f)
            //{
            //    //Moves the clensing tool towards the player? I hope...
            //    clensingTool.transform.position = Vector3.MoveTowards(clensingTool.transform.position, transform.position, 1 * Time.deltaTime);
            //}

            fakeClensingTool.SetActive(true);
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
        if(clensingToolIsPlaced == false && placementManagerRef.gameObject.activeSelf == false && menuManagerRef.menuOpen == false)
            
        {
            clensingToolToPlace =  Instantiate(clensingTool, fakeClensingTool.transform.position, fakeClensingTool.transform.rotation);
            fakeClensingTool.SetActive(false);
            clensingToolIsPlaced = true;
        }
        else
        {
            //Show text and play audio
            Debug.Log("Clensing Tool Placed already");
        }
    }
}

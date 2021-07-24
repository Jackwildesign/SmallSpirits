using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceClensingTool : MonoBehaviour
{

    [SerializeField] Camera fpsCamera;
    [SerializeField] ClensingTool clensingTool;

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
        if (Input.GetButtonDown("Fire2"))
        {
            ReturnClensingTool();
        }
    }

    private void ReturnClensingTool()
    {
        if (clensingToolIsPlaced == true)
        {
            var toolsToDelete = FindObjectsOfType<ClensingTool>();
            foreach (ClensingTool clensingtool in toolsToDelete)
            Destroy(gameObject);
        }
    }

    void SpawnClensingTool()
    {
        if(clensingToolIsPlaced == false)
        {
            Instantiate(clensingTool, transform.position, transform.rotation);
            clensingToolIsPlaced = true;
        }
        else
        {
            //Show text and play audio
            Debug.Log("Clensing Tool Placed already");
        }
    }
}

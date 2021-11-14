using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelectionManager : MonoBehaviour
{
    [SerializeField] GameObject fakeClensingTool;
    [SerializeField] GameObject fakeSheeringTool;
    [SerializeField] GameObject fakeSpellTool;
    [SerializeField] GameObject fakeHands;
    [SerializeField] PlaceClensingTool placeClensingToolRef;

    // Start is called before the first frame update
    void Start()
    {
        fakeClensingTool.SetActive(false);
        fakeSheeringTool.SetActive(false);
        fakeSpellTool.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateTool(fakeSheeringTool);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            ActivateTool(fakeClensingTool);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateTool(fakeSpellTool);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActivateTool(fakeHands);
        }
    }

    private void ActivateTool(GameObject toolSelected)
    {
        
        GameObject[] tools = new GameObject[] { fakeClensingTool, fakeSheeringTool, fakeSpellTool, fakeHands};
        foreach(GameObject tool in tools)
        {
            if (tool == toolSelected)
            {
                tool.SetActive(true);

                if (tool == fakeClensingTool && placeClensingToolRef.clensingToolIsPlaced)
                {
                    placeClensingToolRef.ReturnClensingTool();
                }
                
            }
            else
            {
                tool.SetActive(false);
            }
        }
    }
}

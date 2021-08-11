using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    GameObject placeableObjectPrefab;

    [SerializeField] LayerMask placementLayerMask;
    [SerializeField] Camera cam;

    //made seralize so I can check if its being turned on it editor.
    [SerializeField] bool readyToPlace = false;

    private GameObject currentPlaceableObject;

    public void SetCurrentPlaceableObject (GameObject selectedObject)
    {
        placeableObjectPrefab = selectedObject;
    }

    private void Update()
    {
        HandleNewObject();

        if (currentPlaceableObject != null)
        {
            print(currentPlaceableObject.name + " != null ");
            CheckForRayCollision();
            ReleaseIfClicked();
        }
        ClosePlacementModeOnMouse1();

    }

    private void HandleNewObject()
    {
        if (placeableObjectPrefab != null && readyToPlace == false)
        {
            print("Trying to spawn " + placeableObjectPrefab.name);
            currentPlaceableObject = Instantiate(placeableObjectPrefab);
            readyToPlace = true;
        }
    }

    private void CheckForRayCollision()
    {
        Ray placementRay = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hitInfo;
        //Debug.DrawRay(cam.transform.position, Vector3.forward * 10);
        if (Physics.Raycast(placementRay, out hitInfo, 20, placementLayerMask))
        {
            if (readyToPlace)
            {
                currentPlaceableObject.transform.position = hitInfo.point;
                currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            }
            
        }
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
            readyToPlace = false;
        }
    }

    //Allows us to exit this placement mode by pressing Mouse 1 or Esc
    private void ClosePlacementModeOnMouse1()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
                readyToPlace = false;
                gameObject.SetActive(false);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] GameObject placeableObjectPrefab;

    [SerializeField] LayerMask placementLayerMask;
    [SerializeField] Camera cam;

    bool readyToPlace;
    private GameObject currentPlaceableObject;

    private void Update()
    {
        CheckForRayCollision();
        ReleaseIfClicked();

        if (Input.GetKeyDown(KeyCode.Mouse3) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
                gameObject.SetActive(false);
            }
        }

        
    }

    private void CheckForRayCollision()
    {
        Ray placementRay = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hitInfo;
        //Debug.DrawRay(cam.transform.position, Vector3.forward * 10);
        if (Physics.Raycast(placementRay, out hitInfo, 20, placementLayerMask))
        {
            print("Ray has hit = " + hitInfo.collider.gameObject.name);
            ShowPlacingObject();
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void ShowPlacingObject()
    {
        if (readyToPlace == false)
        {
            currentPlaceableObject = Instantiate(placeableObjectPrefab);
            print("Spawning" + currentPlaceableObject.name);
            readyToPlace = true;
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
}

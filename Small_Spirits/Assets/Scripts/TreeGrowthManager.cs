using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowthManager : MonoBehaviour
{
    [Header("Models for Each stage of Growth")]
    [SerializeField] GameObject stageOneModel;
    [SerializeField] GameObject stageTwoModel;
    [SerializeField] GameObject stageThreeModel;
    [SerializeField] GameObject stageFourModel;

    [Header("Growth Thresholds")]
    [SerializeField] int stageTwoAmount = 60;
    [SerializeField] int stageThreeAmount = 120;
    [SerializeField] int stageFourAmount = 240;

    GameObject currentGameObject;

    void Start()
    {
        currentGameObject = stageOneModel;
        StartCoroutine(StartGrowing());
    }

    IEnumerator StartGrowing()
    {
        //Do we want to keep growing old so we can have trees die over time? Maybe.

        yield return new WaitForSeconds(stageTwoAmount);
        SwitchTreeModel(stageTwoModel);

        yield return new WaitForSeconds(stageThreeAmount);
        SwitchTreeModel(stageThreeModel);

        yield return new WaitForSeconds(stageFourAmount);
        SwitchTreeModel(stageFourModel);
    }

    private void SwitchTreeModel(GameObject treeToSpawn)
    {
        print("Spawning " + treeToSpawn.name);
        Destroy(currentGameObject.gameObject);
        currentGameObject = Instantiate(treeToSpawn, transform.position, transform.rotation);
        currentGameObject.transform.parent = gameObject.transform; 
    }
}

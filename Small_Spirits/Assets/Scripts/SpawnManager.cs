using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject lion;
    [SerializeField] GameObject lionSpawner;
    [SerializeField] GameObject chicken;
    [SerializeField] GameObject chickenSpawner;

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(CheckSceneForRequirements());
    }

    IEnumerator CheckSceneForRequirements()
    {
        while (gameObject.activeSelf)
        {
            print("Checking eco system");
            CheckForChickenRequirements();
            yield return new WaitForSeconds(10);
        }
    }

    private void CheckForChickenRequirements()
    {
        var mushrooms = FindObjectsOfType(typeof(MushroomHealth));
        
        //Add other requirements for the chicken habitat
        if (mushrooms.Length >= 10)
        {
            CheckForChickens(mushrooms.Length);
        }
    }

    private void CheckForChickens(int mushrooms)
    {


        var chickens = FindObjectsOfType(typeof(ChickenAI));
        if (chickens.Length  <= mushrooms / 10)
        {
            GameObject newChickn = Instantiate(chicken, chickenSpawner.transform.position, chickenSpawner.transform.rotation);
            print("Spawning a chicken");
        }

        if (chickens.Length >= 5)
        {
            CheckForLionRequiremnts(chickens.Length);

        }
    }

    private void CheckForLionRequiremnts(int chickens)
    {
        var lions = FindObjectsOfType(typeof(LionAI));
        if (lions.Length < chickens/5)
        {
            GameObject newLion = Instantiate(lion, lionSpawner.transform.position, lionSpawner.transform.rotation);
            print("Spawning a Lion");
        }
    }
}

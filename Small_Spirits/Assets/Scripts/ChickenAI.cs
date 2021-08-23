using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    [SerializeField] int hunger = 20;
    [SerializeField] int health = 5;
    NavMeshAgent navMeshAgent;
    bool hungry;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(BecomeHungry());
    }

    void Update()
    {
        if (hunger <= 5)
        {
            health = health - 1;
        }
        else if (hunger <= 15)
        {
            HuntForFood();
            hungry = true;
        }
        else if (hunger > 15)
        {
            hungry = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator BecomeHungry()
    {
        while (gameObject.activeSelf)
        {
            hunger = hunger - 1;
            yield return new WaitForSeconds(5);
        }
    }

    private void HuntForFood()
    {
        {
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 20);
            foreach (Collider hitcollider in hitColliders)
            {
                print("Searching for Mushrooms, found a " + hitcollider.gameObject.name);
                if (hitcollider.gameObject.tag == "Mushroom")
                {
                    print("Found a mushroom");
                    navMeshAgent.SetDestination(hitcollider.gameObject.transform.position);
                    //MoveToFoodAndEat();
                    return;
                }
            }
        }
    }

    private static void MoveToFoodAndEat()
    {
        
        //Go to first game object
        //If still there eat it again
        //If not, run search for food again.
        //Eat the mushroom
        //Increase hunger int.
    }
}

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
    Vector3 target;
    GameObject food;
    float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(BecomeHungry());
    }

    void Update()
    {
        CheckHunger();

        if (food != null)
        {
            navMeshAgent.SetDestination(target);
            transform.LookAt(target);
            if (distanceToTarget <= navMeshAgent.stoppingDistance)
            {
                var plantAIRef = food.GetComponentInParent<PlantCorruption>();
                plantAIRef.GetEaten();
                hunger = hunger + 1;
            }
        }

    }

    private void CheckHunger()
    {
        if (hunger <= 5)
        {
            health = health - 1;

            if (health <= 0)
            {
                Destroy(gameObject);
            }

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
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 20);
            foreach (Collider hitcollider in hitColliders)
            {
                if (hitcollider.gameObject.tag == "Mushroom")
                {
                    distanceToTarget = Vector3.Distance(hitcollider.transform.position, transform.position);
                    target = hitcollider.gameObject.transform.position;
                    food = hitcollider.gameObject;
                }
            }
    }


}

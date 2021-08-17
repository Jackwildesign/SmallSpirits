using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHealth : MonoBehaviour
{
    [SerializeField] int mushHealth = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BiteTaken(int biteAmount)
    {
        mushHealth = mushHealth - biteAmount;

        if (mushHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

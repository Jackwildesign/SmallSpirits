using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCorruption : MonoBehaviour
{

    public float corruption = 100f;

    public void RemoveCorruption(int clensingpower)
    {
        if (corruption > 0)
        {
            corruption = corruption - clensingpower; //Turn this into a corutine so it takes longer to occur.
        }
        else if (corruption <= 0)
        {
            Renderer treeRender = GetComponent<Renderer>();
            treeRender.material.SetColor("Green", Color.green);
        }
        print("corruption = " + corruption);

    }
}

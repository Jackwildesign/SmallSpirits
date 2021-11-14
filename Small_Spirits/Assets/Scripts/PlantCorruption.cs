using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCorruption : MonoBehaviour
{
    //System.NonSerializedAttribute
    public int maxCorruption = 100;
    public int corruption = 100;
    float corruptionColour;
    

    public int bushValue = 5;
    [SerializeField] int health = 3;
    MeshRenderer meshRenderer;

    [SerializeField] Color corruptionColor = Color.black;
    [SerializeField] Color noneCorruptionColor = Color.white;
    Color plantColor;

    void Start()
    {
        corruption = maxCorruption;
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        ModifyColor();
    }

    public void RemoveCorruption(int clensingpower)
    {
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        }

        if (corruption > 0)
        {
            corruption -= clensingpower;

            //prevents corruption going below zero
            if (corruption < 0 )
            {
                corruption = 0;
            }
            ModifyColor();
        }
    }

    private void ModifyColor()
    {
        float corruptionRation = (float)corruption / maxCorruption;
        Color plantColor = Color.Lerp(noneCorruptionColor, corruptionColor, corruptionRation);
        meshRenderer.material.color = plantColor;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0 )
        {
            Destroy(gameObject);
        } 
    }
}

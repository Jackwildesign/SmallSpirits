using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClensingTool : MonoBehaviour
{
    
    public float clensingRadius;
    [SerializeField] int clensingPower = 1;
    [SerializeField] float clensingSpeed = 0.5f;
    private Collider[] hitColliders;
    public int currency = 0;

    void Start()
    {
        CheckForTreestoClense();
    }

    private void CheckForTreestoClense()
    {
        hitColliders = Physics.OverlapSphere(transform.position, clensingRadius);
        AccessRemoveCorruptionOnTrees();
    }

    private void AccessRemoveCorruptionOnTrees()
    {
        foreach (Collider tree in hitColliders)
        {
            if (tree.gameObject.layer == 7)
            {
                PlantCorruption plantScript = tree.gameObject.GetComponentInParent<PlantCorruption>();

                StartCoroutine(BeginClensing(plantScript));
            }
        }
    }

    IEnumerator BeginClensing(PlantCorruption plantScript)
    {
        if (plantScript != null)
        {
            while (plantScript.corruption > 0)
            {

                plantScript.RemoveCorruption(clensingPower);
                currency++;
                yield return new WaitForSeconds(clensingSpeed);

            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushCutting : MonoBehaviour
{
    [SerializeField] PlayerCurrencyManager currencyManager;
    [SerializeField] GameObject sheers;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask cuttingLayerMask;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sissors;

    [Header("Animation")]
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && sheers.activeSelf == true)
        {
            audioSource.PlayOneShot(sissors);
            animator.Play("Sissors Chopping");
            Ray choppingRay = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(choppingRay, out hitInfo, 10, cuttingLayerMask))
            {
                print("Attempting to cut " + hitInfo.collider.gameObject.name);
                var plantToCut = hitInfo.collider.GetComponentInParent<PlantCorruption>();
                currencyManager.StringCurrencyTotal(plantToCut.bushValue);
                plantToCut.TakeDamage(5);
               
            }
        }
    }
}

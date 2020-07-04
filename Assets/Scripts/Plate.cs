using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] GameObject plateObject = null;
    [SerializeField] GameObject brokenPlate = null;

    public void Break()
    {
        //Activate broken plate, and remove regular.
        brokenPlate.SetActive(true);
        plateObject.SetActive(false);
        
        //Get every plate piece.
        foreach (Rigidbody rb in brokenPlate.GetComponentsInChildren<Rigidbody>())
        {
            //Random force vector
            rb.AddForce(new Vector3(Random.Range(-250, 250), Random.Range(-250, 250), Random.Range(-250, 250)));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cannonball")) { Break(); }
    }
}
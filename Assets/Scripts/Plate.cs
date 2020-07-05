using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] GameObject plateObject = null;
    [SerializeField] GameObject brokenPlate = null;

    public void Break()
    {
        //Disable collider.
        GetComponent<Collider>().enabled = false;

        //Activate broken plate, and remove regular.
        brokenPlate.SetActive(true);
        plateObject.SetActive(false);    

        //Get every plate piece.
        foreach (Rigidbody rb in brokenPlate.GetComponentsInChildren<Rigidbody>())
        {
            //Random force vector
            rb.AddForce(new Vector3(Random.Range(-250, 250), Random.Range(-250, 250), Random.Range(-250, 250)));
        }

        //Start a lifespan countdown for 7 seconds.
        gameObject.AddComponent<LifespanCountdown>();

        //Remove the parent. If the plate was inheriting any movement it no longer will.
        transform.parent = null;

        GetComponent<SoundManager>().PlayRandomClip();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision registered by " + other.name);
        if (other.CompareTag("Cannonball")) { Break(); }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifespanCountdown : MonoBehaviour
{
    public float lifeTimeInSeconds = 10f;

    //Starts the countdown when this object is created.
    public bool countdownOnInstantiation;

    //Start the countdown
    void Start()
    {
        if (countdownOnInstantiation) { StartCountdown(); }
    }

    public void StartCountdown() { StartCoroutine(LifeCountdown()); }

    private IEnumerator LifeCountdown()
    {
        yield return new WaitForSeconds(lifeTimeInSeconds);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifespanCountdown : MonoBehaviour
{
    public float _lifespanInSeconds = 7f;

    //Starts the countdown when this object is created.
    public bool countdownOnInstantiation = true;

    //Start the countdown
    void Start()
    {
        if (countdownOnInstantiation) { StartCountdown(); }
    }

    public void StartCountdown() { StartCoroutine(LifeCountdown()); }

    private IEnumerator LifeCountdown()
    {
        yield return new WaitForSeconds(_lifespanInSeconds);
        Destroy(gameObject);
    }

    public LifespanCountdown(float lifespanInSeconds, bool startCountdownImmediatly)
    {
        _lifespanInSeconds = lifespanInSeconds;
        countdownOnInstantiation = startCountdownImmediatly;
    }

    public LifespanCountdown()
    {
        _lifespanInSeconds = 7;
        countdownOnInstantiation = true;
    }
}

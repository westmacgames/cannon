using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateWheel : MonoBehaviour
{
    [Range(0f, 10f)]
    public float rotationSpeed;

    [Range(0f, 6f)]
    public float strafeMovementSpeed;

    [Range(0f, 6f)]
    public float upMovementSpeed;

    // Update is called once per frame
    void Update()
    {
        //Rotate
        transform.Rotate(0, 0, rotationSpeed * 20 * Time.deltaTime);

        //X Movement
        transform.position = new Vector3(originalPosition.x + (strafeMovementSpeed * Mathf.Sin(Time.time)), 0, 0);
    }

    //These functions handle the position the wheel should always return to.
    public Vector3 originalPosition { private set; get; }

    //Should be called in start. Sets the position that the wheel returns equal to the current plate position.
    private void SetOriginalPosition() { originalPosition = transform.position; }

    void Start() => SetOriginalPosition(); // Call it
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateWheel : MonoBehaviour
{
    [Range(3, 10)]
    public float speed;

    public List<Plate> plates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * 20 * Time.deltaTime);
    }
}

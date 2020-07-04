using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Range(5f, 50f)]
    public float power;

    [Range(1f, 3f)]
    public float sensitivity;

    [SerializeField]
    private Transform shootPoint = null;

    [SerializeField]
    private GameObject cannonBall = null;

    private CannonInput input;
    private void Awake()
    {
        input = new CannonInput();
        input.Game.Shoot.performed += ctx => Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        GameObject newCannonBall = Instantiate(cannonBall, shootPoint.position, Quaternion.identity);
        newCannonBall.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * 100 * power);
    }

    void Look()
    {

    }

    private void OnEnable() { input.Enable(); }
    private void OnDisable() { input.Disable(); }
}

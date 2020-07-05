using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Cannon : MonoBehaviour
{
    [Header("Cannon Settings")]
    [Range(25f, 45f)]
    public float power;

    [Range(1f, 3f)]
    public float sensitivity;

    [SerializeField]
    [Tooltip("The point where the ball is shot from. The blue/forward axis should point out from the cannon.")]
    private Transform shootPoint = null;

    [SerializeField]
    [Tooltip("Cannonball prefab to be shot out from shootPoint")]
    private GameObject cannonBall = null;

    [Header("Camera Shake")]
    [Space]

    [Range(5f, 15f)] public float magn;
    [Range(5f, 15f)] public float rough;
    [Range(0.0f, 1.5f)] public float fadeIn;
    [Range(0.5f, 2f)] public float fadeOut;
  
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
        CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
        GameObject newCannonBall = Instantiate(cannonBall, shootPoint.position, Quaternion.identity);
        newCannonBall.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * 100 * power);
    }

    void Look()
    {

    }

    private void OnEnable() { input.Enable(); }
    private void OnDisable() { input.Disable(); }
}

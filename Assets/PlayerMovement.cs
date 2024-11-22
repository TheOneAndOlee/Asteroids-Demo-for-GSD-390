using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float thrustFactor = 15;

    [SerializeField]
    private float bulletSpeed = 20;

    [SerializeField]
    private float torqueFactor = 100;

    [SerializeField]
    private GameObject bulletPrefab;


    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.position = transform.position;

            var bulletRigidBody = bulletInstance.GetComponent<Rigidbody2D>();
            bulletRigidBody.velocity = transform.up * bulletSpeed * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rigidbody.AddForce(transform.up * thrustFactor);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.SetRotation(rigidbody.rotation + torqueFactor * Time.fixedDeltaTime);
            rigidbody.freezeRotation = false;
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            rigidbody.freezeRotation = false;
            rigidbody.SetRotation(rigidbody.rotation - torqueFactor * Time.fixedDeltaTime);
        }
        else
        {
            rigidbody.freezeRotation = true;
        }

    }
}

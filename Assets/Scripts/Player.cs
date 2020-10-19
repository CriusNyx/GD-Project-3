using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject cameraParent;

    float playerFacingAngle;
    float currentTurnSpeed = 0f;
    float maxTurnSpeed = 90f;
    float turnAcceleration = 300f;

    float acceleration = 50f;
    float maxSpeed = 5f;

    Vector3 velocity;
    new Rigidbody rigidbody;

    public void Start()
    {
        cameraParent = transform.Find("CameraParent").gameObject;
        rigidbody = gameObject.GetComponentInChildren<Rigidbody>();
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        float cameraInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            cameraInput += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraInput += 1f;
        }

        currentTurnSpeed = Mathf.MoveTowards(currentTurnSpeed, cameraInput * maxTurnSpeed, turnAcceleration * Time.deltaTime);

        playerFacingAngle += currentTurnSpeed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.Euler(0f, playerFacingAngle, 0f);
        cameraParent.transform.rotation = lookRotation;

        float movementInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            movementInput += 1f;
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementInput += -0.5f;
            GetComponent<AudioSource>().Play();
        }

        Vector3 currentVelocity = rigidbody.velocity;
        currentVelocity = Vector3.MoveTowards(currentVelocity, lookRotation * Vector3.forward * movementInput * maxSpeed, acceleration * Time.deltaTime);

        rigidbody.velocity = currentVelocity;
    }
    public void ForceToLookAt(Vector3 direction)
    {

    }
}
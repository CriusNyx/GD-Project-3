using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    float maxSpeed = 1;
    new Rigidbody rigidbody;
    Vector3 monsterVelocity;
    bool hasSpawned;
    Vector3 target;
    void Start()
    {
        hasSpawned = false;
        rigidbody = gameObject.GetComponentInChildren<Rigidbody>();
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveMonster();
    }
    public void SpawnInitialMonster()
    {
        hasSpawned = true;
        transform.position = new Vector3(-10, 1, 61);
        UnityEngine.Debug.Log(transform.position);
    }
    void MoveMonster()
    {
        target = GameObject.Find("Player").transform.position;
        if (hasSpawned)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, maxSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter()
    {
        UnityEngine.Debug.Log("You have died. Game Over.");
    }
}

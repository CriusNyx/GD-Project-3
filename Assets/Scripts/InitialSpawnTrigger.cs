using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InitialSpawnTrigger : MonoBehaviour
{
    public MonsterBehavior Monster;
    public Player player;
    public AudioSource monsterClip, ringingClip;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        StartCoroutine(SpawnMonster());
        monsterClip.Play();
        ringingClip.Play();
        player.PlayScarySound();
    }
    IEnumerator SpawnMonster()
    {
        UnityEngine.Debug.Log("Player entered the inital spawn zone.");
        Monster.SpawnInitialMonster();
        //Player.ForceToLookAt(new Vector3(-10, 1, 61));
        Destroy(this);
        yield return new WaitForSeconds(5);
        
    }
}
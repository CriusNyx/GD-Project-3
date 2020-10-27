using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    AudioSource footstepSound;
    AudioSource bigThunder;
    AudioSource rain;
    AudioSource scarySound;
    AudioSource fuseBox;
    AudioSource killerFound;
    AudioSource bodyFound;
    GameObject normalLights;
    GameObject emergancyLights;
    GameObject flashlight;

    public void Start()
    {
        cameraParent = transform.Find("CameraParent").gameObject;
        rigidbody = gameObject.GetComponentInChildren<Rigidbody>();
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        footstepSound = transform.Find("Sounds/FootstepSound").GetComponent<AudioSource>();
        bigThunder = transform.Find("Sounds/BigThunder").GetComponent<AudioSource>();

        normalLights = GameObject.Find("NormalLights");
        emergancyLights = GameObject.Find("EmergancyLights");

        emergancyLights.SetActive(false);

        flashlight = transform.Find("CameraParent/Flashlight").gameObject;

        flashlight.SetActive(false);

        rain = transform.Find("Sounds/Rain").GetComponent<AudioSource>();

        scarySound = transform.Find("Sounds/ScarySound").GetComponent<AudioSource>();

        // Voice over sounds
        fuseBox = transform.Find("Sounds/FuseBox").GetComponent<AudioSource>();
        bodyFound = transform.Find("Sounds/Body").GetComponent<AudioSource>();
        killerFound = transform.Find("Sounds/CallCops").GetComponent<AudioSource>();

        StartCoroutine(FootstepSounds());
        StartCoroutine(PowerOut());
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
            //GetComponent<AudioSource>().Play();
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementInput += -0.5f;
            //GetComponent<AudioSource>().Play();
        }

        Vector3 currentVelocity = rigidbody.velocity;
        currentVelocity = Vector3.MoveTowards(currentVelocity, lookRotation * Vector3.forward * movementInput * maxSpeed, acceleration * Time.deltaTime);

        rigidbody.velocity = currentVelocity;
    }
    public void ForceToLookAt(Vector3 direction)
    {

    }

    private IEnumerator FootstepSounds()
    {
        while (true)
        {
            int input = 0;
            if (Input.GetKey(KeyCode.W)) 
                input += 1;
            if (Input.GetKey(KeyCode.S))
                input -= 1;
            if(input != 0)
            {
                footstepSound.Play();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator PowerOut()
    {
        yield return new WaitForSeconds(10f);
        bigThunder.Play();
        yield return new WaitForSeconds(1.5f);
        normalLights.SetActive(false);
        yield return new WaitForSeconds(1f);
        emergancyLights.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        emergancyLights.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        emergancyLights.SetActive(true);
        yield return new WaitForSeconds(2f);
        flashlight.SetActive(true);
        fuseBox.Play();
    }

    public void TriggerRainStop()
    {
        StartCoroutine(FadeOut(rain, 5f));
    }

    private IEnumerator FadeOut(AudioSource source, float time)
    {
        float localTime = 0f;
        while(localTime < time)
        {
            localTime += Time.deltaTime;
            float t = localTime / time;
            source.volume = 1 - t;
            yield return null;
        }
        source.Stop();
    }

    public void PlayScarySound()
    {
        killerFound.Play();
        StartCoroutine(FadeIn(scarySound, 5f));
    }

    private IEnumerator FadeIn(AudioSource source, float time)
    {
        source.volume = 0;
        source.Play();
        float localTime = 0f;
        while (localTime < time)
        {
            localTime += Time.deltaTime;
            float t = localTime / time;
            source.volume = t;
            yield return null;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Monster")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
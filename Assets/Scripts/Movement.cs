using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float boostSpeed = 1000f;
    [SerializeField] float rotationThrust = 300f;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.W))
        {
            StartThrusting();
        }

        else
        {
            StopThrustEffect();   
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * boostSpeed * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            if(!mainBoosterParticles.isPlaying)
            {
                mainBoosterParticles.Play();
            }
    }

    void StopThrustEffect()
    {
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }


    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

        else
        {
            StopRotationEffects();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
            if(!rightBoosterParticles.isPlaying)
            {
                rightBoosterParticles.Play();
            }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
            if(!leftBoosterParticles.isPlaying)
            {
                leftBoosterParticles.Play();
            }
    }

    void StopRotationEffects()
    {
        rightBoosterParticles.Stop();
        leftBoosterParticles.Stop();
    }

    void ApplyRotation(float rpf) // rpf = rotation per frame
    {
        transform.Rotate(Vector3.forward * rpf * Time.deltaTime);
    }

}

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

        else
        {
            audioSource.Stop();
            mainBoosterParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if(!rightBoosterParticles.isPlaying)
            {
                rightBoosterParticles.Play();
            }
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if(!leftBoosterParticles.isPlaying)
            {
                leftBoosterParticles.Play();
            }
        }

        else
        {
            rightBoosterParticles.Stop();
            leftBoosterParticles.Stop();
        }
    }

    void ApplyRotation(float rpf) // rpf = rotation per frame
    {
        transform.Rotate(Vector3.forward * rpf * Time.deltaTime);
    }
}

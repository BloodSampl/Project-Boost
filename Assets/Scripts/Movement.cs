using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource soundClip;
    [SerializeField] private float thrust = 1;
    [SerializeField] private float rotation = 1;
    // Start is called before the first frame update
    void Start()
    {
        soundClip = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if(!soundClip.isPlaying)
            {
                soundClip.Play();
            }
        }
        else
        {
            soundClip.Stop();
        }
        
    }
        void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false)
        {
            ApplyRotation(rotation);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) == false)
        {
            ApplyRotation(- rotation);
        }
    }

     void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing Rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // un freezing Rotation so the Phsysics System can take Control
    }
}

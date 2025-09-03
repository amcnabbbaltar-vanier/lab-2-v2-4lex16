using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;
    private Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * moveX) + (transform.forward * moveZ);
        
        rb.AddForce(movement * moveSpeed, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win");
        }
        else if (other.CompareTag("DeathPlane"))
        {
            rb.position = startPosition;
        }
    }
}

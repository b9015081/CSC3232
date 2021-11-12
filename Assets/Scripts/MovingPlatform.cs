using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform start;
    public Transform end;
    public float travelTime;

    private Rigidbody rb;
    private Vector3 currentPos;

    CharacterController cc;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // platform oscillates between two points using cosine curve
    void Update()
    {
        currentPos = Vector3.Lerp(start.position, end.position,
            Mathf.Cos(Time.time / travelTime * Mathf.PI * 2) * -0.5f + 0.5f);
        rb.MovePosition(currentPos);
    }


    // player moves with platform
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cc = other.GetComponent<CharacterController>();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }
}

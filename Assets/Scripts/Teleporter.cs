using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    

    public Transform receiver;

   
    void OnTriggerEnter(Collider Col)
    {
        // sends player to receiver
        Col.transform.position = receiver.position;
    }
}

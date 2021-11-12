using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float distToGround = 1f;

    Vector3 velocity;

    bool isGrounded;

    int score = 0;
    int pointsPerCoin = 100;
    
    public GameObject scoretext;

    // Update is called once per frame
    void Update()
    {
       // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);

        // player movement
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // score when player picks up coins

        if (other.gameObject.CompareTag("Coin"))
        {
            score += pointsPerCoin;
            scoretext.GetComponent<Text>().text = "Score: " + score.ToString();
        }
            
    }

}


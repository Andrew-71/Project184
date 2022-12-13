using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController controller;

    [SerializeField] private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // find rotation
        float rotation = Mathf.Atan2(x, z) * Mathf.Rad2Deg;

        // account for rotation so that movement ignores rotation (Horizontal and Vertical are relative to rotation)
        Vector3 move;
        if (x != 0 || z != 0)
        {
            move = Quaternion.Euler(0f, rotation, 0f) * Vector3.forward;
        }
        else
        {
            move = Vector3.zero;
        }


        // speed_main is a float that should be positive if we are moving forward and negative if we are moving backwards
        float speed_main = Vector3.Dot(move, transform.forward);
        // speed_side is a float that should be positive if we are moving right and negative if we are moving left
        float speed_side = Vector3.Dot(move, transform.right);
        animator.SetFloat("speed", speed_main);
        animator.SetFloat("speed_side", speed_side);
        
        controller.Move(move * speed * Time.deltaTime);
        
        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down * 9.81f * Time.deltaTime);
        }
    }
}
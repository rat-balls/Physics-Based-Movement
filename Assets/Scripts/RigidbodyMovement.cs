using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{   
    private Vector3 playerMovementInput;

    [SerializeField] private Transform playerCam;
    [SerializeField] private Rigidbody torso;
    [SerializeField] private Rigidbody spineBase;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;
    [SerializeField] public Vector3 moveVector;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(Input.GetKeyDown(KeyCode.A))
        {
            speed = speed * 2;
        } else if(Input.GetKeyUp(KeyCode.A))
        {
            speed = speed / 2;
        }

        if(playerMovementInput.magnitude >= 0.1f){
            spineBase.MoveRotation(Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f));
            torso.MoveRotation(Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f));
        }
    }

    private void FixedUpdate() 
    {
        movePlayer();
    }

    private void movePlayer()
    {   
    
        moveVector = spineBase.transform.TransformDirection(playerMovementInput) * speed;
        spineBase.velocity = new Vector3(moveVector.x, spineBase.velocity.y, moveVector.z);
        torso.velocity = new Vector3(moveVector.x, torso.velocity.y, moveVector.z);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            spineBase.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }
}

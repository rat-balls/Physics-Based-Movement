using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    [SerializeField] private Rigidbody Head;
    [SerializeField] private Rigidbody Torso;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float force;
    [SerializeField] private bool standing;
    [Space]
    [Header("Feet")]
    [SerializeField] private Rigidbody FootL;
    [SerializeField] private Rigidbody FootR;
    [SerializeField] private float feetDist;
    [SerializeField] private bool feetGrounded;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Head.position, Vector3.down, distance, groundMask))
        {
            standing = false;
        } else {
            standing = true;
        }

        if(Physics.Raycast(FootL.position, Vector3.down, feetDist, groundMask) || Physics.Raycast(FootR.position, Vector3.down, feetDist, groundMask))
        {
            feetGrounded = false;
        } else {
            feetGrounded = true;
        }
    }

    private void FixedUpdate() 
    {
        if(!standing)
        {
            Head.AddForce(new Vector3(0f, force, 0f), ForceMode.Force);
            Torso.AddForce(new Vector3(0f, force, 0f), ForceMode.Force);
        }
    }
}

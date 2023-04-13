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
    [SerializeField] private bool footLGrounded;
    [SerializeField] private bool footRGrounded;
    
    private RaycastHit hit;
    private Vector3 Lhit;
    private Vector3 Rhit;

    // Update is called once per frame
    void Update()
    {

        if(Physics.Raycast(Head.position, Vector3.down, distance, groundMask))
        {
            standing = false;
        } else {
            standing = true;
        }

        if(Physics.Raycast(FootL.position, Vector3.down, out hit, feetDist, groundMask))
        {
            footLGrounded = true;
            Lhit = hit.point;
        } else {
            footLGrounded = false;
        }

        if(Physics.Raycast(FootR.position, Vector3.down, out hit, feetDist, groundMask))
        {
            footRGrounded = true;
            Rhit = hit.point;
        } else {
            footRGrounded = false;
        }
    }

    private void FixedUpdate() 
    {   
        if(footLGrounded)
        {

        }


        if(!standing)
        {
            Head.AddForce(new Vector3(0f, force, 0f), ForceMode.Force);
            Torso.AddForce(new Vector3(0f, force, 0f), ForceMode.Force);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanonoff : MonoBehaviour
{
    public BoxCollider maincollider;
    public GameObject ThisGuysRig;
    public Animator ThisGuysAnimator;

    void Start()
    {
        GetRagdollBits();
        ModeOff();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ModeOn();
        }
    }

    Collider[] ragcolliders;
    Rigidbody[] limbrigidbodies; // Change RigidBody to Rigidbody

    void GetRagdollBits()
    {
        ragcolliders = ThisGuysRig.GetComponentsInChildren<Collider>();
        limbrigidbodies = ThisGuysRig.GetComponentsInChildren<Rigidbody>(); // Change RigidBody to Rigidbody
    }

    void ModeOn()
    {
        ThisGuysAnimator.enabled = false;

        foreach (Collider col in ragcolliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbrigidbodies)
        {
            rigid.isKinematic = false;
        }
        maincollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true; // Change RigidBody to Rigidbody
    }

    void ModeOff()
    {
        foreach (Collider col in ragcolliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbrigidbodies)
        {
            rigid.isKinematic = true;
        }
        ThisGuysAnimator.enabled = true;
        maincollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false; // Change RigidBody to Rigidbody
    }
}

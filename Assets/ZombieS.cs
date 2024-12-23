using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieS : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _animator;

    public GameObject _Target;
    // Start is called before the first frame update
    void Start()
    {
       _agent = GetComponent<NavMeshAgent>();
       _animator = GetComponent<Animator>();

       _Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_Target.transform.position);

        //Animation
        if(_agent.velocity.x==0 && _agent.velocity.y==0 && _agent.velocity.z==0)
        {
             _animator.SetBool("Walk", false);
        }
        else
        {
             _animator.SetBool("Walk", true);
        }
    }
}

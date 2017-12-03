using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderScript : LifeScript {

    public Transform Destination;
    public LifeBarScript LifeBar;
    private Animator animator;
    private NavMeshAgent agent;
    bool waitActive = false; //so wait function wouldn't be called many times per frame
    private bool isAttack = false;
    
    public override void Damage(int d)
    {
        base.Damage(d);
        LifeBar.Damage(d);
        animator.SetInteger("Pv", Pv);
        if(Pv <= 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            animator.SetBool("isAttack", false);
            gameObject.tag = "SpiderDied";
            Destroy(this);
        }
    }

    private void Start()
    {
        // agent.destination = Destination.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //agent = GetComponent<NavMeshAgent>();
        if (!isAttack) { agent.destination = Destination.position; }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<LifeScript>())
            {
                if (!waitActive)
                {
                    other.gameObject.GetComponent<LifeScript>().Damage(3);
                    StartCoroutine(Wait());
                }
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isAttack = true;
            animator.SetBool("isAttack", isAttack);
            agent.isStopped = true;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isAttack = false;
            animator.SetBool("isAttack", isAttack);
            agent.isStopped = false;
        }
    }

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(1.0f);
        waitActive = false;
    }

    /*private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i), 0.001f);
        }
        transform.parent.gameObject
    }*/
}

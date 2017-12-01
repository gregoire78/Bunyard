using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderScript : LifeScript {

    public Transform Destination;
    public LifeBarScript LifeBar;
    private NavMeshAgent agent;

    public override void Damage(int d)
    {
        base.Damage(d);
        LifeBar.Damage(d);
        GetComponent<Animator>().SetInteger("Pv", Pv);
        if(Pv <= 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(this);
        }
    }

    private void Start()
    {
        // agent.destination = Destination.position;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //agent = GetComponent<NavMeshAgent>();
        agent.destination = Destination.position;
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

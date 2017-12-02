using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    private LifeScript ObjectInRange;
    public int timer;
    public float ExplosionPower;
    public int Damage;
    bool timeExpected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Example());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (timeExpected)
        {
            if (other.tag == "Player")
            {
                Rigidbody ObjectInRange = other.gameObject.GetComponent<Rigidbody>();
                other.gameObject.GetComponent<LifeScript>().Damage(Damage);
                ObjectInRange.AddForce(Vector3.Normalize(ObjectInRange.transform.position - transform.position) * ExplosionPower);
                Destroy(gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(timeExpected)
        {
            //ObjectInRange.Damage(20);
            //ObjectInRange.AddForce(Vector3.Normalize(ObjectInRange.transform.position - transform.position) * ExplosionPower);
            
        }
	}

    IEnumerator Example()
    {
        yield return new WaitForSeconds(timer);
        timeExpected = true;
    }
}

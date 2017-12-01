using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4);
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<LifeScript>())
        {
            collision.gameObject.GetComponent<LifeScript>().Damage(2);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBulletScript : MonoBehaviour {

    public List<GameObject> SpiderScripts;
    // Use this for initialization
    void Start () {
        foreach (GameObject SpiderScript in SpiderScripts)
        {
            SpiderScript.GetComponent<SpiderScript>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Player")
        {
            foreach (GameObject SpiderScript in SpiderScripts)
            {
                SpiderScript.GetComponent<SpiderScript>().enabled = true;
            }
        }
    }
}

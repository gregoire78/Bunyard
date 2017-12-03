using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConditionScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (GameObject.FindGameObjectsWithTag("Spider").Length > 0)
            {
                gameObject.GetComponent<DoorScript>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<DoorScript>().enabled = true;
            }
        }
    }
}

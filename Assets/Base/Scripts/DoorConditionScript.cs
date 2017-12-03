using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConditionScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("Spider").Length <= 0 && !GameObject.FindGameObjectWithTag("BoxWithThirdIndice"));
            if (GameObject.FindGameObjectsWithTag("Spider").Length <= 0 && !GameObject.FindGameObjectWithTag("BoxWithThirdIndice"))
            {
                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionScript : MonoBehaviour {

    public bool isHold;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag == "Player" );
        if(other.tag == "Player" && Input.GetKey(KeyCode.I) && !isHold)
        {
            isHold = true;
            Transform weapon = other.transform.Find("Camera/Weapon/StartBulletPosition");
            gameObject.transform.parent = weapon;
        }
        if (Input.GetKey(KeyCode.O) && isHold)
        {
            isHold = false;
            transform.parent = null;
        }
    }
}

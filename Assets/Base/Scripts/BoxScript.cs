using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : LifeScript {

    public BoxCollider activatedDoor;

    public override void Damage(int d)
    {
        
        base.Damage(d);
        if (Pv <= 0)
        {
            if (gameObject.tag == "BoxWithIndice") { activatedDoor.GetComponent<BoxCollider>().enabled = true; }
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

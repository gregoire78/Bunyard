using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : LifeScript {

    public override void Damage(int d)
    {
        base.Damage(d);
        if (Pv <= 0)
        {
            SceneManager.LoadScene("Base");
        }
    }
}

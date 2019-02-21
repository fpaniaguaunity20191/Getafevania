using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Item {
    private const int NUM_VIDAS = 1;
    public override void Kill()
    {
        base.Kill();
        Destroy(this.gameObject);
    }
    public override void DoAction()
    {
        base.DoAction();
        GameManager.AddLive(NUM_VIDAS);
        Kill();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item {
    public int points;
    public override void Kill()
    {
        base.Kill();
        Destroy(this.gameObject);
    }
    public override void DoAction()
    {
        base.DoAction();
        GameManager.AddPoints(points);
        Kill();
    }
}

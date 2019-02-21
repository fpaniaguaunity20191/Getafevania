using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public AudioClip collectSound;
    public GameObject prefabEffect;
    public virtual void DoAction() { }
    public virtual void Kill() {
        if (prefabEffect != null) {
            RunEffect();
        }
    }
    private void RunEffect() {
        if (prefabEffect != null) {
            Instantiate(prefabEffect, transform.position, transform.rotation);
        }
    }
    public void PlaySound()
    {

    }
}

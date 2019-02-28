using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private const string ANIM_PARAM_CHECKED = "checked";
    private bool bChecked = false;
    private Animator animador;
    private void Awake()
    {
        animador = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER) && bChecked==false)
        {
            bChecked = true;
            animador.SetBool(ANIM_PARAM_CHECKED, true);
            collision.gameObject.GetComponent<Player>().SetCheckPointPosition(transform.position);
        }
    }
}

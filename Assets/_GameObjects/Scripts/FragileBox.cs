using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileBox : MonoBehaviour {
    public float delay;
    public int unidades;
    public float speed;
    private bool cayendo = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Alien" && !cayendo)
        {
            cayendo = true;
            Invoke("IniciarCaida", delay);
        }
    }
    private void IniciarCaida()
    {
        StartCoroutine("Caer");
    }
    private IEnumerator Caer()
    {
        for(int i = 0; i < unidades; i++)
        {
            transform.Translate(0, -Time.deltaTime * speed, 0);
            yield return null;
        }
    }
}

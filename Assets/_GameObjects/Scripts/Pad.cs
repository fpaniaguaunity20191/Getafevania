using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {
    Touch[] pulsaciones;
    Touch pulsacion;
    
    void Update()
    {
        //TACTICL
        pulsaciones = Input.touches;
        //Si no hay pulsaciones no seguimos
        if (pulsaciones.Length != 1)
        {
            return;
        }
        //Recojo la pulsación
        pulsacion = pulsaciones[0];

        //Evaluar las pulsaciones
        switch (pulsacion.phase)
        {
            case (TouchPhase.Began):
                ComenzarToque();
                break;
            case (TouchPhase.Moved):
                MoverToque();
                break;
            case (TouchPhase.Ended):
                FinalizarToque();
                break;
            case (TouchPhase.Canceled):
                //CancelarToque();
                break;
            case (TouchPhase.Stationary):
                //PausarToque();
                break;
            default:
                //EjecutarAccionPorDefectoToque();
                break;
        }
        
    }

    void ComenzarToque()
    {
        print("Comienza Pulsacion");
        ComprobarPulsacionObjetoByName(pulsaciones[0], "Pad");
    }
    void MoverToque()
    {

    }
    void FinalizarToque()
    {
    }
    private Vector2 getWorldPosition(Touch _t)
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(_t.position.x, _t.position.y));
    }

    private bool ComprobarPulsacionObjetoByName(Touch _t, string _name)
    {
        bool estaPulsado = false;
        Vector3 touchWorldPosition = getWorldPosition(_t);
        Debug.DrawLine(Camera.main.transform.position, touchWorldPosition, Color.red, 1000);
        RaycastHit2D rch2d = Physics2D.Raycast(Camera.main.transform.position, touchWorldPosition);
        print("Objeto pulsado:" + rch2d.transform.gameObject.name);
        if (rch2d.transform != null && rch2d.transform.gameObject.name == _name)
        {
            estaPulsado = true;
        }
        return estaPulsado;
    }
}

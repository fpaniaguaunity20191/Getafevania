using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {
    public int maxForce = 500;
    Touch[] pulsaciones;
    Touch pulsacion;
    Vector2 posicionInicial;
    Vector2 posicionFinal;
    bool pajarracoSeleccionado = false;
	void Update () {
        pulsaciones = Input.touches;
        //Si no hay pulsaciones no seguimos
        if (pulsaciones.Length!=1) {
            return;
        }
        //Recojo la pulsación
        pulsacion = pulsaciones[0];
        //Evaluar las pulsaciones
        switch (pulsacion.phase) {
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
    void ComenzarToque() {
        if (!ComprobarPulsacionObjetoByName(pulsacion, "Manejador")){
            return;
        }
        pajarracoSeleccionado = true;
        //Obtenemos el vector de posición en el mundo del juego
        Vector2 posicionConvertida = getWorldPosition(pulsacion);
        //Asignamos la nueva posición
        transform.position = posicionConvertida;
        posicionInicial = posicionConvertida;
    }
    void MoverToque() {
        if (!pajarracoSeleccionado)
        {
            return;
        }
        //Obtenemos el vector de posición en el mundo del juego
        Vector2 posicionConvertida = getWorldPosition(pulsacion);
        //Asignamos la nueva posición
        transform.position = posicionConvertida;
    }
    void FinalizarToque() {
        if (!pajarracoSeleccionado)
        {
            return;
        }
        pajarracoSeleccionado = false;
        //Asignamos la nueva posición
        posicionFinal = getWorldPosition(pulsacion);
        //Calculamos direccion
        Vector2 vectorDistancia = (posicionInicial - posicionFinal);
        Vector2 vectorDireccion = vectorDistancia.normalized;
        float distancia = vectorDistancia.magnitude;
        //Ponemos el rigidbody2d en modo kinematic
        GetComponent<Rigidbody2D>().isKinematic = false;
        //Le damos un empujon
        GetComponent<Rigidbody2D>().AddRelativeForce(vectorDireccion * distancia * maxForce);
    }
    private Vector2 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector2(_t.position.x, _t.position.y));
    }
    private bool ComprobarPulsacionObjetoByName(Touch _t, string _name) {
        bool estaPulsado = false;
        Vector3 touchWorldPosition = getWorldPosition(_t);
        Debug.DrawLine(Camera.main.transform.position, touchWorldPosition, Color.red, 1000);
        RaycastHit2D rch2d = Physics2D.Raycast(Camera.main.transform.position, touchWorldPosition);
        if (rch2d.transform != null & rch2d.transform.gameObject.name == _name) {
            estaPulsado = true;
        }
        return estaPulsado;
    }
    /*
    private Vector3 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector3(_t.position.x, _t.position.y, 0));
    }
    */
}

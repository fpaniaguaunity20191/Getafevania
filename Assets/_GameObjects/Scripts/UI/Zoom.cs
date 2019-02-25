using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Zoom : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float maxScale;
    [SerializeField] float scaleSpeed;

    RectTransform rt;

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("ZoomIn");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ZoomOut();
    }

    public void OnSelect(BaseEventData eventData)
    {
        StartCoroutine("ZoomIn");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ZoomOut();
    }

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    IEnumerator ZoomIn()
    {
        //Escalamos el botón
        while (rt.localScale.x < maxScale) {
            rt.localScale *= 1 + Time.deltaTime * scaleSpeed;
            yield return null;
        }
    }
    private void ZoomOut()
    {
        StopAllCoroutines();
        rt.localScale = new Vector3(1, 1, 1);
    }

    private void OnDisable()
    {
        rt.localScale = Vector3.one;
    }
}

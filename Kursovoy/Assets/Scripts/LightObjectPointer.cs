using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightObjectPointer : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    Color Krishka_color;
    public void OnPointerEnter(PointerEventData eventData)
    {
        var items = GetComponentsInChildren<Renderer>();
        foreach (Renderer joint in items)
        {
            if (joint.name == "ChamferBox005" || joint.name == "ChamferBox006")
            {
                Krishka_color = joint.material.color;
            }
            joint.material.color = (new Color(0, 4, 4)) * 0.25f;
        }



    }
    public void OnPointerExit(PointerEventData eventData)
    {
        var items = GetComponentsInChildren<Renderer>();
        foreach (Renderer joint in items)
        {
            if (joint.name == "ChamferBox005" || joint.name == "ChamferBox006")
            {
                joint.material.color = Krishka_color;
            }
            else
            {
                joint.material.color = Color.white * 1f;
            }
        }
    }
}

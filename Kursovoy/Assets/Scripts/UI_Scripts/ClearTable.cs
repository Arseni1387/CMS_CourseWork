using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClearTable : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]
    TableScript Table;

    Image Backgroungimage;
    public void OnPointerClick(PointerEventData eventData)
    {
        Table.Clear();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Backgroungimage.color = Color.magenta;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Backgroungimage.color = new Color(255, 255, 255, 255);
    }
    void Start()
    {
        Backgroungimage = GetComponent<Image>();
    }

}

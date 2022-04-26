using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorButtonsPracticNotes : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    public Button Button;
    Image Backgroungimage;
    int counter = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        if (counter % 2 == 1)
        {
            Backgroungimage.color = Color.magenta;
        }
        else
        {
            Backgroungimage.color = new Color(255, 255, 255, 255);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Backgroungimage.color = Color.magenta;
        //Backgroungimage.color = new Color(169, 54, 187, 255);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (counter % 2 == 1)
        {
            Backgroungimage.color = Color.blue;
        }
        else
        {
            Backgroungimage.color = new Color(255, 255, 255, 255);
        }
    }
    void Start()
    {
        Backgroungimage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

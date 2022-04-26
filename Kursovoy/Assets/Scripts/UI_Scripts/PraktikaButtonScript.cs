using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PraktikaButtonScript : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    public Button Button;
    public Sprite NormalSprite;
    public Sprite HilitedSprite;

    [SerializeField]
    TaskPanelScript Tasks;

    int counter = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Image>().sprite = HilitedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Image>().sprite = NormalSprite;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        if (counter % 2 == 1)
            Tasks.Show();
        else
        {
            Tasks.Close();
        }

        
    }


}

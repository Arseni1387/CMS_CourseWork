using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddButtonScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public Button Button;
  
    Image InputBackgroungimage;
    [SerializeField]
    TextMeshProUGUI Placeholder;
    [SerializeField]
    TextMeshProUGUI InputText;
    [SerializeField]
    RectTransform PracticText;
    [SerializeField]
    TMP_InputField Input;
    [SerializeField]
    TableScript table;
    int counter = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        if (counter % 2 == 1)
        {           
            Input.enabled = true;
            InputBackgroungimage.enabled = true;
            InputBackgroungimage.enabled = true;
            Placeholder.enabled = true;
            InputText.enabled = true;
        }
        else
        {
            Input.enabled = false;
            InputBackgroungimage.enabled = false;
            Placeholder.enabled = false;
            InputText.enabled = false;
            table.Write();
        }
        //Input.text = "";
    }

   
    void Start()
    {
              InputBackgroungimage = Input.GetComponent<Image>();
        Input.enabled = false;
        InputBackgroungimage.enabled = false;
        Placeholder.enabled = false;
        InputText.enabled = false;
    }

  
}

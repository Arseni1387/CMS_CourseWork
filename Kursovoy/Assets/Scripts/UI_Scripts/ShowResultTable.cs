using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowResultTable : MonoBehaviour, IPointerClickHandler
{
    
    [SerializeField]
    Image ResultTable;
    Image Backgroungimage;
    [SerializeField]
    public Button Button;

    int counter = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        if (counter % 2 == 1)
        {   
            ResultTable.transform.gameObject.SetActive(true);
        }
        else
        {
            ResultTable.transform.gameObject.SetActive(false);
        }
    }


    

    void Start()
    {
        ResultTable.transform.gameObject.SetActive(false);
        Backgroungimage = Button.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Nagr_Grafik_Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject startButton;
    [SerializeField]
    GameObject grafikOxl;


    public TextMeshPro Time1;
    public TextMeshPro Time2;
    public TextMeshPro Time3;
    public TextMeshPro Time4;

    public TextMeshPro ready;
    public TextMeshPro minutes;
    public TextMeshPro seconds;
 


    public bool Status = false;
    bool FLAG=false;
   
    bool Move = false;
    float speed = 0.1f;
    float offset = 0;
    float offset2 = 0;

    Vector3 startPosition;
    Vector3 needPosition;
    Vector3 needPosition2;

    [SerializeField]
    GameObject Pos1;
    [SerializeField]
    GameObject Pos2;

    public void OnPointerClick(PointerEventData eventData)
    {

        if (startButton.GetComponent<Start_Button_Script>().FLAG2)
        {
            Status = true;
        }

        if (Status)
        {
            grafikOxl.GetComponent<Oxl_Grafik_Button>().Status = false;
            ChangeTimeValue();
        }


        if (offset == 0 && offset2 == 0)
        {
            Move = true;
            startPosition = transform.position;
            needPosition = Pos1.transform.position;
            needPosition2 = Pos2.transform.position;
        }
    }


    int isMiddlePosition = 0;
    void FixedUpdate()
    {
        if (!startButton.GetComponent<Start_Button_Script>().FLAG2 && FLAG)
        {
            Status = false;
            StartTimeValue();
        }
        if (Move)
        {


            if (isMiddlePosition == 0)
            {
                offset += speed;
                transform.position = Vector3.Lerp(startPosition, needPosition, offset);

                if (offset >= 1)
                {
                    offset = 0;
                    isMiddlePosition = 2;
                }
            }
            else if (isMiddlePosition == 2)
            {
                offset2 += speed;
                transform.position = Vector3.Lerp(transform.position, needPosition2, offset2);

                if (offset2 >= 1)
                {
                    offset2 = 0;
                    Move = false;
                    isMiddlePosition = 0;
                }
            }
        }
    }

    public void ChangeTimeValue()
    {
        FLAG = true;
        Time1.text = "1:00";
        Time2.text = "2:00";
        Time3.text = "3:00";
        Time4.text = "4:00";
        minutes.text = "05";
        seconds.text = "02";
        ready.text = "Viewing Heating";

    }

    public void StartTimeValue()
    {
        FLAG = false;
        Time1.text = "2:00";
        Time2.text = "4:00";
        Time3.text = "6:00";
        Time4.text = "8:00";
    }
}

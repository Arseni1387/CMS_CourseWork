using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Start_Button_Script : MonoBehaviour, IPointerClickHandler
{
   


    [SerializeField]
    GameObject Al_Stakan;
    [SerializeField]
    GameObject Viklichatel;
    [SerializeField]
    GameObject Ekran;
    [SerializeField]
    GameObject Krishka;

    public TextMeshPro ready;
    public TextMeshPro perI;
    public TextMeshPro perP;
    public TextMeshPro minutes;
    public TextMeshPro seconds;


    public TextMeshPro MaxTHt;
    public TextMeshPro MaxTAr;
    public TextMeshPro MaxTU;


    public bool Status = false;
    public bool Status2 = false;

    public bool FLAG = false;
    public bool FLAG2 = false;

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
      
        if (Viklichatel.GetComponent<Viklichatel>().Status && Al_Stakan.GetComponent<MoveElement>().Status)
        {
            Status = true;
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
        if(!Status)
        {
            Status2 = false;
            FLAG = false;
            FLAG2 = false;
        }
        if (!Viklichatel.GetComponent<Viklichatel>().Status)
        {
            Status = false;          
        }
        else
        {
            if (Status)
            {
                if (Krishka.GetComponent<Krishka>().Status && !Status2 && !FLAG)
                {
                    ChangeValueWorkingHeating();
                }
                else if(!Krishka.GetComponent<Krishka>().Status  && !FLAG2)
                {
                    ChangeValueWorkingCooling();
                }
            }

            else
            {
                StartValue();
            }
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
    public void ChangeValueWorkingHeating()
    {
        FLAG = true;
        ready.text = "Working Heating";
        perI.text = "0,98";
        perP.text = "33,2";
        minutes.text = "05";
        seconds.text = "02";

        MaxTHt.text = "74,3";
        MaxTAr.text = "23,6";
        MaxTHt.text = "21,5";
    }

    public void ChangeValueWorkingCooling()
    {
        FLAG2 = true;
        Status2 = true;
        ready.text = "Working Cooling";
        perI.text = "0,02";
        perP.text = "0,0";
        minutes.text = "03";
        seconds.text = "15";

        MaxTHt.text = "42,3";
        MaxTAr.text = "26,9";
        MaxTHt.text = "42,2";
    }

    public void StartValue()
    {
        Status2 = false;
        ready.text = "Ready";
        perI.text = "0,03";
        perP.text = "0,0";
        minutes.text = "00";
        seconds.text = "00";

        MaxTHt.text = "21,6";
        MaxTAr.text = "20,7";
    }
}

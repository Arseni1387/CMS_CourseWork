using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knopka_Script : MonoBehaviour, IPointerClickHandler
{

    
    [SerializeField]
    GameObject startButton;
   [SerializeField]
    GameObject Viklichatel;

    int startvalue;
    public TextMeshPro value;
    public bool Status = false;
    bool Flag = false;
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
       

        if (offset == 0 && offset2 == 0)
        {
                Move = true;
                startPosition = transform.position;
                needPosition = Pos1.transform.position;
                needPosition2 = Pos2.transform.position;

            if (Viklichatel.GetComponent<Viklichatel>().Status == true && startButton.GetComponent<Start_Button_Script>().Status == false)
            {
                startvalue = int.Parse(value.text);
                if (startvalue < 10 && this.gameObject.name == "Knopka_DAVLENIE_VVERX")
                {
                    startvalue++;
                    value.text = startvalue.ToString();
                }
                else if (startvalue > 6 && this.gameObject.name == "Knopka_DAVLENIE_VNIZ")
                {
                    startvalue--;
                    value.text = startvalue.ToString();
                }


                else if (startvalue <= 75 && this.gameObject.name == "Knopka_TEMP_VVERX")
                {
                    startvalue += 5;
                    value.text = startvalue.ToString();
                }
                else if (startvalue >= 60 && this.gameObject.name == "Knopka_TEMP_VNIZ")
                {
                    startvalue -= 5;
                    value.text = startvalue.ToString();
                }


                else if (startvalue == 2 && this.gameObject.name == "Knopka_OBRAZEC1")
                {
                    startvalue = 1;
                    value.text = startvalue.ToString();
                }
                else if (startvalue == 1 && this.gameObject.name == "Knopka_OBRAZEC2")
                {
                    startvalue = 2;
                    value.text = startvalue.ToString();
                }
            }
       
        }
    }
    int isMiddlePosition = 0;
    void FixedUpdate()
    {
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
}
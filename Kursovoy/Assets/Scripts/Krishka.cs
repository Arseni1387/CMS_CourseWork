using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Krishka : MonoBehaviour, IPointerClickHandler
{
    public bool Flag = false;
    public bool Status = false;
    bool Move = false;
    float speed = 0.03f;
    float offset = 0;
    float offset2 = 0;

    Vector3 startPosition;
    Vector3 needPosition;
    Vector3 needPosition2;

   
    Vector3 needPosition3;
    Vector3 needPosition4;


    [SerializeField]
    GameObject Al_stakan;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Al_stakan.GetComponent<MoveElement>().Status == false)
        {

            if (offset == 0 && offset2 == 0)
            {
                if(!Status)
                {
                    Flag = true;
                }
                else
                {
                    Flag = false;
                }
                Move = true;
                startPosition = transform.position;
                needPosition = transform.position += new Vector3(-6, 0, 0);
                needPosition2 = transform.position += new Vector3(0, -4.6f, 0);


                needPosition3 = transform.position += new Vector3(6, 9.2f, 0);
                needPosition4 = transform.position += new Vector3(6, 0, 0);
            }
        }
    }
    void FixedUpdate()
    {

        if (Move)
        {

            if (Status == false)
            {
                if (offset < 1)
                {
                    offset += speed;
                    transform.position = Vector3.Lerp(startPosition, needPosition, offset);
                }

                if (offset >= 1)
                {
                    offset2 += speed;
                    transform.position = Vector3.Lerp(needPosition, needPosition2, offset2);

                }

            }

            if (Status == true)
            {
                if (offset < 1)
                {
                    offset += speed;
                    transform.position = Vector3.Lerp(startPosition, needPosition3, offset);
                }

                if (offset >= 1)
                {
                    offset2 += speed;
                    transform.position = Vector3.Lerp(needPosition3, needPosition4, offset2);
                }

            }
            if (offset2 >= 1)
            {
                offset = 0;
                offset2 = 0;
                Move = false;
                Status = !Status;
                
            }
        }
    }
    
}

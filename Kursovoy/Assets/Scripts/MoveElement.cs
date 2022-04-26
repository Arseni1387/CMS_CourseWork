using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveElement : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject Krishka;

    [SerializeField]
    GameObject WirePos1;
    [SerializeField]
    GameObject WirePos2;

    [SerializeField]
    GameObject WireMiddlePosition1;
    [SerializeField]
    GameObject WireCub;

   [SerializeField]
    GameObject Pos1;
    [SerializeField]
    GameObject Pos2;
  
    [SerializeField]
    GameObject MiddlePosition1;
    public bool Status = false;
    bool move = false;
    public bool Move
    {
        get => move;
    }
    Vector3 startPosition;
    Vector3 needPosition;
    float speed = 0.04f;
    float offset = 0;
    Quaternion startRotation;
    Quaternion needRotaton;

      

    Vector3 CubstartPosition;
    Vector3 CubneedPosition;
 
    Quaternion CubstartRotation;
    Quaternion CubneedRotaton;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Krishka.GetComponent<Krishka>().Flag==true)
        {

            if (!Status)
            {
                if (!move)
                {
                    move = true;
                    startPosition = transform.position;
                    startRotation = transform.rotation;
                    needPosition = Pos2.transform.position;
                    needRotaton = Pos2.transform.rotation;


                    CubstartPosition = WireCub.transform.position;
                    CubstartRotation = WireCub.transform.rotation;
                    CubneedPosition = WirePos2.transform.position;
                    CubneedRotaton = WirePos2.transform.rotation;
                    Status = true;

                }

            }
            else if (Status)
            {
                if (!move)
                {
                    move = true;
                    startPosition = transform.position;
                    startRotation = transform.rotation;
                    needPosition = Pos1.transform.position;
                    needRotaton = Pos1.transform.rotation;

                    CubstartPosition = WireCub.transform.position;
                    CubstartRotation = WireCub.transform.rotation;
                    CubneedPosition = WirePos1.transform.position;
                    CubneedRotaton = WirePos1.transform.rotation;
                    Status = false;
                }
            }
        }
    }   

    int isMiddlePosition = 0;
    void FixedUpdate()
    {
        if (move)
        {
            if(isMiddlePosition == 0)
            {
                offset += speed;
                transform.position = Vector3.Lerp(startPosition, MiddlePosition1.transform.position, offset);
                transform.rotation = Quaternion.Lerp(startRotation, MiddlePosition1.transform.rotation, offset);

                WireCub.transform.position = Vector3.Lerp(CubstartPosition, WireMiddlePosition1.transform.position, offset);
                WireCub.transform.rotation = Quaternion.Lerp(CubstartRotation, WireMiddlePosition1.transform.rotation, offset);

                if (offset >= 1)
                {                    
                    offset = 0;
                    isMiddlePosition = 2;
                }
            }            
            else if(isMiddlePosition == 2)
            {
                offset += speed;
                transform.position = Vector3.Lerp(transform.position, needPosition, offset);
                transform.rotation = Quaternion.Lerp(transform.rotation, needRotaton, offset);

                WireCub.transform.position = Vector3.Lerp(WireCub.transform.position, CubneedPosition, offset);
                WireCub.transform.rotation = Quaternion.Lerp(WireCub.transform.rotation, CubneedRotaton, offset);

                if (offset >= 1)
                {                    
                    offset = 0;
                    move = false;                   
                    isMiddlePosition = 0;
                   
                       
                }               
            }
           
        }
    }  

}


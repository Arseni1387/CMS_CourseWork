using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Viklichatel : MonoBehaviour, IPointerClickHandler/*,IPointerExitHandler, IPointerEnterHandler*/
{
    bool Flag = false;
    bool Move = false;
    float speed = 0.1f;
    float offset = 0;
    [SerializeField]
    public bool Status = false;

    public bool TaskStatus = false;

    Quaternion startRotation;
    Quaternion needRotaton;
    Quaternion needRotaton2;

    [SerializeField]
    TaskPanelScript Tasks;
    [SerializeField]
    GameObject resultTable;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (TaskStatus)
        {
            TaskStatus = false;
            resultTable.GetComponent<TableScript>().Clear();
            Tasks.Close();
        }
        if (offset == 0) {
       
        Move = true;
        startRotation = transform.rotation;
        needRotaton = startRotation * Quaternion.Euler(-45, 0, 0);
        needRotaton2 = startRotation * Quaternion.Euler(45, 0, 0);
        }
    }
    void FixedUpdate()
    {

        if (Move)
        {
           
            if (!Flag)
            {
                offset += speed;
                transform.rotation = Quaternion.Lerp(startRotation, needRotaton, offset);
               
            }

            if(Flag)
            {
                offset += speed;
                transform.rotation = Quaternion.Lerp(startRotation, needRotaton2, offset);
                
            }
            if (offset >= 1)
            {
                offset = 0;
                Move = false;
                Flag = !Flag;
                Status = !Status;
            }
        }
    }


}

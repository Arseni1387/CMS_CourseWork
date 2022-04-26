using UnityEngine;
using UnityEngine.EventSystems;

public class Knopka_SBROS : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject startButton;
    [SerializeField]
    GameObject resultTable;

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

        resultTable.GetComponent<TableScript>().Clear();
        if (offset == 0 && offset2 == 0)
        {
            Move = true;
            startPosition = transform.position;
            needPosition = Pos1.transform.position;
            needPosition2 = Pos2.transform.position;

            if (startButton.GetComponent<Start_Button_Script>().Status == true)
            {
                startButton.GetComponent<Start_Button_Script>().Status = false;
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knopki_sdvig : MonoBehaviour, IPointerClickHandler
{ 
    [SerializeField]
    GameObject Viklichatel;
    [SerializeField]
    GameObject grafikOxl;
    [SerializeField]
    GameObject grafikNagr;

    public TextMeshPro minutesText;
    public TextMeshPro secondsText;

   
    int minutes;
    int seconds;
  
    public bool Status = false;
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

            if (grafikNagr.GetComponent<Nagr_Grafik_Button>().Status)
            {
                minutes = int.Parse(minutesText.text);
                seconds = int.Parse(secondsText.text);

                if (this.gameObject.name == "Knopka_VPRAVO10")
                {
                    if ((minutes == 5&& seconds>=0)||(minutes == 4 && seconds >= 52))
                    {
                        seconds = 2;
                        minutes = 5;
                    }
                    else
                    {
                        seconds += 10;
                        if (seconds / 60 == 1)
                        {
                            minutes++;
                            seconds %= 60;
                        }
                    } 
                    minutesText.text = string.Format("{0:d2}", minutes);
                    secondsText.text = string.Format("{0:d2}", seconds);
                }


                else if (this.gameObject.name == "Knopka_VPRAVO_1")
                {
                    if(minutes==5 && seconds==2)
                    { }
                    else
                    {
                        seconds++;
                        if (seconds / 60 == 1)
                        {
                            minutes++;
                            seconds %= 60;
                        }
                    }
                 
                    minutesText.text = string.Format("{0:d2}", minutes);
                    secondsText.text = string.Format("{0:d2}", seconds);

                }


                else if (this.gameObject.name == "Knopka_VLEVO10")
                {
                    if (minutes == 0 && seconds <=10)
                    {
                        seconds = 0;
                        minutes = 0;
                    }
                    else
                    {
                        if (seconds / 10 == 0)
                        {
                            minutes--;
                            seconds += 60;
                        }
                        seconds -= 10;
                    }
                    minutesText.text = string.Format("{0:d2}", minutes);
                    secondsText.text = string.Format("{0:d2}", seconds);
                }


                else if (this.gameObject.name == "Knopka_VLEVO1")
                {
                    if (minutes == 0& seconds == 0)
                    {
                        seconds = 0;
                        minutes = 0;
                    }
                    else
                    {
                        if (seconds / 1 == 0)
                        {
                            minutes--;
                            seconds += 60;
                        }
                        seconds--;
                        minutesText.text = string.Format("{0:d2}", minutes);
                        secondsText.text = string.Format("{0:d2}", seconds);
                    }
                  

                }

            }
            else if (grafikOxl.GetComponent<Oxl_Grafik_Button>().Status)
            {
                minutes = int.Parse(minutesText.text);
                seconds = int.Parse(secondsText.text);

                if (this.gameObject.name == "Knopka_VPRAVO10")
                {
                    if ((minutes == 3 && seconds >= 5))
                    {
                        minutes = 3;
                        seconds = 15;
 
                    }

                    else
                    {
                        seconds += 10;

                        if (seconds / 60 == 1)
                        {
                            minutes++;
                            seconds %= 60;
                        }
                    }
                    minutesText.text = string.Format("{0:d2}", minutes);
                    secondsText.text = string.Format("{0:d2}", seconds);
                }


                else if (this.gameObject.name == "Knopka_VPRAVO_1")
                {
                    if (minutes == 3 && seconds == 15)
                    { }
                    else
                    {
                        seconds++;
                        if (seconds / 60 == 1)
                        {
                            minutes++;
                            seconds %= 60;
                        }
                    }

                    minutesText.text = string.Format("{0:d2}", minutes);
                    secondsText.text = string.Format("{0:d2}", seconds);

                }


                else if (this.gameObject.name == "Knopka_VLEVO10")
                {
                    if (minutes == 0 && seconds <= 10)
                    {
                        seconds = 0;
                        minutes = 0;
                    }
                    else
                    {
                        if (seconds / 10 == 0)
                        {
                            minutes--;
                            seconds += 60;
                        }
                        seconds -= 10;
                    }
                    minutesText.text = string.Format("{0:d2}", minutes);
                    secondsText.text = string.Format("{0:d2}", seconds);
                }


                else if (this.gameObject.name == "Knopka_VLEVO1")
                {
                    if (minutes == 0 & seconds == 0)
                    {
                        seconds = 0;
                        minutes = 0;
                    }
                    else
                    {
                        if (seconds / 1 == 0)
                        {
                            minutes--;
                            seconds += 60;
                        }
                        seconds--;
                        minutesText.text = string.Format("{0:d2}", minutes);
                        secondsText.text = string.Format("{0:d2}", seconds);
                    }


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

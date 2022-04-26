using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class THt_TArUpdate : MonoBehaviour
{
    [SerializeField]
    GameObject grafikOxl;
    [SerializeField]
    GameObject grafikNagr;


    float START;
    float nowValue;
    public TextMeshPro minutesText;
    public TextMeshPro secondsText;
    int minutes;
    int seconds;

    void FixedUpdate()
    {
        minutes = int.Parse(minutesText.text);
        seconds = int.Parse(secondsText.text);

        if (grafikNagr.GetComponent<Nagr_Grafik_Button>().Status)
        {
            if (name == "perTHt =")
            {
                START = 21.6f;
                nowValue = START + 0.174504f * (minutes * 60 + seconds);
            }
            else if (name == "perTAr =")
            {
                START = 20.7f;
                nowValue = START + 0.009603f * (minutes * 60 + seconds);
               
            }
            else if (name == "perTU =")
            {
                START = 21.5f;
                nowValue = START;
                this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
            }
            this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
        }
        else if (grafikOxl.GetComponent<Oxl_Grafik_Button>().Status)
        {
            if (name == "perTHt =")
            {

                if ((minutes == 1 && seconds <= 30) || (minutes == 0))
                {
                    START = 74.3f;
                    nowValue = START - 0.2844444f * (minutes * 60 + seconds);
                    this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                }
                else
                {
                    if ((minutes == 1 && seconds <= 57))
                    {
                        nowValue = 48.7f - 0.1148148f * ((minutes * 60 + seconds) - 90);
                        this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                    }
                    else
                    {
                        if ((minutes == 2 && seconds <= 30) || (minutes == 1))
                        {
                            nowValue = 45.6f - 0.060606f * ((minutes * 60 + seconds) - 117);
                            this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                        }
                        else
                        {
                            if ((minutes == 3 && seconds == 00) || (minutes == 2))
                            {
                                nowValue = 43.6f - 0.0333333f * ((minutes * 60 + seconds) - 150);
                                this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                            }
                            else
                            {
                                nowValue = 42.6f - 0.02f * ((minutes * 60 + seconds) - 180);
                                this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                            }
                        }

                    }
                }




            }
            else if (name == "perTAr =")
            {
                START = 23.6f;
                nowValue = START + 0.009603f * (minutes * 60 + seconds);
                this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
            }
            else if (name == "perTU =")
            {
                if ((minutes == 1 && seconds <= 30) || (minutes == 0))
                {
                    START = 21.5f;
                    nowValue = START + 0.1733333f * (minutes * 60 + seconds);
                    this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                }
                else
                {
                    if ((minutes == 1 && seconds <= 57))
                    {
                        nowValue = 37.1f + 0.1f * ((minutes * 60 + seconds) - 90);
                        this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                    }
                    else
                    {
                        if ((minutes == 2 && seconds <= 30) || (minutes == 1))
                        {
                            nowValue = 39.8f + 0.051515f * ((minutes * 60 + seconds) - 117);
                            this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                        }
                        else
                        {
                            if ((minutes == 3 && seconds == 00) || (minutes == 2))
                            {
                                nowValue = 41.5f + 0.0166666f * ((minutes * 60 + seconds) - 150);
                                this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                            }
                            else
                            {
                                nowValue = 42.0f + 0.0133333f * ((minutes * 60 + seconds) - 180);
                                this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:f1}", nowValue);
                            }
                        }

                    }
                }

            }
        }
    }
}

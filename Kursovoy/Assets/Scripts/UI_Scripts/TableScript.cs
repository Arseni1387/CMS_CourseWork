using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class TableScript : MonoBehaviour
{
    string pattern = @"^\d{1,}(\,?\d{1,})*$";
    public int Counter = 0;
    public bool Flag = false;
    string input;
    [SerializeField]
    TMP_InputField Input;

    [SerializeField]
    TextMeshProUGUI deltaTemperature;
    [SerializeField]
    TextMeshProUGUI[] ArrayTextMeshs;

    [SerializeField]
    GameObject grafikOxl;
    [SerializeField]
    GameObject grafikNagr;


    public void Write()
    {
            if (Regex.IsMatch(Input.text, pattern))
            {
                input = Input.text;
                if (input != "" && Counter < 16)
                {
                    if (!Flag)
                    {
                        if(grafikNagr.GetComponent<Nagr_Grafik_Button>().Status == true)
                        {
                            double delta = double.Parse(input) - 21.6;
                            if (delta >= 0)
                            {
                                deltaTemperature.text = string.Format("{0:f1}", delta);
                                Flag = true;
                            }
                        } 
                    }
                    else
                    {
                        if(grafikOxl.GetComponent<Oxl_Grafik_Button>().Status == true)
                        {
                            ArrayTextMeshs[Counter].text = input;

                            if (Counter < 8)
                            {
                                double Sst = (0.9 * Math.Log((273 + double.Parse(input) )/ (273 + 21.6)));
                                ArrayTextMeshs[Counter + 16].text = string.Format("{0:f3}", Sst);
                            }
                            if (Counter >= 8)
                            {
                                double Sst = double.Parse(ArrayTextMeshs[Counter + 8].text);
                                double Sc = (0.9 * Math.Log((273 + double.Parse(input)) / (273 + 21.4)));
                                double S = Sst + Sc;

                                ArrayTextMeshs[Counter + 16].text = string.Format("{0:f3}", Sc);
                                ArrayTextMeshs[Counter + 24].text = string.Format("{0:f3}", S);
                            }
                            Counter++;
                        }
                       
                    }
                }
            }
    }
    public void Clear()
    {
        Flag = false;
        deltaTemperature.text="";
        foreach (TextMeshProUGUI item in ArrayTextMeshs)
        { item.text = ""; }
        Counter = 0;
   
    }

}

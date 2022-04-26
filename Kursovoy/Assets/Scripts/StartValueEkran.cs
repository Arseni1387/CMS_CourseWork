using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartValueEkran : MonoBehaviour
{
    [SerializeField]
    GameObject Viklichatel;

    void Start()
    {
        this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0}", START);
    }
    int START;
    // Update is called once per frame
    void Update()
    {
        if (Viklichatel.GetComponent<Viklichatel>().Status == false) 
        {
            if (name == "perP =")
            {
                START = 7;

            }
            else if (name == "perT = ")
            {
                START = 55;
            }
            else if (name == "perU1 = ")
            {
                START = 1;

            }
            this.gameObject.GetComponent<TextMeshPro>().text = string.Format("{0}", START);
        } 
    }
}

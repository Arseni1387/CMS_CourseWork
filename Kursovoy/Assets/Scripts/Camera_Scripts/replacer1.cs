using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replacer1 : MonoBehaviour
{
    public GameObject Viklichatel;
    public GameObject Ekran;
    public GameObject Klaviatura;
    public GameObject Gl_Vid;
    public GameObject Stakan;
    public GameObject Krishka;
    public GameObject Upr_Block;

    bool move = false;
    Vector3 startPosition;
    Vector3 needPosition;
    float speed = 0.04f;
    float offset = 0;
    Quaternion startRotation;
    Quaternion needRotaton;




    public void Move0()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = Viklichatel.transform.position;
            needRotaton = Viklichatel.transform.rotation;

        }

    }

    public void Move1()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = Ekran.transform.position;
            needRotaton = Ekran.transform.rotation;

        }

    }

    public void Move2()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = Klaviatura.transform.position;
            needRotaton = Klaviatura.transform.rotation;

        }

    }

    public void Move3()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = Gl_Vid.transform.position;
            needRotaton = Gl_Vid.transform.rotation;

        }

    }

    public void Move4()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = Stakan.transform.position;
            needRotaton = Stakan.transform.rotation;

        }

    }

    public void Move5()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = Krishka.transform.position;
            needRotaton = Krishka.transform.rotation;

        }

    }
    public void Move6()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = Upr_Block.transform.position;
            needRotaton = Upr_Block.transform.rotation;

        }

    }


    void FixedUpdate()
    {

        if (move)
        {
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            transform.rotation = Quaternion.Lerp(startRotation, needRotaton, offset);



            if (offset >= 1)
            {
                move = false;
                offset = 0;


            }


        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckViklichatel : MonoBehaviour
{
    [SerializeField]
    GameObject Start_Button;
    [SerializeField]
    GameObject Viklichatel;
    [SerializeField]
    GameObject Al_Stakan;
    [SerializeField]
    GameObject Krishka;
    [SerializeField]
    GameObject NagrGrafik;
    [SerializeField]
    GameObject OxlGrafik;


    public Texture m_MainTexture;
    public Texture Gr_Nagreva;
    public Texture Gr_Oxl;
    public Texture Pusto;
    public Texture Gr_NagrevaBig;
    public Texture Gr_OxlBig;

    Renderer m_Renderer;
   
    
    void Start()
    {
        //Fetch the Renderer from the GameObject
        m_Renderer = GetComponent<Renderer>();

        //Make sure to enable the Keywords
        //m_Renderer.material.EnableKeyword("_NORMALMAP");
        //m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");

        //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture);

       
      

    }
    void Update()
    {
        if (Viklichatel.GetComponent<Viklichatel>().Status)
        {
            if(Start_Button.GetComponent<Start_Button_Script>().Status)
            {
                if(Start_Button.GetComponent<Start_Button_Script>().Status2 == false)
                {
                    m_Renderer.material.SetTexture("_MainTex", Gr_Nagreva);
                }
                else
                {
                    if(NagrGrafik.GetComponent<Nagr_Grafik_Button>().Status)
                    {
                        m_Renderer.material.SetTexture("_MainTex", Gr_NagrevaBig);
                    }
                    else if (OxlGrafik.GetComponent<Oxl_Grafik_Button>().Status)
                    {
                        m_Renderer.material.SetTexture("_MainTex", Gr_OxlBig);
                    }
                    else
                    {
                        m_Renderer.material.SetTexture("_MainTex", Gr_Oxl);
                    }
                       
                }
            }
          
            else
            {
                m_Renderer.material.SetTexture("_MainTex", Pusto);
            }
          
            var items = GetComponentsInChildren<Renderer>();
           
            foreach (Renderer joint in items)
            {
                if(joint.name!="Ёкран")
                {
                    joint.enabled = true;
                }  
            }
        }
        else
        {
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
            var items = GetComponentsInChildren<Renderer>();
            foreach (Renderer joint in items)
            {
                if (joint.name != "Ёкран")
                {
                    joint.enabled = false;
                }
            }
          
            
        }
    }

}

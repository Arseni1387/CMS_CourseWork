using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanelScript : MonoBehaviour
{  //�������
    [SerializeField]
    GameObject Viklichatel;
    
    public TextMeshPro P;
    public TextMeshPro T;
    public TextMeshPro Obrazec2;

    [SerializeField]
    GameObject Krishka;

    [SerializeField]
    GameObject ciynder;

    [SerializeField]
    TextMeshProUGUI TaskText;
    Image Backgroungimage;

    [SerializeField]
    GameObject StartButton;

    [SerializeField]
    GameObject grafikOxl;
    [SerializeField]
    GameObject grafikNagr;

    [SerializeField]
    GameObject resultTable;

    [SerializeField]
    Button addButton;
    [SerializeField]
    Button tableButton;
    [SerializeField]
    Button clearTableButton;

    
    // Start is called before the first frame update
    void Start()
    {
        Backgroungimage = GetComponent<Image>();
        addButton.GetComponent<Image>().enabled = false;
        tableButton.GetComponent<Image>().enabled = false;
        clearTableButton.GetComponent<Image>().enabled = false;
        Backgroungimage.enabled = false;
        TaskText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���� ��������� �� ��������� � ������������ �� ����������
        if (Viklichatel.GetComponent<Viklichatel>().Status == false && Viklichatel.GetComponent<Viklichatel>().TaskStatus==false)
        {
            TaskText.text = "1 �������: �������� ���������";
        }
        else 
        {
            //���� �������� �������� � ����������� �� ����� ���������
            if(P.text!="8"||T.text!="75")
            {
                TaskText.text = "2 �������: �������� T � P ���������� �����������(T),������ 75, � ��������(P), ������ 8";
            }
            else
            {
                // ���� ������� ������� �� ������
                if (Obrazec2.text!="2")
                {
                    TaskText.text = "3 �������: �� ���������� ���������� �������� '������� 2'";
                }
                else
                {
                    //���� ������ ������� � ������ ����� �� ������
                    if (Krishka.GetComponent<Krishka>().Status == false && StartButton.GetComponent<Start_Button_Script>().Status == false)
                    {
                        TaskText.text = "4 �������: ������� ���������������� ������";
                    }
                    else
                    {
                        //���� ������� �� ������� � ������ ����� �� ������
                        if (ciynder.GetComponent<MoveElement>().Status == false && StartButton.GetComponent<Start_Button_Script>().Status == false)
                        {
                            TaskText.text = "5 �������: ��������� ����������� ������� �� �������";
                        }
                        else
                        {
                            //���� ������ ����� �� ������
                            if (StartButton.GetComponent<Start_Button_Script>().Status == false)
                            {
                                TaskText.text = "6 �������: H������ ������ '�����' ";
                            }
                            else
                            {
                                //���� ������� ������� � ������ ����� ������
                                if (ciynder.GetComponent<MoveElement>().Status == true && StartButton.GetComponent<Start_Button_Script>().Status == true)
                                {
                                    TaskText.text = "7 �������: �������� ������� � ������ ";
                                }
                                else
                                {
                                    //���� ������ ������� � ������ ����� ������
                                    if (Krishka.GetComponent<Krishka>().Status == true && StartButton.GetComponent<Start_Button_Script>().Status == true)
                                    {
                                        TaskText.text = "8 �������: �������� ���������������� ������";
                                    }
                                    else
                                    {
                                        //���� ������ ������ ������� � ������ ���������� �� ������, ��� ������ ������ ������� �� ������, ������ ������ ���������� ������ � delta ����������� �� ��������� (� �������)
                                        if ((grafikNagr.GetComponent<Nagr_Grafik_Button>().Status == false && grafikOxl.GetComponent<Oxl_Grafik_Button>().Status == false)|| (grafikNagr.GetComponent<Nagr_Grafik_Button>().Status == false && grafikOxl.GetComponent<Oxl_Grafik_Button>().Status == true && resultTable.GetComponent<TableScript>().Flag == false))
                                        {
                                            TaskText.text = "9 �������: �������� ������ �������, ����� ������ '������ �������'";
                                        }
                                        else
                                        {
                                            //���� delta ����������� �� ��������� (� �������)
                                            if (resultTable.GetComponent<TableScript>().Flag == false)
                                            {
                                                TaskText.text = "10 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 3:30";
                                            }
                                            else
                                            {
                                                //���� ������ ������ ������ ������� � �� ������ ������ ������ ����������
                                                if (grafikNagr.GetComponent<Nagr_Grafik_Button>().Status ==true && grafikOxl.GetComponent<Oxl_Grafik_Button>().Status == false)
                                                {
                                                    TaskText.text = "11 �������: �������� ������ ����������, ����� ������ '������ ����������'";
                                                }
                                                else
                                                {
                                                    //���� ������ �������� ����������� ������� �� ���������� � � �
                                                    if (resultTable.GetComponent<TableScript>().Counter == 0)
                                                    {
                                                       
                                                        TaskText.text = "12 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 0:00 (���������� �������� '1' � '10')";
                                                    }
                                                    else
                                                    {
                                                        if (resultTable.GetComponent<TableScript>().Counter == 1)
                                                        {
                                                            TaskText.text = "13 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 0:30 (���������� �������� '1' � '10')";
                                                        }
                                                        else
                                                        {
                                                            if (resultTable.GetComponent<TableScript>().Counter == 2)
                                                            {
                                                                TaskText.text = "14 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 1:00 (���������� �������� '1' � '10')";
                                                            }
                                                            else
                                                            {
                                                                if (resultTable.GetComponent<TableScript>().Counter == 3)
                                                                {
                                                                    TaskText.text = "15 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 1:30 (���������� �������� '1' � '10')";
                                                                }
                                                                else
                                                                {
                                                                    if (resultTable.GetComponent<TableScript>().Counter == 4)
                                                                    {
                                                                        TaskText.text = "16 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 2:00 (���������� �������� '1' � '10')";
                                                                    }
                                                                    else
                                                                    {
                                                                        if (resultTable.GetComponent<TableScript>().Counter == 5)
                                                                        {
                                                                            TaskText.text = "17 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 2:30 (���������� �������� '1' � '10')";
                                                                        }
                                                                        else
                                                                        {
                                                                            if (resultTable.GetComponent<TableScript>().Counter == 6)
                                                                            {
                                                                                TaskText.text = "18 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 3:00 (���������� �������� '1' � '10')";
                                                                            }
                                                                            else
                                                                            {
                                                                                if (resultTable.GetComponent<TableScript>().Counter == 7)
                                                                                {
                                                                                    TaskText.text = "19 �������: ������� � ������� �������� ����������� �������(THt) ��� ������� ������ 3:15 (���������� �������� '1' � '10')";
                                                                                }
                                                                                else
                                                                                {
                                                                                    //���� ������ �������� ����������� �������� �� ���������� � � �
                                                                                    if (resultTable.GetComponent<TableScript>().Counter == 8)
                                                                                    {
                                                                                        TaskText.text = "20 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 0:00 (���������� �������� '1' � '10')";
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (resultTable.GetComponent<TableScript>().Counter == 9)
                                                                                        {
                                                                                            TaskText.text = "21 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 0:30 (���������� �������� '1' � '10')";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (resultTable.GetComponent<TableScript>().Counter == 10)
                                                                                            {
                                                                                                TaskText.text = "22 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 1:00 (���������� �������� '1' � '10')";
                                                                                            }
                                                                                            else
                                                                                            {

                                                                                                if (resultTable.GetComponent<TableScript>().Counter == 11)
                                                                                                {
                                                                                                    TaskText.text = "23 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 1:30 (���������� �������� '1' � '10')";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (resultTable.GetComponent<TableScript>().Counter == 12)
                                                                                                    {
                                                                                                        TaskText.text = "24 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 2:00 (���������� �������� '1' � '10')";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (resultTable.GetComponent<TableScript>().Counter == 13)
                                                                                                        {
                                                                                                            TaskText.text = "25 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 2:30 (���������� �������� '1' � '10')";
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (resultTable.GetComponent<TableScript>().Counter == 14)
                                                                                                            {
                                                                                                                TaskText.text = "26 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 3:00 (���������� �������� '1' � '10')";
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                //���� ��������� ��������� �������
                                                                                                                if (resultTable.GetComponent<TableScript>().Counter == 15)
                                                                                                                {
                                                                                                                    TaskText.text = "27 �������: ������� � ������� �������� ����������� ��������(TU) ��� ������� ������ 3:15 (���������� �������� '1' � '10')";
                                                                                                                    Viklichatel.GetComponent<Viklichatel>().TaskStatus = true; //������������� �� ��� ������������ ������ ����������
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    //���� ������������ ������ ����������
                                                                                                                    if (Viklichatel.GetComponent<Viklichatel>().TaskStatus)
                                                                                                                    {
                                                                                                                        TaskText.text = "28 �������: ���������� ���������� � ������� � ��������� ���������";
                                                                                                                    }
                                                                                                                }
                                                                                                            }                                                    
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    }
            }
            
        }
        
    }
    public void Open(string Text)
    {
        Backgroungimage.enabled = true;
        TaskText.enabled = true;
        TaskText.text = "";
        TaskText.text = Text;
        addButton.GetComponent<Image>().enabled = true;
        tableButton.GetComponent<Image>().enabled = true;
        clearTableButton.GetComponent<Image>().enabled = true;
    }
    public void Show()
    {
        Backgroungimage.enabled = true;
        TaskText.enabled = true;
        addButton.GetComponent<Image>().enabled = true;
        tableButton.GetComponent<Image>().enabled = true;
        clearTableButton.GetComponent<Image>().enabled = true;
    }
    public void Close()
    {
        Backgroungimage.enabled = false;
        TaskText.enabled = false;
        addButton.GetComponent<Image>().enabled = false;
        tableButton.GetComponent<Image>().enabled = false;
        clearTableButton.GetComponent<Image>().enabled = false;
    }
}

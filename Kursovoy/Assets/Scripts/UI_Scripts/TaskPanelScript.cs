using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanelScript : MonoBehaviour
{  //Объекты
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
        //Если установка не включенна и лабораторная не выполненна
        if (Viklichatel.GetComponent<Viklichatel>().Status == false && Viklichatel.GetComponent<Viklichatel>().TaskStatus==false)
        {
            TaskText.text = "1 задание: Включите установку";
        }
        else 
        {
            //Если значения давления и температуры не равны указанным
            if(P.text!="8"||T.text!="75")
            {
                TaskText.text = "2 задание: Кнопками T и P установите температуру(T),равную 75, и мощность(P), равную 8";
            }
            else
            {
                // Если образец выбранн не второй
                if (Obrazec2.text!="2")
                {
                    TaskText.text = "3 задание: на клавиатуре управления выберите 'образец 2'";
                }
                else
                {
                    //Если крышка закрыта и кнопка старт не нажата
                    if (Krishka.GetComponent<Krishka>().Status == false && StartButton.GetComponent<Start_Button_Script>().Status == false)
                    {
                        TaskText.text = "4 задание: Снимите теплоизолирующую крышку";
                    }
                    else
                    {
                        //Если цилиндр не достали и кнопка старт не нажата
                        if (ciynder.GetComponent<MoveElement>().Status == false && StartButton.GetComponent<Start_Button_Script>().Status == false)
                        {
                            TaskText.text = "5 задание: Достаньте алюминиевый цилиндр из стакана";
                        }
                        else
                        {
                            //Если кнопка старт не нажата
                            if (StartButton.GetComponent<Start_Button_Script>().Status == false)
                            {
                                TaskText.text = "6 задание: Hажмите кнопку 'Старт' ";
                            }
                            else
                            {
                                //Если цилиндр достали и кнопка старт нажата
                                if (ciynder.GetComponent<MoveElement>().Status == true && StartButton.GetComponent<Start_Button_Script>().Status == true)
                                {
                                    TaskText.text = "7 задание: вставьте цилиндр в стакан ";
                                }
                                else
                                {
                                    //Если крышка открыта и кнопка старт нажата
                                    if (Krishka.GetComponent<Krishka>().Status == true && StartButton.GetComponent<Start_Button_Script>().Status == true)
                                    {
                                        TaskText.text = "8 задание: закройте теплоизолирующую крышку";
                                    }
                                    else
                                    {
                                        //Если кнопки график нагрева и график охлаждения не нажаты, или кнопка график нагрева не нажата, кнопка график охлаждения нажата и delta температура не заполнена (в таблице)
                                        if ((grafikNagr.GetComponent<Nagr_Grafik_Button>().Status == false && grafikOxl.GetComponent<Oxl_Grafik_Button>().Status == false)|| (grafikNagr.GetComponent<Nagr_Grafik_Button>().Status == false && grafikOxl.GetComponent<Oxl_Grafik_Button>().Status == true && resultTable.GetComponent<TableScript>().Flag == false))
                                        {
                                            TaskText.text = "9 задание: Выведите график нагрева, нажав кнопку 'График нагрева'";
                                        }
                                        else
                                        {
                                            //Если delta температура не заполнена (в таблице)
                                            if (resultTable.GetComponent<TableScript>().Flag == false)
                                            {
                                                TaskText.text = "10 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 3:30";
                                            }
                                            else
                                            {
                                                //Если нажата кнопка график нагрева и не нажата кнопка график охлаждения
                                                if (grafikNagr.GetComponent<Nagr_Grafik_Button>().Status ==true && grafikOxl.GetComponent<Oxl_Grafik_Button>().Status == false)
                                                {
                                                    TaskText.text = "11 задание: Выведите график охлаждения, нажав кнопку 'График охлаждения'";
                                                }
                                                else
                                                {
                                                    //Если первое значение температуры стакана не заполненно и т д
                                                    if (resultTable.GetComponent<TableScript>().Counter == 0)
                                                    {
                                                       
                                                        TaskText.text = "12 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 0:00 (передвигая кнопками '1' и '10')";
                                                    }
                                                    else
                                                    {
                                                        if (resultTable.GetComponent<TableScript>().Counter == 1)
                                                        {
                                                            TaskText.text = "13 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 0:30 (передвигая кнопками '1' и '10')";
                                                        }
                                                        else
                                                        {
                                                            if (resultTable.GetComponent<TableScript>().Counter == 2)
                                                            {
                                                                TaskText.text = "14 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 1:00 (передвигая кнопками '1' и '10')";
                                                            }
                                                            else
                                                            {
                                                                if (resultTable.GetComponent<TableScript>().Counter == 3)
                                                                {
                                                                    TaskText.text = "15 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 1:30 (передвигая кнопками '1' и '10')";
                                                                }
                                                                else
                                                                {
                                                                    if (resultTable.GetComponent<TableScript>().Counter == 4)
                                                                    {
                                                                        TaskText.text = "16 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 2:00 (передвигая кнопками '1' и '10')";
                                                                    }
                                                                    else
                                                                    {
                                                                        if (resultTable.GetComponent<TableScript>().Counter == 5)
                                                                        {
                                                                            TaskText.text = "17 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 2:30 (передвигая кнопками '1' и '10')";
                                                                        }
                                                                        else
                                                                        {
                                                                            if (resultTable.GetComponent<TableScript>().Counter == 6)
                                                                            {
                                                                                TaskText.text = "18 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 3:00 (передвигая кнопками '1' и '10')";
                                                                            }
                                                                            else
                                                                            {
                                                                                if (resultTable.GetComponent<TableScript>().Counter == 7)
                                                                                {
                                                                                    TaskText.text = "19 задание: Введите в таблицу значение температуры стакана(THt) при времени равном 3:15 (передвигая кнопками '1' и '10')";
                                                                                }
                                                                                else
                                                                                {
                                                                                    //Если первое значение температуры цилиндра не заполненно и т д
                                                                                    if (resultTable.GetComponent<TableScript>().Counter == 8)
                                                                                    {
                                                                                        TaskText.text = "20 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 0:00 (передвигая кнопками '1' и '10')";
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (resultTable.GetComponent<TableScript>().Counter == 9)
                                                                                        {
                                                                                            TaskText.text = "21 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 0:30 (передвигая кнопками '1' и '10')";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (resultTable.GetComponent<TableScript>().Counter == 10)
                                                                                            {
                                                                                                TaskText.text = "22 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 1:00 (передвигая кнопками '1' и '10')";
                                                                                            }
                                                                                            else
                                                                                            {

                                                                                                if (resultTable.GetComponent<TableScript>().Counter == 11)
                                                                                                {
                                                                                                    TaskText.text = "23 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 1:30 (передвигая кнопками '1' и '10')";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (resultTable.GetComponent<TableScript>().Counter == 12)
                                                                                                    {
                                                                                                        TaskText.text = "24 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 2:00 (передвигая кнопками '1' и '10')";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (resultTable.GetComponent<TableScript>().Counter == 13)
                                                                                                        {
                                                                                                            TaskText.text = "25 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 2:30 (передвигая кнопками '1' и '10')";
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (resultTable.GetComponent<TableScript>().Counter == 14)
                                                                                                            {
                                                                                                                TaskText.text = "26 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 3:00 (передвигая кнопками '1' и '10')";
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                //Если полностью заполнили таблицу
                                                                                                                if (resultTable.GetComponent<TableScript>().Counter == 15)
                                                                                                                {
                                                                                                                    TaskText.text = "27 задание: Введите в таблицу значение температуры цилиндра(TU) при времени равном 3:15 (передвигая кнопками '1' и '10')";
                                                                                                                    Viklichatel.GetComponent<Viklichatel>().TaskStatus = true; //Устанавливаем то что лабораторная работа выполненна
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    //Если лабораторная работа выполненна
                                                                                                                    if (Viklichatel.GetComponent<Viklichatel>().TaskStatus)
                                                                                                                    {
                                                                                                                        TaskText.text = "28 задание: Посмотрите результаты в таблице и выключите установку";
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

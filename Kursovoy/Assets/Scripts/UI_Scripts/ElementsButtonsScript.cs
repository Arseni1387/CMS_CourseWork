using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementsButtonsScript : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]
    TextPanel table;
    string Message;
    public int Number;
    public Button Button;
    public Sprite NormalSprite;
    public Sprite HilitedSprite;

    void Start()
    {
        switch (Number)
        {
            case 2: { Message = "<b><color=red>Рабочий блок</color></b>, в нем происходят процессы нагревания и теплообмена."; break; }
            case 3: { Message = "<b><color=red>Блок управления</color></b>, на котором расположенны клавиатура, экран, выключатель."; break; }
            case 1: { Message = "<b><color=red>Выключатель</color></b> используется для включения установки."; break; }
            case 4: { Message = "<b><color=red>Крышка</color></b> используется для изолирования тепла."; break; }
            case 5: { Message = "<b><color=red>Экран</color></b> используется для вывода значений силы тока, мощности, напряжения, график зависимости температуры от времени нагревания."; break; }
            case 6: { Message = "<b><color=red>Клавиатура</color></b> используется для установления температуры нагревателя и мощности."; break; }
            case 7: { Message = "<b><color=red>Алюминиевый цилиндр</color></b> используется для нахождения изменения энтропии системы стакан-цилиндр."; break; }
            case 8: { Message = "<b><color=red>Lатунный цилиндр</color></b> используется для нахождения изменения энтропии системы стакан-цилиндр."; break; }
        }
    }
  

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Image>().sprite = HilitedSprite;
        table.Open(Message);       
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Image>().sprite = NormalSprite;
        table.Close();
    }
}

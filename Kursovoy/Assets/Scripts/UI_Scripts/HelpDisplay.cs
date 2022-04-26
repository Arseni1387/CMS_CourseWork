using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HelpDisplay : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    GameObject Background;

    [SerializeField]
    Image button;

    [SerializeField]
    public Sprite buttonNormalState;
    public Sprite buttonHighlightedState;

    public void OnPointerEnter(PointerEventData eventData)//когда подсветили
    {
        button.sprite = buttonHighlightedState;
        Background.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.sprite = buttonNormalState;
        Background.SetActive(false);
    }
}

using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    GameObject BottomInfo;

    void Start()
    {
        BottomInfo.SetActive(false);
    }

    public void Open(string message)
    {
        if (message.Length != 0)
        {
            text.text = message;
        }
        BottomInfo.SetActive(true);
    }

    public void Close()
    {
        BottomInfo.SetActive(false);
    }
}

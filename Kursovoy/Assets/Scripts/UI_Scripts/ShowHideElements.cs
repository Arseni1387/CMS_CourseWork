using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowHideElements : MonoBehaviour, IPointerClickHandler, IPointerExitHandler,IPointerEnterHandler
{
    [SerializeField]
    GameObject Elements;
    public Button Button;
    public Sprite NormalSprite;
    public Sprite HilitedSprite;
    [SerializeField]
    //GameObject TargetObject;
    //[SerializeField]
    //GameObject Cam;
    //bool move = false;
    //float ofset = 0;
    //float Speed = 0.01f;
    int counter = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        if (counter % 2 == 1)
            Elements.SetActive(true);
        else
        {
            Elements.SetActive(false);
            //ofset = 0;
            //move = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Image>().sprite = HilitedSprite;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Image>().sprite = NormalSprite;
    }

  

    // Update is called once per frame
    //void Update()
    //{
    //    if (move)
    //    {
    //        if (ofset <= 1)
    //        {
    //            ofset += Speed;
    //            Cam.transform.position = Vector3.Lerp(Cam.transform.position, TargetObject.transform.position, ofset);
    //            Cam.transform.rotation = Quaternion.Lerp(Cam.transform.rotation, TargetObject.transform.rotation, ofset);
    //        }
    //        else
    //        {
    //            move = false;
    //        }
    //    }
    //}


}

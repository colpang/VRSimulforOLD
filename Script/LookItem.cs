using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookItem : MonoBehaviour,
                        IPointerEnterHandler,   //Pointer Enter 인터페이스
                        IPointerExitHandler,    //Pointer Exit 인터페이스
                        IGvrPointerHoverHandler //Pointer Hover 인터페이스
{
    //public GameObject Cube;
    public void OnLookItemBox(bool isLookAt)
    {
        Debug.Log(isLookAt);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MoveCtrl.isStopped = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MoveCtrl.isStopped = false;
    }

    public void OnGvrPointerHover(PointerEventData eventData)
    {
        Debug.Log("Pointer Hover !!");
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Pond"))
        {
            Debug.Log("Pond");
            //연못이라면
            //Cube.active = true;
        }
    }
}
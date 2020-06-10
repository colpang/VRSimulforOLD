using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonResponder : MonoBehaviour
{
    private EventTrigger _trigger;
    void Start()
    {
        //EventTrigger 컴포넌트 생성
        _trigger = this.gameObject.AddComponent<EventTrigger>();

        // =====PointerEnter 이벤트 정의 =========//
        //이벤트의 종류와 호출할 함수의 정보를 저장할 Entry를 생성
        EventTrigger.Entry entry1 = new EventTrigger.Entry();

        //마우스 커서 또는 레이캐스트가 Hover됐을 때 발생하는 이벤트
        entry1.eventID = EventTriggerType.PointerEnter;

        //이벤트가 발생했을 때 호출할 함수를 정의
        entry1.callback.AddListener(
            delegate
            {
                OnButtonHover(true);
            }
       );

        //EventTrigger에 PointerEnter 이벤트 추가
        _trigger.triggers.Add(entry1);

        //=====PointerExit 이벤트 정의========//
        //이벤트의 종류와 호출할 함수의 정보를 저장할 Entry를 생성
        EventTrigger.Entry entry2 = new EventTrigger.Entry();

        //마우스 커서 또는 레이캐스트가 벗어났을 때 발생하는 이벤트
        entry2.eventID = EventTriggerType.PointerExit;

        //이벤트가 발생했을 때 호출할 함수를 정의
        entry2.callback.AddListener(
             delegate
             {
                 OnButtonHover(false);
             }
        );
        //EventTrigger에 PointerExit 이벤트 추가
        _trigger.triggers.Add(entry2);
    }
    void OnButtonHover(bool isHover)
    {
        Debug.Log("Button is hovered = " + isHover);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    public static bool FishActivated = false;

    [SerializeField]
    private GameObject go_FishBase;

    [SerializeField]
    private float range; //습득 가능한 최대 거리

    private bool pickupActivated = false; //습득 가능할 시 true

    private RaycastHit hitInfo; //충돌체 정보 저장

    // 아이템 레이어에만 반응하도록 레이어 마스크 설정
    [SerializeField]
    private LayerMask layerMask;

    // 필요한 컴포넌트 
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Inventory theInventory;
    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
        TryOpenFish();
    }

    private void TryOpenFish()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            FishActivated = !FishActivated;

            if (FishActivated)
                OpenFish();
            else
                CloseFish();
        }
    }

    private void OpenFish()
    {
        go_FishBase.SetActive(true);
    }

    private void CloseFish()
    {
        go_FishBase.SetActive(false);
    }

    private void TryAction()
    {
        // ==================이거는 컨트롤러 있으면 그걸로 바꿔야됨 =================
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득했습니다.");
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
            InfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 을(를) 획득하기";
    }
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}

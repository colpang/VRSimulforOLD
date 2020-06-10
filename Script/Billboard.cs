using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform camTr;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        //메인카메라의 Transform 컴포넌트를 캐시 처리
        camTr = Camera.main.transform;
        tr = transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //메뉴를 메인카메라를 응시
        tr.LookAt(camTr.position);
    }
}

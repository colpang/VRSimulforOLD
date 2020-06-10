using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Players : MonoBehaviourPun
{
    public bool IsMasterClientLocal => PhotonNetwork.IsMasterClient && photonView.IsMine;

    public float speed = 3f;
    private Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        var input = InputButton.VerticalInput;

        var distance = input * speed * Time.deltaTime;
        var targetPosition = transform.position + Vector3.up * distance;

        playerRigidbody.MovePosition(targetPosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalControl : NetworkBehaviour {
    void Update()
    {
        if (!this.transform.parent.GetComponent<PlayerController>().isLocalPlayer)
        {
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioListener>().enabled = false;
        }

    }

}

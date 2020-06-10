using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class moveFish : MonoBehaviour
{
    public int randomtime;
    public int moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        randomtime = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(3, randomtime, -5) * moveSpeed * Time.deltaTime);
    }
}

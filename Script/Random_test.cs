using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Random_test : MonoBehaviour
{
    public int a;
    public float b;

    void Start()
    {
        a = Random.Range(1, 10);
        b = Random.Range(0.1f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    [SerializeField]
    float t, segundosacontar;
    public bool control;
    void Start()
    {
        t = 0;
        control = false;
    }

    void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) && t<Time.time)
        {
            t = Time.time + segundosacontar;
            //logica
            Debug.Log("Disparo");
        }
    }
}

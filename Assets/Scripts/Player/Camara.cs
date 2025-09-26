using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform Player;
    public GameObject Target;
    public float Sensibilidad;
    public float VelocidadMaxima;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * Sensibilidad;
        float velocidadLimitada = Mathf.Clamp(inputX, -VelocidadMaxima, VelocidadMaxima);
        transform.LookAt(Player);
        Player.Rotate(Vector3.up * velocidadLimitada * Sensibilidad);
    }
}

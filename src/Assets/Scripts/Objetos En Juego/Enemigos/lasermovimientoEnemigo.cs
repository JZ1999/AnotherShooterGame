﻿using UnityEngine;

public class lasermovimientoEnemigo : MonoBehaviour {

    private const int constVelocidad = 10;

    #region Variables
    [SerializeField]
    private float velocidad;
    private float tiempoDeVida = 7f;
    Rigidbody rb;
    Movimiento objetivo;
    Vector3 direccionDeMovimiento;
    #endregion

    #region Metodos de Unity
    void Start()
    {
        float velocidadDeseada = velocidad * Time.deltaTime * constVelocidad;//Multiplicado por constVelocidad para no tener que usar
																			 //valores tan altos en el inspector de velocidad
		rb = GetComponent<Rigidbody>();
        objetivo = GameObject.FindObjectOfType<Movimiento>();
        direccionDeMovimiento = (objetivo.transform.position - transform.position).normalized * velocidadDeseada;
        rb.velocity = new Vector3(direccionDeMovimiento.x, direccionDeMovimiento.y, direccionDeMovimiento.z);
    }

    private void Update()
    {
        if (tiempoDeVida <= 0)
        {
            Destroy(gameObject);
        }
        tiempoDeVida -= Time.deltaTime;
    }
    #endregion
}

using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class Misil : MonoBehaviour {
	private const int constanteVelocidad = 2;
	private float tiempoDeVida = 6f;

	#region Variables
	private Rigidbody rb;
	private Transform objetivoTR;
	[SerializeField]
	private float velocidad;
	[SerializeField]
	private GameObject explosion;
	[SerializeField]
	private AudioSource explosionSND;
	#endregion

	#region Metodos de Unity
	void Start () {
		objetivoTR = GameObject.FindGameObjectWithTag("enemigo").transform;
		rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate () {
		try
		{
			Vector3 posDeseada = objetivoTR.position;
			transform.LookAt(posDeseada);
			rb.AddForce(transform.forward * constanteVelocidad * velocidad);
		}catch (Exception)
		{
			explotar();
		}

		if (tiempoDeVida <= 0)
		{
			explotar();
		}
		tiempoDeVida -= Time.deltaTime;

	}

	private void OnTriggerEnter(Collider other)
	{
		
		if (other.CompareTag("enemigo"))
		{
			explotar();
		}
	}

	private void explotar()
	{
		explosionSND.Play();
		Instantiate(explosion, transform.position, Quaternion.identity);
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		Destroy(gameObject);
	}
	#endregion
}

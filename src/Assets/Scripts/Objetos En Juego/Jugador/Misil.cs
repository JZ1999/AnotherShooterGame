using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class Misil : MonoBehaviour {
	private const int constanteVelocidad = 3;
	[SerializeField]
	private string[] tags;
	private float tiempoDeVida = 5f;

	#region Variables
	private Rigidbody rb;
	private GameObject objetivo;
	[SerializeField]
	private float velocidad;
	[SerializeField]
	private GameObject explosion;
	[SerializeField]
	private AudioSource explosionSND;
	private bool exploto = false;
	#endregion

	#region Metodos de Unity
	void Start ()
	{
		calcEnemigoCercano();

		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		destruirObjeto();
		accionesDeMisil();
		tiempoAcabado();
		tiempoDeVida -= Time.deltaTime;

	}


	private void OnTriggerEnter(Collider other)
	{
		foreach(var tag in tags)
		{
			if (other.CompareTag(tag))
			{
				if (!exploto)
					explotar();
			}
		}
	}

	#endregion

	private void accionesDeMisil()
	{
		try
		{
			movimiento();
		}
		catch (Exception)
		{
			if (!exploto)
				explotar();
		}
	}

	private void tiempoAcabado()
	{
		if (tiempoDeVida <= 0)
		{
			if (!exploto)
				explotar();
		}
	}

	private void movimiento()
	{
		if (!exploto)
		{
			Vector3 posDeseada = objetivo.transform.position;
			transform.LookAt(posDeseada);
			rb.AddForce(transform.forward * constanteVelocidad * velocidad);
		}
	}

	private void destruirObjeto()
	{
		if (!explosionSND.isPlaying && exploto)
			Destroy(gameObject);
	}

	private void explotar()
	{
		exploto = true;
		explosionSND.Play();
		Instantiate(explosion, transform.position, Quaternion.identity);
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
	}

	private void calcEnemigoCercano()
	{
		GameObject[] enemigosObj = GameObject.FindGameObjectsWithTag("enemigo");
		objetivo = enemigosObj[0];
		float dist = Vector3.Distance(gameObject.transform.position, objetivo.transform.position);

		foreach (var obj in enemigosObj)
		{
			if(obj != null)
			{
				if (dist > Vector3.Distance(gameObject.transform.position, obj.transform.position))
				{
					dist = Vector3.Distance(gameObject.transform.position, obj.transform.position);
					objetivo = obj;
				}
			}
		}
	}
}

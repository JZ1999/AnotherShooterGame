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
	#endregion

	#region Metodos de Unity
	void Start ()
	{
		calcEnemigoCercano();

		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		try
		{
			Vector3 posDeseada = objetivo.transform.position;
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
		foreach(var tag in tags)
		{
			if (other.CompareTag(tag))
			{
				explotar();
			}
		}
	}

	#endregion

	private void explotar()
	{
		explosionSND.Play();
		Instantiate(explosion, transform.position, Quaternion.identity);
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
		Destroy(gameObject);
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

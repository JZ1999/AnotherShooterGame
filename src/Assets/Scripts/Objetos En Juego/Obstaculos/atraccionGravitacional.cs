using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class atraccionGravitacional : MonoBehaviour {

	#region Variables
	[SerializeField]
	private Rigidbody rb;

	private const float G = 66.74f;
	public static List<atraccionGravitacional> atraciones;
	#endregion

	#region Metodos de Unity

	private void FixedUpdate()
	{
		foreach(atraccionGravitacional atr in atraciones)
		{
			Debug.Log(atr.tag);
			if(atr != this)
				Atraccion(atr);
		}
	}

	private void OnEnable()
	{
		if (atraciones == null)
			atraciones = new List<atraccionGravitacional>();

		if (CompareTag("gravitacional")){
			atraciones.Add(this);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameObject player = GameObject.FindGameObjectWithTag("player");
			atraciones.Add(player.GetComponent<atraccionGravitacional>());
		}
	}

	private void OnDisable()
	{
		atraciones.Remove(this);	
	}

	void Atraccion(atraccionGravitacional obj)
	{
		Rigidbody objParaAtraer = obj.rb;

		Vector3 direccion = rb.position - objParaAtraer.position;
		float distancia = direccion.magnitude;
		if (distancia == 0f || objParaAtraer.CompareTag("gravitacional"))
			return;

		float fuerzaMagnitud = G * (rb.mass * objParaAtraer.mass) / Mathf.Pow(distancia, 2);
		Vector3 fuerza = direccion.normalized * fuerzaMagnitud;

		objParaAtraer.AddForce(fuerza);
	}

    #endregion
}

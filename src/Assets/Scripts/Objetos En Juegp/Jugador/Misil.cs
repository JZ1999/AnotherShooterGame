using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class Misil : MonoBehaviour {
	private const int constanteVelocidad = 200;

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
		}catch(Exception e) {
			explotar();
		}

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
		Instantiate(explosion, objetivoTR);
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		transform.position = new Vector3(1000, 0, 0);//Se hace esto para que no vuelva a chocar aun siendo invisible
		Destroy(gameObject, 3);//3 segundos para que explosionSND suene todo
	}
	#endregion
}

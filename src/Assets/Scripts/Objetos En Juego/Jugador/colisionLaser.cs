using System;
using UnityEngine;

[DisallowMultipleComponent]
public class colisionLaser : MonoBehaviour {

	#region Variables
	[SerializeField]
	private AudioSource explosion;
    #endregion

    #region Metodos de Unity

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(gameObject.tag);

		if (gameObject.CompareTag("laser"))
			colisionLaserJugador(other);
		else if (gameObject.CompareTag("laser_enemigo"))
			colisionLaserEnemigo(other);

	}

	private void colisionLaserEnemigo(Collider other)
	{
		if (other.CompareTag("objeto_solido") || other.CompareTag("Player"))
		{
			explosion.Play();
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			Destroy(gameObject, 0.5f);//Un tiempo para darle tiempo a que los sonidos suenen
		}
	}

	private void colisionLaserJugador(Collider other)
	{
		if (other.CompareTag("objeto_solido") || other.CompareTag("enemigo"))
		{
			explosion.Play();
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			Destroy(gameObject, 0.5f);//Un tiempo para darle tiempo a que los sonidos suenen
		}
	}
	#endregion
}

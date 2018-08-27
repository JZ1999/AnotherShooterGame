using System;
using UnityEngine;

enum ModosDeCamara
{
	_3D,_2D
}

[DisallowMultipleComponent]
public class CamaraSigueJugador : MonoBehaviour {

	#region Variables
	private Transform naveTR;
	[SerializeField]
	[Range(0f,1f)]
	private float velocidad;
	[SerializeField]
	private Vector3 offset3D;
	[SerializeField]
	private Vector3 offset2D;
	[SerializeField]
	private ModosDeCamara modoCamara;
	#endregion

	#region Metodos de Unity

	void FixedUpdate()
	{
		try
		{
			naveTR = GameObject.FindGameObjectWithTag("Player").transform;
			if (naveTR != null)
				AjustarPosicionRotacion();
		}
		catch(Exception)
		{
			//No existe el naveTR
		}
		
	}
	#endregion

	private void AjustarPosicionRotacion()
	{
		if (modoCamara == ModosDeCamara._3D)
			modo3D();
		else
			modo2D();
	}

	private void modo3D()
	{
		Vector3 posDeseada = naveTR.position + offset3D;
		Vector3 posRefinada = Vector3.Lerp(transform.position, posDeseada, velocidad);
		transform.position = posRefinada;

		transform.LookAt(naveTR);
	}

	private void modo2D()
	{
		Vector3 posDeseada = naveTR.position + offset2D;
		Vector3 posRefinada = Vector3.Lerp(transform.position, posDeseada, velocidad);
		posRefinada.y = 3357f;
		posRefinada.x = 0;
		transform.position = posRefinada;
	}
}

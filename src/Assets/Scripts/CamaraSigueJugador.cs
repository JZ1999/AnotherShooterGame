using UnityEngine;

enum ModosDeCamara
{
	_3D,_2D
}

[DisallowMultipleComponent]
public class CamaraSigueJugador : MonoBehaviour {

	#region Variables
	private Transform nave;
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
	private void Start()
	{
		nave = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate()
	{
		AjustarPosicionRotacion();
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
		Vector3 posDeseada = nave.position + offset3D;
		Vector3 posRefinada = Vector3.Lerp(transform.position, posDeseada, velocidad);
		transform.position = posRefinada;

		transform.LookAt(nave);
	}

	private void modo2D()
	{
		Vector3 posDeseada = nave.position + offset2D;
		Vector3 posRefinada = Vector3.Lerp(transform.position, posDeseada, velocidad);
		posRefinada.y = 3357f;
		posRefinada.x = 0;
		transform.position = posRefinada;
	}
}

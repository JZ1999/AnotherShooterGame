using UnityEngine;

[DisallowMultipleComponent]
public class CamaraSigueJugador : MonoBehaviour {

	#region Variables
	private Transform nave;
	[SerializeField]
	[Range(0f,1f)]
	private float velocidad;
	[SerializeField]
	private Vector3 offset;
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
		Vector3 posDeseada = nave.position + offset;
		Vector3 posRefinada = Vector3.Lerp(transform.position, posDeseada, velocidad);
		transform.position = posRefinada;

		transform.LookAt(nave);
	}
}

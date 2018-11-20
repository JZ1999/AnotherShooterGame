using UnityEngine;

[DisallowMultipleComponent]
public class laserMovimiento : MonoBehaviour {
	private const int constVelocidad = 10;

	#region Variables
	[SerializeField]
	private float velocidad;
	private float tiempoDeVida = 1f;
	#endregion

	#region Metodos de Unity
	void Start () {
		float velocidadDeseada = velocidad * Time.deltaTime * constVelocidad;//Multiplicado por constVelocidad para no tener que usar
																//valores tan altos en el inspector de velocidad
		GetComponent<Rigidbody>().velocity = new Vector3(0,0, velocidadDeseada);
    }

	private void Update()
	{
		despawn();
	}

	private void despawn()
	{
		if (tiempoDeVida <= 0)
		{
			Destroy(gameObject);
		}
		tiempoDeVida -= Time.deltaTime;
	}
	#endregion
}

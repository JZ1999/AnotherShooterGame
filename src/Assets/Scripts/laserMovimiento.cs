using UnityEngine;

[DisallowMultipleComponent]
public class laserMovimiento : MonoBehaviour {
	private const int constVelocidad = 1000;

	#region Variables
	[SerializeField]
	private float velocidad;
	private float tiempoDeVida = 7f;
	#endregion

	#region Metodos de Unity
	void Start () {
		float velocidadDeseada = velocidad * Time.deltaTime * constVelocidad;//Multiplicado por 100 para no tener que usar
																//valores tan altos en el inspector de velocidad
		GetComponent<Rigidbody>().velocity = new Vector3(0,0, velocidadDeseada);
    }

	private void Update()
	{
		if (tiempoDeVida<=0)
		{
			Destroy(gameObject);
		}
		tiempoDeVida -= Time.deltaTime;
	}
	#endregion
}

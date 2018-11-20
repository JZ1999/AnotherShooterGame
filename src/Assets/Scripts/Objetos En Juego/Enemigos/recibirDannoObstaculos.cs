using UnityEngine;

[DisallowMultipleComponent]
public class recibirDannoObstaculos : MonoBehaviour {
	//Trata con el recibir daño pero del enemigo

	#region Variables
	[SerializeField]
	private Obstaculo informacionObstaculo;
	[SerializeField]
	private DatosDeJugador info;
	[SerializeField]
	private GameObject objDestruido;

	private int vida;
	private int danno;
	private GameObject fracturasSpawneadas = null;//Para detectar si ya spawneo
											//el objeto fracturado
    #endregion

    #region Metodos de Unity
    void Start () {
		danno = info.danno;
		vida = informacionObstaculo.escudos;
	}

	private void OnTriggerEnter(Collider other)
	{
		perderVida(other);
		muerte();
	}

	private void muerte()
	{
		if (vida <= 0 && fracturasSpawneadas == null)
		{
			GameObject obj = Instantiate(objDestruido, transform.position, transform.rotation);
			fracturasSpawneadas = obj;
			obj.SetActive(true);

			Destroy(gameObject);
		}
	}

	private void perderVida(Collider other)
	{
		if (other.CompareTag("laser") || other.CompareTag("misil"))
		{
			vida -= danno;
		}
	}
	#endregion
}

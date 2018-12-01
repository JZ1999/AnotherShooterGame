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
	[SerializeField]
	private cofre[] cofres;

	private int vida;
	private int danno;
	private bool cofreSpawneado = false;
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


	#endregion

	private void muerte()
	{
		if (vida <= 0 && fracturasSpawneadas == null)
		{
			if (!cofreSpawneado)
			{
				GameObject obj = Instantiate(objDestruido, transform.position, transform.rotation);
				fracturasSpawneadas = obj;
				obj.SetActive(true);
			}
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

	private void spawnearCofre()
	{

		cofreSpawneado = true;
		for (int i = 0; i < cofres.Length; i++)
		{
			int num = Random.Range(0, 100);
			if (num <= cofres[i].posibilidad)
			{
				Instantiate(cofres[i].objeto, transform.position, Quaternion.Euler(new Vector3(-120, 0, 0)));
				return;
			}

		}
	}
}

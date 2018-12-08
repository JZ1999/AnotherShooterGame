using UnityEngine;

[DisallowMultipleComponent]
public class recibirDannoObstaculos : MonoBehaviour {
	//Trata con el recibir daño pero del enemigo

	#region Variables
	[SerializeField]
	private Obstaculo informacionObstaculo;
	private DatosDeJugador info;
	[SerializeField]
	private GameObject objDestruido;
	[SerializeField]
	private cofre[] cofres;
	[SerializeField]
	private string tagJugador;

	private int vida;
	private int danno;
	private int dannoHabilidad;
	private bool cofreSpawneado = false;
	private GameObject fracturasSpawneadas = null;//Para detectar si ya spawneo
											//el objeto fracturado
    #endregion

    #region Metodos de Unity
    void Start () {
		info = GameObject.FindGameObjectWithTag(tagJugador).GetComponent<guardarDatosJugador>().getInfo();
		danno = info.danno;
		dannoHabilidad = info.dannoHabilidad;
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
		if (other.CompareTag("laser"))
		{
			vida -= danno;
		}else if (other.CompareTag("misil"))
		{
			vida -= dannoHabilidad;
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

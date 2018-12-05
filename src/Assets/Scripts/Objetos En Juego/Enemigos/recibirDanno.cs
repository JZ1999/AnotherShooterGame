using UnityEngine;

[System.Serializable]
public struct cofre
{
	public GameObject objeto;
	[Tooltip("Posibilidad de aparecer de 100")]
	[Range(0,100)]
	public int posibilidad;
}


[DisallowMultipleComponent]
public class recibirDanno : MonoBehaviour {
	//Trata con el recibir daño pero del enemigo

	#region Variables
	[SerializeField]
	private Enemigo informacionEnemigo;
	private DatosDeJugador info;
	[SerializeField]
	private SimpleHealthBar barraDeVida;
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
	#endregion

	#region Metodos de Unity
	void Start () {
		info = GameObject.FindGameObjectWithTag(tagJugador).GetComponent<guardarDatosJugador>().getInfo();
		danno = info.danno;
		dannoHabilidad = info.dannoHabilidad;
		vida = informacionEnemigo.escudos;
		
	}

	private void OnTriggerEnter(Collider other)
	{
		perderVida(other);
		muerte();
	}


	#endregion
	private void muerte()
	{
		if (vida <= 0)
		{
			if (!cofreSpawneado)
			{
				spawnearCofre();
				GameObject obj = Instantiate(objDestruido, transform.position, transform.rotation);
				obj.SetActive(true);
			}
			Destroy(gameObject, 0.2f);
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
					Instantiate(cofres[i].objeto, transform.position, Quaternion.Euler(new Vector3(-120,0,0)));
					return;
				}

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
		barraDeVida.UpdateBar(vida, informacionEnemigo.escudos);
	}
}

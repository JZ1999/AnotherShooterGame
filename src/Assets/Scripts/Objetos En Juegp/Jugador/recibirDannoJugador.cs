using UnityEngine;

[DisallowMultipleComponent]
public class recibirDannoJugador : MonoBehaviour {

	#region Variables
	[SerializeField]
	private DatosDeJugador info;

	private int vida;
	[SerializeField]
	private GameObject[] objetosDanninos;
	private DannoEnemigo dannoInfo;//Guarda la informacion
								   //sobre de cual objeto esta
								   //recibiendo daño
	#endregion


	#region Metodos de Unity
	private void Start () {
		vida = info.vida;
    }

	private void OnTriggerEnter(Collider other)
	{
		asignarDannoInfo(other);
		muerte();
	}

	private void asignarDannoInfo(Collider other)
	{
		foreach (var obj in objetosDanninos)
		{
			if (obj.CompareTag(other.tag))
			{
				dannoInfo = obj.GetComponent<guardarDanno>().getInfo();
				perderVida(other);
			}
		}
	}

	private void muerte()
	{
		if (vida <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void perderVida(Collider other)
	{
		vida -= dannoInfo.danno;
	}
	#endregion
}

using UnityEngine;

[DisallowMultipleComponent]
public class recibirDanno : MonoBehaviour {
	//Trata con el recibir daño pero del enemigo

	#region Variables
	[SerializeField]
	private DatosDeJugador info;

	private int vida = 2;
	private int danno;
    #endregion

    #region Metodos de Unity
    void Start () {
		danno = info.danno;
	}

	private void OnTriggerEnter(Collider other)
	{
		perderVida(other);
		muerte();
	}

	private void muerte()
	{
		if (vida <= 0)
		{
			Destroy(gameObject, 0.2f);
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

using UnityEngine;

[DisallowMultipleComponent]
public class recibirDanno : MonoBehaviour {
	//Trata con el recibir daño pero del enemigo

	#region Variables
	[SerializeField]
	private Enemigo informacionEnemigo;
	[SerializeField]
	private DatosDeJugador info;
	[SerializeField]
	private SimpleHealthBar barraDeVida;
	[SerializeField]
	private GameObject objDestruido;

	private int vida;
	private int danno;
    #endregion

    #region Metodos de Unity
    void Start () {
		danno = info.danno;
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
			GameObject obj = Instantiate(objDestruido, transform.position, transform.rotation);
			obj.SetActive(true);

			Destroy(gameObject, 0.2f);
		}
	}

	private void perderVida(Collider other)
	{
		if (other.CompareTag("laser") || other.CompareTag("misil"))
		{
			vida -= danno;
			barraDeVida.UpdateBar(vida, informacionEnemigo.escudos);
		}
	}
}

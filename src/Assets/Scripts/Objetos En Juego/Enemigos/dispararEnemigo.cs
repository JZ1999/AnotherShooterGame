using UnityEngine;

[DisallowMultipleComponent]
public class dispararEnemigo : MonoBehaviour {

	#region Variables
	[SerializeField]
	private Enemigo info;
	[SerializeField]
	private GameObject bullet;
	[SerializeField]
	private AudioSource laserSND;
	[SerializeField]
	[Range(0.1f, 5f)]
	private float cooldown;
	private float siguiente_disparo;

	#endregion

	#region Metodos de Unity

	private void Start()
	{
		siguiente_disparo = Time.time;
	}

	void Update () {
        TiempodeDisparar();
	}
    #endregion

    void TiempodeDisparar()
	{
		if (Time.time > siguiente_disparo && estaEnRango())
		{
			Quaternion rotacion = Quaternion.FromToRotation(Vector3.up, transform.forward);
			Vector3 posicion = transform.position;
			GameObject proyectil = Instantiate(bullet, posicion, rotacion);
			proyectil.GetComponent<guardarDanno>().setInfo(info);
			laserSND.Play();
			siguiente_disparo = Time.time + cooldown;
		}
	}

	private bool estaEnRango()
	{
		try
		{
			Vector3 posJugador = GameObject.FindGameObjectWithTag("Player").transform.position;
			float distanciaEnemigoJugador = Vector3.Distance(transform.position, posJugador);
			return distanciaEnemigoJugador <= info.getRango();
		}
		catch{

			return false;
		}
	}
}

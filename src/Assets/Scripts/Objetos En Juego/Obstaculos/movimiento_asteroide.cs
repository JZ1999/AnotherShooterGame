using UnityEngine;

[DisallowMultipleComponent]
public class movimiento_asteroide : MonoBehaviour {

	#region Variables
	
	[SerializeField]
	private float velocidad = 0;

	[SerializeField]
	private float escalaMinima;
	[SerializeField]
	private float escalaMaxima;
	private float posZJugador;
	#endregion

	#region Metodos de Unity
	void Start () {
		posZJugador = GameObject.FindGameObjectWithTag("Player").transform.position.z;
		transform.localScale = Vector3.one * Random.Range(escalaMinima, escalaMaxima);
		transform.rotation = Random.rotation;
    }
    
    void FixedUpdate () {
		
		Vector3 jugador = new Vector3(transform.position.x, transform.position.y, posZJugador);
	
		float step = velocidad * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, jugador, step);
	}
	
	#endregion
}

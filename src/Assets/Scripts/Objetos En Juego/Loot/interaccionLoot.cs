using UnityEngine;

[DisallowMultipleComponent]
public class interaccionLoot : MonoBehaviour {

	#region Variables
	private Transform jugadorTR;
	[SerializeField]
	private float rango;
	[SerializeField]
	private float velocidad;
	[SerializeField]
	private string tagJugador;
	private bool enRango = false;

	#endregion

	#region Metodos de Unity
	private void Start()
	{
		jugadorTR = GameObject.FindGameObjectWithTag(tagJugador).transform;
	}

	void Update ()
	{
		irAJugador();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(tagJugador))
		{
			Destroy(gameObject);
		}
	}


	#endregion

	public bool getenRango()
	{
		return this.enRango;
	}
	
	private void irAJugador()
	{
		float dist = Vector3.Distance(transform.position, jugadorTR.position);

		if (dist <= rango)
		{
			enRango = true;
			float paso = velocidad * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, jugadorTR.position, paso);
		}
		else
			enRango = false;
	}

}

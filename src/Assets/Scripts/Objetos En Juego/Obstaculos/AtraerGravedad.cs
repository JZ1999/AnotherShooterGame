using UnityEngine;

[DisallowMultipleComponent]
public class AtraerGravedad : MonoBehaviour {

	#region Variables
	[HideInInspector]
	private bool jalar = false;//Este variable publico lo lee otros objetos (i.e. El jugador )

	public bool Jalar
	{
		get{return jalar;}
		set{jalar = value;}
	}

	#endregion

	#region Metodos de Unity

	private void Awake()
	{
		jalar = false;	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			jalar = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			jalar = false;
		}
	}
	#endregion
}

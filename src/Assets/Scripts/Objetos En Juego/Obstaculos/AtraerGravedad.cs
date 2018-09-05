using UnityEngine;

[DisallowMultipleComponent]
public class AtraerGravedad : MonoBehaviour {

	#region Variables
	[HideInInspector]
	public bool jalar = false;
	#endregion

	#region Metodos de Unity


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

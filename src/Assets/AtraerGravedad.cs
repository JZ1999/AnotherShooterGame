using UnityEngine;

[DisallowMultipleComponent]
public class AtraerGravedad : MonoBehaviour {

	#region Variables
	public bool jalar = false;
	#endregion

	#region Metodos de Unity


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("enter");
			jalar = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("exit");
			jalar = false;
		}
	}
	#endregion
}

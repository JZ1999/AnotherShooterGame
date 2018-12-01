using UnityEngine;

[DisallowMultipleComponent]
public class sonidosEspeciales : MonoBehaviour {

	#region Variables
	[SerializeField]
	private AudioSource cofreSND;
    #endregion

    #region Metodos de Unity
    

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("cofre"))
		{
			cofreSND.Play();
		}
	}
	#endregion
}

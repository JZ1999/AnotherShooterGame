using UnityEngine;

[DisallowMultipleComponent]
public class colisionLaser : MonoBehaviour {

    #region Variables

    #endregion

    #region Metodos de Unity

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("objeto_solido"))
		{
			Destroy(gameObject, 0.5f);//Un tiempo para darle tiempo a que los sonidos suenen
		}
	}
	#endregion
}

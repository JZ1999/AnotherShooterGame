using UnityEngine;

[DisallowMultipleComponent]
public class duracionExplosion : MonoBehaviour {

	#region Variables
	private float tiempoDeVida = 1f;
	[SerializeField]
	private AudioSource explosionSND;
	#endregion

	#region Metodos de Unity

	void Update () {
		if (tiempoDeVida <= 0)
		{
			GetComponent<MeshRenderer>().enabled = false;
			Destroy(gameObject,1.7f);
		}
		tiempoDeVida -= Time.deltaTime;
	}
    #endregion
}

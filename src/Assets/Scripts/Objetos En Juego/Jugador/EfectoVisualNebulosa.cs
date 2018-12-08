using UnityEngine;

[DisallowMultipleComponent]
public class EfectoVisualNebulosa : MonoBehaviour {

	#region Variables
	private float fogDensity;
	private Color fogColor;

	[SerializeField]
	private float fogDensity_Deseado;
	[SerializeField]
	private Color fogColor_Deseado;
	[SerializeField]
	private GameObject camara1OBJ;
	[SerializeField]
	private GameObject camara2OBJ;
	public static bool activado;
	#endregion

	#region Metodos de Unity
	private void Start()
	{
		fogColor = RenderSettings.fogColor;
		fogDensity = RenderSettings.fogDensity;
		revertirEfecto();
	}


	private void Update()
	{
		/*if (camara1OBJ.GetComponent<Camera>().isActiveAndEnabled)
		{
			revertirEfecto();
		}*/
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("nebulosa"))
		{
			/*RenderSettings.fogDensity = fogDensity_Deseado;
			RenderSettings.fogColor = fogColor_Deseado;*/
			activado = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("nebulosa"))
		{
			revertirEfecto();
		}
	}


	#endregion

	private void revertirEfecto()
	{
		RenderSettings.fogDensity = fogDensity;
		RenderSettings.fogColor = fogColor;
		activado = false;
	}
}

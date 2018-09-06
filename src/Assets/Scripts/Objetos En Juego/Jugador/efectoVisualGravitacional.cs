using UnityEngine;

[DisallowMultipleComponent]
public class efectoVisualGravitacional : MonoBehaviour {

	#region Variables
	private float fogDensity;
	private Color fogColor;

	[SerializeField]
	private float fogDensity_Deseado;
	[SerializeField]
	private Color fogColor_Deseado;
	
	public static bool activado;
	#endregion

	#region Metodos de Unity

	private void Start()
	{
		fogColor = RenderSettings.fogColor;
		fogDensity = RenderSettings.fogDensity;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("gravitacional"))
		{
			RenderSettings.fogDensity = fogDensity_Deseado;
			RenderSettings.fogColor = fogColor_Deseado;
			activado = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("gravitacional"))
		{
			RenderSettings.fogDensity = fogDensity;
			RenderSettings.fogColor = fogColor;
			activado = false;
		}
	}
	#endregion
}

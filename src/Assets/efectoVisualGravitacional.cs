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
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("gravitacional"))
		{
			RenderSettings.fogDensity = fogDensity;
			RenderSettings.fogColor = fogColor;
		}
	}
	#endregion
}

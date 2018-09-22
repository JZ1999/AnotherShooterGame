using UnityEngine;
using System;

[DisallowMultipleComponent]
public class efectoVisualGravitacional : MonoBehaviour {


	#region Variables
	[SerializeField]
	[Range(0.1f,20f)]
	[Tooltip("Esto decide el multiplicador del color rojo entre mas se acerca el jugador")]
	private int multiplicador = 10;
	private float fogDensity;
	private Color fogColor;
	[SerializeField]
	private float fogDensity_Deseado;
	[SerializeField]
	private Color fogColor_Deseado;
	
	[HideInInspector]
	public static bool activado;
	[HideInInspector]
	public static float indice;


	#endregion

	#region Metodos de Unity

	private void Start()
	{
		fogColor = RenderSettings.fogColor;
		fogDensity = RenderSettings.fogDensity;
	}

	private void Update()
	{
		calcularIndice();
	}

	private void calcularIndice()
	{
		if (activado)
		{
			Vector3 posicionCampoGravitacional = GameObject.FindGameObjectWithTag("gravitacional").transform.position;
			const float offset = 69f;
			float distancia = Vector3.Distance(transform.position, posicionCampoGravitacional) - offset;
			indice = multiplicador * (1 - (1 - (1 / distancia)));
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("gravitacional"))
		{
			activado = true;
			RenderSettings.fogDensity = fogDensity_Deseado;

			//filtrado para que tenga la cantidad de rojo correcta
			Color color_filtrado = new Color(indice, fogColor_Deseado.g, fogColor_Deseado.b, fogColor_Deseado.a);
			RenderSettings.fogColor = color_filtrado;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("gravitacional"))
		{
			activado = false;
			RenderSettings.fogDensity = fogDensity;
			RenderSettings.fogColor = fogColor;
		}
	}
	#endregion
}

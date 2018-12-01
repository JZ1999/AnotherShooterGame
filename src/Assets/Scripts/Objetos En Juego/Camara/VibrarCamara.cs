using System.Collections;
using UnityEngine;

[System.Serializable]
public class Datos_de_vibracion
{
	public float duracion, fuerza;
}

[DisallowMultipleComponent]
public class VibrarCamara : MonoBehaviour {

	#region Variables
	[SerializeField]
	private Datos_de_vibracion datos;
	private bool activado = true;
	#endregion

	#region Metodos de Unity
	private void FixedUpdate()
	{
		if (efectoVisualGravitacional.activado && activado) { 
			StartCoroutine(Vibrar(datos.duracion, datos.fuerza));
			activado = false;
		}

		if (!efectoVisualGravitacional.activado)
			activado = true;

	}
	#endregion

	public IEnumerator Vibrar(float duracion, float fuerza)
	{
		//Vector3 posOriginal = transform.position;
		Vector3 posOriginal = GameObject.FindGameObjectWithTag("Player").transform.position;
		const float constanteY = 2.76f;//Los constantes existen para un offset a la camara
										//mientras vibra.
		const float constanteZ = 7.88f;

		while(efectoVisualGravitacional.activado)
		{
			float x, y;
			calcular_X_Y(fuerza, posOriginal, constanteY, out x, out y);

			transform.position = new Vector3(x, y, posOriginal.z - constanteZ);

			posOriginal = GameObject.FindGameObjectWithTag("Player").transform.position;
			yield return null;
		}

		transform.position = posOriginal;
	}

	private static void calcular_X_Y(float fuerza, Vector3 posOriginal, float constanteY, out float x, out float y)
	{
		x = Random.Range(-1f, 1f) * fuerza + posOriginal.x;
		y = Random.Range(-1f, 1f) * fuerza + posOriginal.y + constanteY;
	}
}

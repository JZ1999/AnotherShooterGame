using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class activarEfectoNebulosa : MonoBehaviour {

	#region Variables
	private Image img;
	private float farClipPlane;
	private Camera camara;
	#endregion

	#region Metodos de Unity
	void Start()
	{
		camara = GameObject.FindGameObjectsWithTag("camaras")[0].GetComponent<Camera>();
		farClipPlane = camara.farClipPlane;
		img = GetComponent<Image>();
	}

	void Update()
	{
		if (EfectoVisualNebulosa.activado)
		{
			aplicarEfecto();
		}
		else
		{
			camara.farClipPlane = farClipPlane;
			img.enabled = false;
		}
	}


	#endregion

	private void aplicarEfecto()
	{
		img.enabled = true;

		
		camara.farClipPlane = 25f;
	}
}

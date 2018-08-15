using UnityEngine;

[DisallowMultipleComponent]
public class cambiarCamara : MonoBehaviour {

	#region Variables
	private GameObject[] camaras;//1er camara es 3D, 2da es 2D
	[SerializeField]
	private KeyCode tecla;
	#endregion

	#region Metodos de Unity
	private void Start()
	{
		camaras = GameObject.FindGameObjectsWithTag("camaras");
	}

	void Update () {
		bool presionaTecla = Input.GetKeyDown(tecla);
		if (presionaTecla)
		{
			toggleCamara();
		}
    }
	#endregion

	void toggleCamara()
	{
		foreach (var cam in camaras)
		{
			cam.GetComponent<Camera>().enabled = !cam.GetComponent<Camera>().enabled;
		}
	}
}

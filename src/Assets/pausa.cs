using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class pausa : MonoBehaviour {

	#region Variables
	[SerializeField]
	private KeyCode tecla;
	[SerializeField]
	private GameObject menu;
	public static bool juegoEnPausa = false;
	#endregion

	#region Metodos de Unity

	private void Update()
	{
		if (Input.GetKeyDown(tecla))
		{
			if (toggleMenu())
				pausar();
			else
				continuar();
		}
	}


	#endregion

	private bool toggleMenu()
	{
		menu.active = !menu.active;
		Debug.Log(menu.active);
		return menu.active;
	}


	public void continuar()
	{
		menu.active = false;
		Time.timeScale = 1f;
		juegoEnPausa = false;
	}

	public void pausar()
	{
		menu.active = true;
		Time.timeScale = 0f;
		juegoEnPausa = true;
	}

	public void salir()
	{
		menu.active = false;
		Time.timeScale = 1f;
		juegoEnPausa = false;
		SceneManager.LoadScene(0);
	}
}

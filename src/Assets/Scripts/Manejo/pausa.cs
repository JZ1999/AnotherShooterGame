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
		menu.SetActive(!menu.activeInHierarchy);
		return menu.activeInHierarchy;
	}


	public void continuar()
	{
		menu.SetActive(false);
		Time.timeScale = 1f;
		juegoEnPausa = false;
	}

	public void pausar()
	{
		menu.SetActive(true);
		Time.timeScale = 0f;
		juegoEnPausa = true;
	}

	public void salir()
	{
		menu.SetActive(false);
		Time.timeScale = 1f;
		juegoEnPausa = false;
		SceneManager.LoadScene(0);
	}

	public void reiniciar()
	{
		Time.timeScale = 1f;
		menu.SetActive(false);
		juegoEnPausa = false;
		string nombreEscena = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(nombreEscena);
		//uiEventSystem.firstSelectedGameObject = defualtSelectedMain;
	}
}

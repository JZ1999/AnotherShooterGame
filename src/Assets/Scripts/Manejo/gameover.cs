using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class gameover : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject menu;
	public static bool juegoEnPausa = false;
    #endregion

    #region Metodos de Unity

    private void FixedUpdate()
	{
        if (GameObject.FindGameObjectWithTag("Player") == null && juegoEnPausa == false)
		{
            finjuego();
        }
	}


	#endregion

	public void finjuego()
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
	}
}

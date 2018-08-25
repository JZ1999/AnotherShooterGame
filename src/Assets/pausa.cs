using System;
using UnityEngine;

[DisallowMultipleComponent]
public class pausa : MonoBehaviour {

	#region Variables
	[SerializeField]
	private KeyCode tecla;
	[SerializeField]
	private GameObject menu;
	#endregion

	#region Metodos de Unity

	private void Update()
	{
		if (Input.GetKeyDown(tecla))
		{
			toggleMenu();
		}
	}

	private void toggleMenu()
	{
		menu.active = !menu.active;
	}

	#endregion
}

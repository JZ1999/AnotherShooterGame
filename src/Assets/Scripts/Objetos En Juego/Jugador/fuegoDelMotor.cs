using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class fuegoDelMotor : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject[] objetosFuego;
	private bool sinMoverse = true;
	#endregion

	#region Metodos de Unity

	private void Start()
	{
		foreach(GameObject obj in objetosFuego)
		{
			obj.GetComponent<ParticleSystem>().Pause();
		}
	}

	void Update () {
		
		if (conseguirPresionadoTecla())
		{

			if (sinMoverse)
			{
				foreach (GameObject obj in objetosFuego)
				{
					//obj.SetActive(true);
					obj.GetComponent<ParticleSystem>().Play();
				}
				sinMoverse = false;
			}
		}
		else
		{
			foreach (GameObject obj in objetosFuego)
			{
				//obj.SetActive(false);
				obj.GetComponent<ParticleSystem>().Stop();
			}
			sinMoverse = true;
			
		}
    }


	#endregion
	private static bool conseguirPresionadoTecla()
	{
		return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
	}
}

using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class barraProgreso : MonoBehaviour {
	//TODO: Este script no sirve


	#region Variables
	[SerializeField]
	private Vector3 final;
	private Vector3 posJugador;
	[SerializeField]
	private SimpleHealthBar healthBar;
	private Vector3 posTR;
	#endregion

	#region Metodos de Unity
	void Start () {
		posTR = transform.position;
		posJugador = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    
    void Update () {
		try
		{
			actualizarBarraYIcono();
		}
		catch(System.Exception e)
		{
			Debug.Log(e);
		}
    }

	private void actualizarBarraYIcono()
	{
		float z = (final.z-Mathf.Abs(gameObject.GetComponent<Image>().transform.position.z));
		gameObject.GetComponent<Image>().transform.position = new Vector3(posTR.x, z,posTR.z);
		healthBar.UpdateBar(final.z - Vector3.Distance(posJugador, final), final.z);
	}
	#endregion
}

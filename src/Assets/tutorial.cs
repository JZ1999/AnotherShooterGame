using UnityEngine;

[DisallowMultipleComponent]
public class tutorial : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject[] paneles;
	[SerializeField]
	private Transform posJugador;
	[SerializeField]
	private float[] posiciones;//Las posiciones cuando se activará los paneles
    #endregion

    #region Metodos de Unity
    void Start () {
		paneles[0].SetActive(true);
    }
    
    void Update () {
		
		for(int i = 1; i<posiciones.Length; i++)
		{
			try
			{
				if (posJugador.position.z >= posiciones[i] )
				{
					paneles[i].SetActive(true);
				}
			}catch{

			}
		}
	}
    #endregion
}

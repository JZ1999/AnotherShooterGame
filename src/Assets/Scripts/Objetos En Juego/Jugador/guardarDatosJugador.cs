using UnityEngine;

[DisallowMultipleComponent]
public class guardarDatosJugador : MonoBehaviour {

	#region Variables
	[SerializeField]
	private DatosDeJugador info;
    #endregion

    #region Metodos de Unity

    #endregion

	public DatosDeJugador getInfo()
	{
		return info;
	}

	public void setInfo(DatosDeJugador datos)
	{
		info = datos;
	}
}

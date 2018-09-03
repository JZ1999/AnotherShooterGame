using UnityEngine;

[DisallowMultipleComponent]
public class movimientCuboTMP : MonoBehaviour {

	#region Variables
	[SerializeField]
	private float speed;
	private int direccion = 1;
    #endregion

    #region Metodos de Unity
    
    void Update ()
	{
		if (!pausa.juegoEnPausa)
		{
			mover();
		}
	}

	#endregion

	private void mover()
	{
		identificarDireccion();
		Vector3 vecDeseado = new Vector3(1, 0) * speed * direccion;
		gameObject.transform.Translate(vecDeseado);
	}

	private void identificarDireccion()
	{
		if (gameObject.transform.position.x < -15)
		{
			direccion = 1;
		}
		else if (gameObject.transform.position.x > 15)
		{
			direccion = -1;
		}
	}
}

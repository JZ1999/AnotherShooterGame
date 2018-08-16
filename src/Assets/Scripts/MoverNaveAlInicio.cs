using UnityEngine;

[DisallowMultipleComponent]
public class MoverNaveAlInicio : MonoBehaviour {

	#region Variables
	[SerializeField]
	private Vector3 posInicial;
	#endregion

	#region Metodos de Unity
	private void OnEnable()
	{
		transform.position = posInicial;
	}
    #endregion
}

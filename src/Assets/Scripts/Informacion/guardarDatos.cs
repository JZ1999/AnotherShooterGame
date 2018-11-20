using UnityEngine;

[DisallowMultipleComponent]
public class guardarDatos : MonoBehaviour {

	#region Variables
	[SerializeField]
	private Obstaculo info;
	#endregion

	public Obstaculo getInfo()
	{
		return info;
	}

}

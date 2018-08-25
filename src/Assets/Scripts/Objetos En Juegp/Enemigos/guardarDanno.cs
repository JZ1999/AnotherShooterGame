using UnityEngine;

[DisallowMultipleComponent]
public class guardarDanno : MonoBehaviour
{

	#region Variables
	[SerializeField]
	private DannoEnemigo info;
	#endregion

	public DannoEnemigo getInfo()
	{
		return info;
	}

}

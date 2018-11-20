using UnityEngine;

[DisallowMultipleComponent]
public class guardarDanno : MonoBehaviour
{

	#region Variables
	private  Enemigo info;
	#endregion

	public Enemigo getInfo()
	{
		return info;
	}

	public void setInfo(Enemigo _info)
	{
		info = _info;
	}

}

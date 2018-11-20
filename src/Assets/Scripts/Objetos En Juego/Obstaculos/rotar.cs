using UnityEngine;

enum Dir
{
	X,Y,Z
}

[DisallowMultipleComponent]
public class rotar : MonoBehaviour
{

	#region Variables
	[SerializeField]
	private float velocidad;
	[SerializeField]
	private Dir dir;
	#endregion

	#region Metodos de Unity

	void Update()
	{
		if (dir == Dir.X)
			transform.Rotate(0, velocidad * Time.deltaTime, 0, Space.Self);
		else if (dir == Dir.Y)
			transform.Rotate(velocidad * Time.deltaTime, 0, 0, Space.Self);
		else
			transform.Rotate(0, 0, velocidad * Time.deltaTime, Space.Self);
	}

	#endregion
}

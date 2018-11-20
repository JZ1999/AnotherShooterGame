using UnityEngine;

[DisallowMultipleComponent]
public class spawnearObstaculos : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject[] objs;

	[SerializeField]
	private float[] limites;
	private float tiempo;
	private int i;
	#endregion

	#region Metodos de Unity

	private void Start()
	{
		i = 0;
		tiempo = Random.Range(4f,8f);
	}

	void Update () {
		if (tiempo <= 0)
		{
			espawnear();
		}
		else
		{
			tiempo-= Time.deltaTime;
		}
    }


	#endregion

	private void espawnear()
	{
		//Esto es el indica que cual obstaculo sigue para espawnear
		i = i % objs.Length;
		Vector3 pos = new Vector3
		(
			Random.Range(limites[0], limites[1]),
			0.0f,
			1600f
		);

		Instantiate(objs[i], pos, Quaternion.identity);
		tiempo = Random.Range(4f, 10f);
		i++;
	}
}

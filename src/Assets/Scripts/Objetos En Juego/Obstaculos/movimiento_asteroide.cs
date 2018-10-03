using UnityEngine;

public enum Eje
{
	X,Y,Z
}

[DisallowMultipleComponent]
public class movimiento_asteroide : MonoBehaviour {

	#region Variables
	
	private float velocidad = 0;

	private Eje eje;
    #endregion

    #region Metodos de Unity
    void Start () {
		transform.localScale = Vector3.one * Random.Range(0.2f, 1.5f);
		velocidad += Random.Range(0, 400);
		Vector3 vect = new Vector3(0, 0, Mathf.Abs(30 + velocidad));
		GetComponent<Rigidbody>().AddForce(-vect*15);
		int n = Random.Range(0, 3);
		switch (n)
		{
			case 0:
				eje = Eje.X;
				break;
			case 1:
				eje = Eje.Y;
				break;
			case 2:
				eje = Eje.Z;
				break;
			default:
				eje = Eje.Z;
				break;
		}
    }
    
    void FixedUpdate () {
		
		switch (eje)
		{
			case Eje.X:
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(transform.position.x, 0, 0);
				break;
			case Eje.Y:
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, transform.position.x, 0);
				break;
			case Eje.Z:
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(0,0,transform.position.x);
				break;
			default:
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.x, 0, 0);
				break;
		}
    }
    #endregion
}

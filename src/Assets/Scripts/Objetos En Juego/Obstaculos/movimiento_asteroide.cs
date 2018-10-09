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
	private Vector3 vect;
    #endregion

    #region Metodos de Unity
    void Start () {
		//transform.localScale = Vector3.one * Random.Range(0.2f, 1.5f);
		//velocidad += Random.Range(1, 10);
		//vect = new Vector3(0, 0, Mathf.Abs(velocidad));
		//GetComponent<Rigidbody>().AddForce(-vect*15);
		//transform.Translate(vect);
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
		//transform.Translate(new Vector3(0,0,GameObject.FindGameObjectWithTag("Player").transform.position.z));
		transform.position -= new Vector3(0, 0, GameObject.FindGameObjectWithTag("Player").transform.position.z);

		/*switch (eje)
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
		}*/
	}
    #endregion
}

using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

[DisallowMultipleComponent]
public class Movimiento : MonoBehaviour {

	#region Variables
	[SerializeField]
	private float speed;
	[SerializeField]
	private float tilt;
	[SerializeField]
	private Boundary boundary;
	[SerializeField]
	private AudioSource motorSND;

	private bool tocandoSonido = false;
	#endregion

	#region Metodos de Unity
	void FixedUpdate()
	{
		float moveHorizontal, moveVertical;
		conseguirInputs(out moveHorizontal, out moveVertical);
		aplicarMovimiento(moveHorizontal, moveVertical);
		sonarMotor();
	}

	#endregion

	private void sonarMotor()
	{
		bool presionadoTecla = conseguirPresionadoTecla();
		if (presionadoTecla)
		{
			if (!tocandoSonido)
			{
				motorSND.Play();
				tocandoSonido = true;
			}
			else
			{
				motorSND.UnPause();
			}
		}
		else
		{
			motorSND.Pause();
		}
	}

	private static bool conseguirPresionadoTecla()
	{
		return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
	}

	private void aplicarMovimiento(float moveHorizontal, float moveVertical)
	{
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		//Esta parte hace la restriccion de movimiento (Barreras)
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	private void conseguirInputs(out float moveHorizontal, out float moveVertical)
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
	}
}

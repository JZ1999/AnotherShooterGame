using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

[DisallowMultipleComponent]
public class Movimiento : MonoBehaviour {
	[SerializeField]
	[Tooltip("Valor que define que tanto es la atraccion gravitacional")]
	[Range(0.1f,20)]
	private float denominador;


	#region Variables
	[SerializeField]
	private float speed;
	[SerializeField]
	private float tilt;
	[SerializeField]
	private Boundary boundary;
	[SerializeField]
	private AudioSource motorSND;

	private GameObject[] objsGravedad;//Lista de objetos que atraen
	private GameObject objGravedad;//Objeto que atrae actualmente
	private bool jalarGravedad = false;//Booleano que decide si está en campo
									//gravitacional

	private bool tocandoSonido = false;
	#endregion

	#region Metodos de Unity
	private void Start()
	{
		objsGravedad = GameObject.FindGameObjectsWithTag("gravitacional");
	}

	void FixedUpdate()
	{
		foreach (var obj in objsGravedad)
		{
			if (obj.GetComponent<AtraerGravedad>().Jalar)
			{
				objGravedad = obj;
				jalarGravedad = true;
				break;
			}else
				jalarGravedad = false;
		}

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
		
		efectoGravitacional();
		aplicarBarreras();

		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	private void aplicarBarreras()
	{
		//Esta parte hace la restriccion de movimiento (Barreras)
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
	}

	private void efectoGravitacional()
	{
		if (jalarGravedad)
		{
			Vector3 offsetPorLaGravedad = objGravedad.transform.position / denominador;
			GetComponent<Rigidbody>().velocity += offsetPorLaGravedad;
		}
	}

	private void conseguirInputs(out float moveHorizontal, out float moveVertical)
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
	}

}

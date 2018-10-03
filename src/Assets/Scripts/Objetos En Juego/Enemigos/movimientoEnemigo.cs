using UnityEngine;

[DisallowMultipleComponent]
public class movimientoEnemigo : MonoBehaviour {
	//Formula de movimiento es velocidad^constane_velocidad_exp * constante_velocidad 

	#region Variables
	private const float constante_velocidad = 1.3f;


	[SerializeField]
	private Enemigo informacion;
	
	private float velocidad;
	[SerializeField]
	private float tilt;
	[SerializeField]
	private Boundary boundary;
	[SerializeField]
	private AudioSource motorSND;
    private Transform naveTR;
	private Vector3 tiltOriginal;

    private bool tocandoSonido = false;
	#endregion

	#region Metodos de Unity
	private void Start()
	{
		velocidad = informacion.velocidad;
		tiltOriginal = transform.position;
	}

	void FixedUpdate()
	{
		float moveHorizontal, moveVertical;
        naveTR = GameObject.FindGameObjectWithTag("Player").transform;
        conseguirInputs(out moveHorizontal, out moveVertical, naveTR);
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
		return true;
	}

	private void aplicarMovimiento(float moveHorizontal, float moveVertical)
	{
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * velocidad * constante_velocidad;

		//Esta parte hace la restriccion de movimiento (Barreras)
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		aplicarRotacion();
	}

	private void aplicarRotacion()
	{
		float dir = -naveTR.transform.position.x + transform.position.x;
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(-20, dir, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	private void conseguirInputs(out float moveHorizontal, out float moveVertical, Transform naveTR)
	{
        float posjugador_x = naveTR.position.x;
		float posjugador_z = naveTR.position.z;

		if (Mathf.Abs((posjugador_x - transform.position.x)) <= 2)
        {
            moveHorizontal = 0;
        }
        else
        {
			moveHorizontal = (posjugador_x - transform.position.x) < 0 ? -1 : 1;
        }
		
		if (Vector3.Distance(naveTR.position, transform.position) >= 36)
		{
			moveVertical = 0;
		}
		else
		{
			moveVertical = -((posjugador_z - transform.position.z) / velocidad)/5;
		}
	}
}

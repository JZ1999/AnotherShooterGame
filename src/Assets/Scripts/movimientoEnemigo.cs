using UnityEngine;

[DisallowMultipleComponent]
public class movimientoEnemigo : MonoBehaviour {

	#region Variables
	[SerializeField]
	private float speed;
	[SerializeField]
	private float tilt;
	[SerializeField]
	private Boundary boundary;
	[SerializeField]
	private AudioSource motorSND;
    private Transform naveTR;

    private bool tocandoSonido = false;
	#endregion

	#region Metodos de Unity
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

	private void conseguirInputs(out float moveHorizontal, out float moveVertical, Transform naveTR)
	{
        float posjugador_x = naveTR.position.x;
        float posenemigo_x = GameObject.FindGameObjectWithTag("enemigo").transform.position.x;
        if (Mathf.Abs((posjugador_x - posenemigo_x)) <= 2)
        {
            moveHorizontal = 0;
        }
        else
        {
            moveHorizontal = (posjugador_x - posenemigo_x)/speed;
        }
		moveVertical = 0;
	}
}

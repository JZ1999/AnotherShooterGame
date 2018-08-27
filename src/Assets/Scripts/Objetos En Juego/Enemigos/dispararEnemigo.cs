using UnityEngine;

[DisallowMultipleComponent]
public class dispararEnemigo : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject bullet;
	[SerializeField]
	private AudioSource laserSND;
	[SerializeField]
	[Range(0.1f, 5f)]
	private float cooldown;
	private float siguiente_disparo;

	#endregion

	#region Metodos de Unity

	private void Start()
	{
		siguiente_disparo = Time.time;
	}

	void Update () {
        TiempodeDisparar();
	}
    #endregion

    void TiempodeDisparar()
    {
        if (Time.time > siguiente_disparo)
        {
			Quaternion rotacion = Quaternion.FromToRotation(Vector3.up, transform.forward);
			Vector3 posicion = transform.position;
			Instantiate(bullet, posicion, rotacion);
            laserSND.Play();
            siguiente_disparo = Time.time + cooldown;
        }
    }
}

using UnityEngine;

[DisallowMultipleComponent]
public class disparar : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject laser;
	[SerializeField]
	private KeyCode tecla;
	[SerializeField]
	private AudioSource laserSND;
	[SerializeField]
	private Vector3[] offsets;//1er es el izquierda y el otro derecho
	[SerializeField]
	[Range(0.1f, 5f)]
	private float cooldown;
	private float cooldown_cp;
	#endregion

	#region Metodos de Unity

	private void Start()
	{
		cooldown_cp = cooldown;
		
	}

	void Update () {
		if (Input.GetKeyDown(tecla) && cooldownTermino())
		{
			crearLaserYsuTransform();
			resetearCooldown();
		}
		cooldown -= Time.deltaTime;
	}
	#endregion
	private void resetearCooldown()
	{
		cooldown = cooldown_cp;
	}

	private bool cooldownTermino()
	{
		bool termino = cooldown <= 0;
		return termino;
	}
 
	private void crearLaserYsuTransform()
	{
		Quaternion rotacionDeseada = Quaternion.Euler(new Vector3(90, 0, 0));
		Vector3 posicionDeseadaIzquierdo = transform.position + offsets[0];
		Vector3 posicionDeseadaDerecho = transform.position + offsets[1];
		crearLasers(rotacionDeseada, posicionDeseadaIzquierdo, posicionDeseadaDerecho);
	}

	private void crearLasers(Quaternion rotacionDeseada, Vector3 posicionDeseadaIzquierdo, Vector3 posicionDeseadaDerecho)
	{
		Instantiate(laser, posicionDeseadaIzquierdo, rotacionDeseada);
		Instantiate(laser, posicionDeseadaDerecho, rotacionDeseada);
		laserSND.Play();
	}
}

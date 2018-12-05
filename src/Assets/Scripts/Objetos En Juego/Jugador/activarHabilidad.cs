using UnityEngine;

[DisallowMultipleComponent]
public class activarHabilidad : MonoBehaviour {

	#region Variables
	[SerializeField]
	private KeyCode tecla;
	[SerializeField]
	private GameObject misil;
	private float cooldown;
	private float cooldown_aux;
	[SerializeField]
	private AudioSource en_cooldownSND;
	[SerializeField]
	private SimpleHealthBar energía;
	[SerializeField]
	private DatosDeJugador info;
	#endregion

	#region Metodos de Unity

	private void Start()
	{
		cooldown = info.cooldownHabilidad;
		cooldown_aux = cooldown;
	}

	void Update () {
		if (Input.GetKeyDown(tecla))
		{
			usarHabilidad();
		}
		if (cooldown >= 0)
			energía.UpdateBar(100 - (cooldown / cooldown_aux) * 100, 100);
		cooldown -= Time.deltaTime;
	}


	#endregion

	private void usarHabilidad()
	{
		if (cooldown <= 0)
		{
			Quaternion rotacionDeseada = Quaternion.Euler(new Vector3(0, 0, 0));
			Instantiate(misil, transform.position, rotacionDeseada);
			cooldown = cooldown_aux;
		}
		else
			en_cooldownSND.Play();
	}
}

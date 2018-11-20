using UnityEngine;

[DisallowMultipleComponent]
public class activarHabilidad : MonoBehaviour {

	#region Variables
	[SerializeField]
	private KeyCode tecla;
	[SerializeField]
	private GameObject misil;
	[SerializeField]
	private float cooldown = 2f;
	[SerializeField]
	private AudioSource en_cooldownSND;
    #endregion

    #region Metodos de Unity
    void Start () {
        
    }
    
    void Update () {
		if (Input.GetKeyDown(tecla))
		{
			if (cooldown <= 0)
			{
				Quaternion rotacionDeseada = Quaternion.Euler(new Vector3(0, 0, 0));
				Instantiate(misil, transform.position, rotacionDeseada);
				cooldown = 2f;
			}
			else
				en_cooldownSND.Play();
		}
		cooldown -= Time.deltaTime;
	}
    #endregion
}

using UnityEngine;

[DisallowMultipleComponent]
public class activarHabilidad : MonoBehaviour {

	#region Variables
	[SerializeField]
	private KeyCode tecla;
	[SerializeField]
	private GameObject misil;
    #endregion

    #region Metodos de Unity
    void Start () {
        
    }
    
    void Update () {
		if (Input.GetKeyDown(tecla))
		{
			Quaternion rotacionDeseada = Quaternion.Euler(new Vector3(0, 0, 0));
			Instantiate(misil, transform.position, rotacionDeseada);
		}
    }
    #endregion
}

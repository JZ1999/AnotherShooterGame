using UnityEngine;

[DisallowMultipleComponent]
public class mensajesDespawn : MonoBehaviour {

	#region Variables
	
	private float tiempoDeVida = 37f;
    #endregion

    #region Metodos de Unity
    void Start () {
        
    }
    
    void Update () {
		if (tiempoDeVida <= 0) Destroy(gameObject);
		tiempoDeVida--;
    }
    #endregion
}

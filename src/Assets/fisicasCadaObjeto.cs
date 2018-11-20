using UnityEngine;

[DisallowMultipleComponent]
public class fisicasCadaObjeto : MonoBehaviour {

    #region Variables

    #endregion

    #region Metodos de Unity
    void Start () {
		Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
		foreach (var parte in rigidbodies)
		{
			Vector3 posicion = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))*100;
			parte.AddForce(posicion);
		}
    }
    
    void Update () {
        
    }
    #endregion
}

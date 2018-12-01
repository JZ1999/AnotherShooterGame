using UnityEngine;

[DisallowMultipleComponent]
public class despawnFracturas : MonoBehaviour {

	#region Variables
	[SerializeField]
	private float tiempo;
    #endregion

    #region Metodos de Unity
    
    void Update () {
		if (tiempo <= 0) Destroy(gameObject);
		tiempo -= Time.deltaTime;
    }
    #endregion
}

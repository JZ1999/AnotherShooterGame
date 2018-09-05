using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class activar : MonoBehaviour {

	#region Variables
	private Image img;
    #endregion

    #region Metodos de Unity
    void Start () {
		img = GetComponent<Image>();
    }
    
    void Update () {
		if (efectoVisualGravitacional.activado)
			img.enabled = true;
		else
			img.enabled = false;
    }
    #endregion
}

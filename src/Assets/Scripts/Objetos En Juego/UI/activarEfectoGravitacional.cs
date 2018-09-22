using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class activarEfectoGravitacional : MonoBehaviour {

	#region Variables
	private Image img;
    #endregion

    #region Metodos de Unity
    void Start () {
		img = GetComponent<Image>();
    }
    
    void Update () {
		if (efectoVisualGravitacional.activado)
		{
			float alpha = efectoVisualGravitacional.indice;
			Color color_deseado = new Color(img.color.r, img.color.g, img.color.b, alpha);
			img.color = color_deseado;
			img.enabled = true;
		}
		else
		{
			img.enabled = false;
		}
    }
    #endregion
}

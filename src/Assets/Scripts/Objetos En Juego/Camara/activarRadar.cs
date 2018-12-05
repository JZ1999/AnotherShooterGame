using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class activarRadar : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject radarOBJ;
	private Color c;
	private float aux = 1;
    #endregion

    #region Metodos de Unity
    void Start () {
        
    }
    
    void Update () {
		if (GetComponent<Camera>().isActiveAndEnabled)
		{
			c = radarOBJ.GetComponent<Image>().color;
			c.a = aux;
			
			radarOBJ.GetComponent<Image>().color = c;
			if(aux>=0.1)
				aux -= 0.06f;
		}
		else
		{
			c = radarOBJ.GetComponent<Image>().color;
			c.a = aux;
			
			radarOBJ.GetComponent<Image>().color = c;
			if (aux <= 0.6)
				aux += 0.06f;
		}
    }
    #endregion
}

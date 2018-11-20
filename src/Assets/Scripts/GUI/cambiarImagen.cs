using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class cambiarImagen : MonoBehaviour {

	#region Variables
	[SerializeField]
	private Sprite[] intelIMG;
	private int indice = 0;
    #endregion

   public void siguiente()
	{
		try
		{
			GetComponent<Image>().sprite = intelIMG[++indice];
		}
		catch (System.Exception)
		{
			--indice;
		}
	}

	public void anterior()
	{
		try
		{
			GetComponent<Image>().sprite = intelIMG[--indice];
		}
		catch (System.Exception)
		{
			++indice;
		}
	}
}

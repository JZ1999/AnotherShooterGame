using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class barraProgreso : MonoBehaviour {
    




    #region Variables
    [SerializeField]
	private float ZFinal;
	private Vector3 posJugador;
	[SerializeField]
	private SimpleHealthBar healthBar;
	private Vector3 posTR;
    public const int offset = 770;
    private const float razonBarraIcono = 9.37f;
    private int[] XZ_delIcono = { 65, 0 };
    #endregion

    #region Metodos de Unity
    void Start () {
		posTR = transform.localPosition;
    }
    
    void Update () {
        actualizarBarraYIcono();
    }

	private void actualizarBarraYIcono()
	{
        posJugador = GameObject.FindGameObjectWithTag("Player").transform.position;
        float posicion = posTR.y;
        float aumento = Mathf.Min(razonBarraIcono, ((posJugador.z + offset) / ZFinal * razonBarraIcono));    
        transform.localPosition = new Vector3(XZ_delIcono[0], posicion + aumento , XZ_delIcono[1]);
        healthBar.UpdateBar(posJugador.z + offset, ZFinal);
    }
	#endregion
}

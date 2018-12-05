using UnityEngine;

[CreateAssetMenu(fileName = "NuevosDatosNave", menuName = "DatosNave")]
public class DatosDeJugador : ScriptableObject {

	#region Variables

	//TODO:
	//Cambiar este enum y sus valores para que tengan
	//las habilidades finales del juego
	public enum habilidades
	{
		NINGUNA, MISIL_PERSIGUIDOR
	};

	[Header("Stats")]
	public int nivel = 1;
	[Range(2f, 50f)]
	public int vida;
	public habilidades habilidad;
	[Range(1f, 50f)]
	public int dannoHabilidad;
	[Range(5f, 60f)]
	[Tooltip("Cooldown de la habilidad")]
	public float cooldownHabilidad;
	[Range(0.7f, 3f)]
	[Tooltip("Cooldown al disparar")]
	public float cooldown;
	[Range(1f, 30f)]
	public int danno;

	[Space]

	[Header("Misc")]
	public string nombreDeNave;
	[TextArea]
	public string descripcion;


	#endregion

}

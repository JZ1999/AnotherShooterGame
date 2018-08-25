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
	[Range(2f, 6f)]
	public int vida;
	public habilidades habilidad;
	[Range(0.7f, 3f)]
	[Tooltip("Cooldown al disparar")]
	public float cooldown;
	public const float cooldownHabilidad = 10f;
	[Range(1f, 6f)]
	public int danno;

	[Space]

	[Header("Misc")]
	public string nombreDeNave;
	[TextArea]
	public string descripcion;


	#endregion

}

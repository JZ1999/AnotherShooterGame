using UnityEngine;

[CreateAssetMenu(fileName = "NuevoObstaculo", menuName = "Obstaculo")]
public class Obstaculo : ScriptableObject
{

	#region Variables
	[Header("Variables del obstáculo")]
	[Range(0,10)]
	public int velocidad;
	public int ataque;
	public int escudos;
	[Range(0, 20)]
	public int recompensa;

	[Space]
	[Header("Información")]
	public string nombre;
	[TextArea]
	public string descripcion;
	
	#endregion
}

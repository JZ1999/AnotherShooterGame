using UnityEngine;

[CreateAssetMenu(fileName = "NuevoEnemigo", menuName = "Enemigo")]
public class Enemigo : ScriptableObject
{

	#region Variables
	[Header("Variables de la nave")]
	[Range(0,10)]
	public int velocidad;
	[Range(0, 10)]
	public int ataque;
	[Range(0, 10)]
	public int escudos;
	[Range(0, 10)]
	public int maniobrabilidad;
	[Range(0, 10)]
	public int recompensa;

	[Space]
	[Header("Información")]
	public string nombre;
	[TextArea]
	public string descripcion;
	
	#endregion
}

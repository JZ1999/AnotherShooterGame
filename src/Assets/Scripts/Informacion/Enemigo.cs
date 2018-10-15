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
	[Tooltip("El rango mínimo de cualquier enemigo")]
	[Range(10, 30)]
	public int rangoOffset;
	[Range(0, 10)]
	[SerializeField]
	private int rango;
	

	public int getRango()
	{
		return this.rango*this.rangoOffset;
	}

	[Space]
	[Header("Información")]
	public string nombre;
	[TextArea]
	public string descripcion;

	#endregion
}

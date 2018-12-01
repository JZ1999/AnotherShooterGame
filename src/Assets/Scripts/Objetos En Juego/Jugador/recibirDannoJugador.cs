using UnityEngine;

[DisallowMultipleComponent]
public class recibirDannoJugador : MonoBehaviour {

	#region Variables
	[SerializeField]
	private DatosDeJugador info;

	private int vida;
	[SerializeField]
	private GameObject[] objetosDanninos;
	private int danno;
	[SerializeField]
	private bool modoDios;
	[SerializeField]
	private SimpleHealthBar healthBar;
	#endregion


	#region Metodos de Unity
	private void Start () {
        vida = info.vida;
    }
    
	private void OnTriggerEnter(Collider other)
	{
		asignarDannoInfo(other);
		muerte();
	}
    
	private void asignarDannoInfo(Collider other)
	{
		foreach (var obj in objetosDanninos)
		{
			
			if (obj.CompareTag(other.tag))
			{
				try
				{
					//Obstaculos
					
					danno = obj.GetComponent<guardarDatos>().getInfo().ataque;
				}
				catch(System.Exception)
				{
					//Proyectiles
					danno = other.GetComponent<guardarDanno>().getInfo().ataque;
				}
				perderVida(other);
				break;
			}
		}
	}

	private void muerte()
	{
		if (vida <= 0)
		{
			Destroy(gameObject);
			Debug.Log("Dead");
        }
	}

	private void perderVida(Collider other)
	{
		if (!modoDios)
		{
			vida -= danno;
			healthBar.UpdateBar(((float)vida / (float)info.vida) * 100, 100);
		}
	}
    #endregion
}

using UnityEngine;

[DisallowMultipleComponent]
public class spawnearObjetosIniciales : MonoBehaviour {

	#region Variables
	[SerializeField]
	private GameObject[] objetos;
	#endregion

	#region Metodos de Unity
	void Awake()
	{
		foreach (var objeto in objetos)
		{
			Instantiate(objeto);
		}
	}
    
    void Update () {
        
    }
    #endregion
}

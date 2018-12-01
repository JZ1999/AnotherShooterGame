using UnityEngine;

[DisallowMultipleComponent]
public class powerup_bounce : MonoBehaviour {

    #region Variables
	[SerializeField]
	private float multiplicador;
	[SerializeField]
	private float offset = 10;
    #endregion

    #region Metodos de Unity
    
    void FixedUpdate () {
		if (!GetComponent<interaccionLoot>().getenRango())
		{
			Vector3 pos = transform.position;
			pos.y = Mathf.Sin(offset) * multiplicador;
			offset += 0.1f;
			transform.position = pos;
		}
	}
    #endregion
}

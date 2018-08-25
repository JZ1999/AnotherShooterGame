using UnityEngine;

[DisallowMultipleComponent]
public class movimientCuboTMP : MonoBehaviour {

	#region Variables
	[SerializeField]
	private float speed;
	private int side = 1;
    #endregion

    #region Metodos de Unity
    void Start () {
        
    }
    
    void Update () {
		if (gameObject.transform.position.x < -800)
		{
			side = 1;
		}
		else if (gameObject.transform.position.x > 800)
		{
			side = -1;
		}
		gameObject.transform.Translate(new Vector3(1,0) * speed * side);
	}
    #endregion
}

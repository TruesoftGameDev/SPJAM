using UnityEngine;
using System.Collections;

public class CameraTop : MonoBehaviour {
	public int ajustey;
	public int ajustez;
	
	public GameObject personagem;
	void Update () {
		transform.position = new Vector3(0,transform.position.y+ajustey, personagem.transform.position.z+ajustez);	
	}
}

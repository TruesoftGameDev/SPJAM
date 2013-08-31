using UnityEngine;
using System.Collections;

public class CameraTop : MonoBehaviour {
	
	public GameObject personagem;
	void Update () {
		transform.position = new Vector3(0,transform.position.y, personagem.transform.position.z);	
	}
}

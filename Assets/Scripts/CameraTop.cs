using UnityEngine;
using System.Collections;

public class CameraTop : MonoBehaviour {
	
	void Update () {
		transform.position = new Vector3(0,transform.position.y, transform.position.z);	
	}
}

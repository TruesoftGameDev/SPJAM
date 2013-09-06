using UnityEngine;
using System.Collections;

public class DestroyAfterPlay : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		if(!gameObject.audio.isPlaying)
			Destroy(this);
	}
}

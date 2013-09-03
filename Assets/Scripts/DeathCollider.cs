using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {
	
	public AudioSource Sound;

	void OnTriggerEnter(Collider colisor)
	{
		Debug.Log ("Teste");
		if(colisor.gameObject.tag == "DeathCollider")
		{
			Debug.Log ("Entrou");
			SendMessage("Dead");
			Instantiate(Sound);
		}
	}
}

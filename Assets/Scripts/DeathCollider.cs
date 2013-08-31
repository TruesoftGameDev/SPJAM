using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

	void OnTriggerEnter(Collider colisor)
	{
		Debug.Log ("Teste");
		if(colisor.gameObject.tag == "DeathCollider")
		{
			Debug.Log ("Entrou");
			SendMessage("Dead");
		}
	}
}

using UnityEngine;
using System.Collections;

public class Projetil : MonoBehaviour {

	//public ParticleSystem particula;
	public float tempoDeVida;
	void Start () {
	
	}
	
	
	void Update () {
		if(tempoDeVida<0)
			DestroyProj();
		tempoDeVida -= Time.deltaTime;		
	}
	void OnColliderEnter(Collider col)
	{
		DestroyProj();	
	}
	
	void DestroyProj()
	{
		//Instantiate(particula, transform.position,Quaternion.identity);
		Destroy(gameObject);
	}
}

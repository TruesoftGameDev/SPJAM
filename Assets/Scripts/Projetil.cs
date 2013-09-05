using UnityEngine;
using System.Collections;

public class Projetil : MonoBehaviour {

	//public ParticleSystem particula;
	public float tempoDeVida;
	private float tempoVivo;
	void Start () {
	
	}
	
	
	void Update () {
		if(tempoVivo>tempoDeVida)
			DestroyProj();
		tempoVivo +=Time.deltaTime;		
	}
	void OnCollisionEnter(Collision collision)
	{
		DestroyProj();	
	}
	
	void DestroyProj()
	{
		//Instantiate(particula, transform.position,Quaternion.identity);
		if(tempoVivo > 1)
			Destroy(gameObject);
	}
}

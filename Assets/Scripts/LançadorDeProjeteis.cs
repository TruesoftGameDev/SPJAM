using UnityEngine;
using System.Collections;

public class LançadorDeProjeteis : MonoBehaviour {
	
	public float intervaloDisparos;
	public Rigidbody projetil;
	private float intervaloAtual;
		
	void Start () {
		intervaloAtual = intervaloDisparos;
	}
	
	
	void Update () {
		intervaloAtual -= Time.deltaTime;
		if(intervaloAtual <= 0)
		{
			//Atira projetil
			Rigidbody disparado = Instantiate(projetil, transform.position, Quaternion.identity) as Rigidbody;
			disparado.AddForce(Vector3.forward * 40);
			
			intervaloAtual = intervaloDisparos;	
		}
	}
}

using UnityEngine;
using System.Collections;

public class AttributesController : MonoBehaviour {
	
	public int orbs;
	public int vidas;
	public int continues;
	
	public string nivelAtual;
	
	private bool deadCollide = false;
	private bool tocou = false;
	
	public float tempoDeMorte = 1.0f;
	
	
	void Start()
	{
		nivelAtual = Application.loadedLevelName;	
	}
	void Update()
	{
		if(orbs >= 100)
		{
			orbs-=100;
			vidas++;
		}
		
		if(deadCollide )
		{
		
			//animation.Play("Happy");
			if(tempoDeMorte>0)
			{
				tempoDeMorte -= Time.deltaTime;	
			}
			else
			{
				Dead();	
			}
		}
	}
	void OnControllerColliderHit(ControllerColliderHit ch)
	{
		
		if(ch.gameObject.tag == "OrbVermelho")
		{
			orbs += 5;
			Destroy(ch.gameObject);
			return;
		}
		if(ch.gameObject.tag == "OrbPreto")
		{
			orbs += 10;
			Destroy(ch.gameObject);
			return;
		}
	}
	void DeadCollider()
	{
		deadCollide = true;
		Destroy(gameObject.GetComponent<PlayerController>());
		animation["Happy"].speed = 6.0f;
		animation.Play("Happy");
	}
	
	void Dead()
	{	
		Application.LoadLevel(nivelAtual);
	}
}

using UnityEngine;
using System.Collections;

public class AttributesController : MonoBehaviour {
	
	public AudioSource DeathSound;
	private bool tocouDeathSound = false;
	
	public AudioSource OrbSound;
	
	
	public int orbs;
	
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
		
		if(deadCollide )
		{
			if(!tocouDeathSound)
			{
				GameObject.FindGameObjectWithTag("GameplaySound").GetComponent<AudioSource>().Stop();
				tocouDeathSound = true;
				Instantiate(DeathSound);
			}
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
			orbs += 10;
			Destroy(ch.gameObject);
			Instantiate(OrbSound);
			return;
		}
		if(ch.gameObject.tag == "OrbPreto")
		{
			orbs += 20;
			Destroy(ch.gameObject);
			Instantiate(OrbSound);
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
		Application.LoadLevel("Continue");
	}
	
	void GravaOrbs()
	{
		PlayerPrefs.SetInt(PlayerPrefs.GetString("Nivel Atual")+"OrbsTemp",orbs);
		//Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetString("Nivel Atual")+"OrbsTemp"));
	}
}

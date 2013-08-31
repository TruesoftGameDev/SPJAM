using UnityEngine;
using System.Collections;

public class AttributesController : MonoBehaviour {
	
	public int orbs;
	public int vidas;
	public int continues;
	
	
	void Update()
	{
		if(orbs >= 100)
		{
			orbs-=100;
			vidas++;
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
	
	void Dead()
	{
		Application.LoadLevel("Prototipo");
	}
}

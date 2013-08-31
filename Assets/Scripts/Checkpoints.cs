using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {
	
	public GameObject[] checkpoints; 
	public int[] perspectivas;
	public int atual;
	GameObject player;
	AttributesController controller;
	
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		controller = player.GetComponent<AttributesController>();
		PlayerController playerController = player.GetComponent<PlayerController>();
		
		if(PlayerPrefs.HasKey("Checkpoint") && controller.vidas>0)
		{
			controller.vidas--;
			atual = PlayerPrefs.GetInt("Checkpoint");
			controller.orbs = PlayerPrefs.GetInt("Orbs");
			controller.vidas = PlayerPrefs.GetInt("Vidas");
			controller.continues = PlayerPrefs.GetInt("Continues");
			player.transform.position = checkpoints[atual].transform.position;
			
		}	
		else
		atual = 0;
		playerController.trocaPerspectiva(perspectivas[atual]);
		
	}
	
	
	public void gravaCheckpoint(int check)
	{
		PlayerPrefs.SetInt("Checkpoint", check);
		PlayerPrefs.SetInt("Orbs", controller.orbs);
		PlayerPrefs.SetInt("Vidas",controller.vidas);
		PlayerPrefs.SetInt("Continues", controller.continues);
		Debug.Log ("Gravou o checkpoint " + check);
	}
}

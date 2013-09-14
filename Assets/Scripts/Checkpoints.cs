using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {
	
	public int perspectivaDaFase = 1;
	GameObject player;
	AttributesController controller;
	
	void Start () {
		
		PlayerPrefs.SetString("Tela Atual",Application.loadedLevelName);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		controller = player.GetComponent<AttributesController>();
		PlayerController playerController = player.GetComponent<PlayerController>();
		
		if(PlayerPrefs.HasKey("Vidas"))
		{
			controller.orbs = PlayerPrefs.GetInt("Orbs");
			controller.vidas = PlayerPrefs.GetInt("Vidas");
			controller.continues = PlayerPrefs.GetInt("Continues");
			controller.vidas--;
		}	
		if(controller.vidas <0)
		{
			Application.LoadLevel("Gameover");
		}
		playerController.trocaPerspectiva(perspectivaDaFase);
		
	}
	
}

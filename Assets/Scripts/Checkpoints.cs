using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {
	
	public int perspectivaDaFase = 1;
	GameObject player;
	
	void Start () {
		
		PlayerPrefs.SetString("Tela Atual",Application.loadedLevelName);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		PlayerController playerController = player.GetComponent<PlayerController>();
		
		playerController.trocaPerspectiva(perspectivaDaFase);
		
	}
	
}

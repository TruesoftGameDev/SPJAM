using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {
	
	public GameObject[] checkpoints; 
	public int[] perspectivas;
	public int atual;
	
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		AttributesController controller = player.GetComponent<AttributesController>();
		
		if(PlayerPrefs.HasKey("Checkpoint"))
		{
			atual = PlayerPrefs.GetInt("Checkpoint");
			controller.orbs = PlayerPrefs.GetInt("Orbs");
			controller.vidas = PlayerPrefs.GetInt("Vidas");
			controller.continues = PlayerPrefs.GetInt("Continues");
			player.transform.position = checkpoints[atual].transform.position;
		}	
		else
			atual = 0;
		
		
	}
	
	
	void Update () {
		
	}
}

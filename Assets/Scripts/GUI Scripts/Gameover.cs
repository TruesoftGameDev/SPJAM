using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	public float tempo;
	private float tp;
	void Start () {
		tp = tempo;
		PlayerPrefs.DeleteAll();
	}
	
	
	// Update is called once per frame
	void Update () {
		tp -= Time.deltaTime;
		if(tp<0)
		{
			Application.LoadLevel("Menu inicial");	
		}
	}
}

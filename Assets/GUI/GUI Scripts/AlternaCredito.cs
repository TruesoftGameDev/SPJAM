using UnityEngine;
using System.Collections;

public class AlternaCredito : MonoBehaviour {

	public Texture2D truesoft;
	public Texture2D spJam;
	private int i;
	public float tempoParaAlternar = 5.0f;
	private float time;
	private GUITexture credito;
	
	void Start () {
		guiTexture.texture = truesoft;
		i = 0;
	}
	
	
	void Update () {
		time-= Time.deltaTime;
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("Menu inicial");	
		}
		
		if(time<0)
		{
			switch(i)
			{
				case 0:
					guiTexture.texture = spJam;
					i = 1;
					break;
				case 1:
					guiTexture.texture = truesoft;
					i = 0;
					break;
			}
			time = tempoParaAlternar;
		}
		
	}
}

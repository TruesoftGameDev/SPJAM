using UnityEngine;
using System.Collections;

public enum PauseOptions
{
	voltar,
	menu,
	sair
}


public class PauseMenu : MonoBehaviour {

	PlayerController controller;
	
	public GUITexture voltar;
	public GUITexture sair;
	public GUITexture menu;
	public GUITexture pauseTop;
	
	public Texture2D[] padrao;
	public Texture2D[] selecionado;
	
	public PauseOptions opt = PauseOptions.voltar;
	
	
	void Start () {
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		voltar.enabled = false;
		menu.enabled = false;
		sair.enabled = false;
		pauseTop.enabled = false;
	}
	
	void Update () {
		
		if(controller.pause)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				controller.pause = false;
				Time.timeScale = 1.0f;
				voltar.enabled = false;
				menu.enabled = false;
				sair.enabled = false;
				pauseTop.enabled = false;
			}
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				opt--;
				if((int)opt <0)
					opt = PauseOptions.sair;
			}
			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				opt++;
				if((int)opt>2)
					opt = PauseOptions.voltar;
			}
			
			
			Debug.Log ((int)opt);
			switch(opt)
			{
				case PauseOptions.voltar:
					voltar.texture = selecionado[0];
					menu.texture = padrao[1];
					sair.texture = padrao[2];
					break;
				case PauseOptions.menu:
					voltar.texture = padrao[0];
					menu.texture = selecionado[1];
					sair.texture = padrao[2];
					break;
				case PauseOptions.sair:
					voltar.texture = padrao[0];
					menu.texture = padrao[1];
					sair.texture = selecionado[2];
					break;
					
			}
			if(Input.GetKeyDown(KeyCode.Return))
			{
				switch(opt)
				{
					case PauseOptions.voltar:
						controller.pause = false;
						Time.timeScale = 1.0f;
						voltar.enabled = false;
						menu.enabled = false;
						sair.enabled = false;
						pauseTop.enabled = false;
						break;
					case PauseOptions.menu:
						controller.pause = false;
						Time.timeScale = 1.0f;
						voltar.enabled = false;
						menu.enabled = false;
						sair.enabled = false;
						pauseTop.enabled = false;
						GameObject.FindGameObjectWithTag("Player").GetComponent<AttributesController>().vidas++;
						Application.LoadLevel("Menu inicial");
						break;
					case PauseOptions.sair:
						GameObject.FindGameObjectWithTag("Player").GetComponent<AttributesController>().vidas++;
						Application.Quit();
						break;
						
				}
			}
			
			
			
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				controller.pause = true;
				Time.timeScale = 0.0f;
				voltar.enabled = true;
				menu.enabled = true;
				sair.enabled = true;
				pauseTop.enabled = true;
			}
		}
	
	}
}

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
	public GUITexture pauseButton;
	
	public GUITexture voltar;
	public GUITexture sair;
	public GUITexture menu;
	public GUITexture pauseTop;
	
	public Texture2D[] padrao;
	public Texture2D[] selecionado;
	
	public PauseOptions opt = PauseOptions.voltar;
	public bool tocou = false;
	
	
	void Start () {
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		voltar.enabled = false;
		menu.enabled = false;
		sair.enabled = false;
		pauseTop.enabled = false;
	}
	
	public bool checarPausa () {
		
		if(controller.pause)
		{
			//Testa touch
			if(Input.touchCount > 0)
			{
				Touch toque = Input.GetTouch(0);
				if(toque.phase == TouchPhase.Began)
				{
					if(voltar.HitTest(toque.position,Camera.main))
					{
						opt = PauseOptions.voltar;
						tocou = true;
					}
					else if(menu.HitTest(toque.position, Camera.main))
					{
						opt = PauseOptions.menu;
						tocou = true;
					}
					else if(sair.HitTest(toque.position, Camera.main))
					{
						opt = PauseOptions.sair;
						tocou = true;
					}
				}
			}
				
			else if(Input.GetKeyDown(KeyCode.Escape))
			{
				despausa();
			}
			else if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				opt--;
				if((int)opt <0)
					opt = PauseOptions.sair;
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				opt++;
				if((int)opt>2)
					opt = PauseOptions.voltar;
			}
			
			
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
			if(Input.GetKeyDown(KeyCode.Return) || tocou)
			{
				tocou = false;
				switch(opt)
				{
					case PauseOptions.voltar:
						despausa();
						return true;
						break;
					case PauseOptions.menu:
						despausa();
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
				pausa ();
			}
			else if(Input.touchCount > 0)
			{
				if(Input.GetTouch(0).phase == TouchPhase.Began)
				{
					if(pauseButton.HitTest(Input.GetTouch(0).position, Camera.main))
					{
						pausa();	
					}
				}
			}
			
		}
		return false;
	
	}
	public void pausa()
	{
		controller.pause = true;
		Time.timeScale = 0.0f;
		voltar.enabled = true;
		menu.enabled = true;
		sair.enabled = true;
		pauseTop.enabled = true;
		pauseButton.enabled = false;
	}
	public void despausa()
	{
		controller.pause = false;
		Time.timeScale = 1.0f;
		voltar.enabled = false;
		menu.enabled = false;
		sair.enabled = false;
		pauseTop.enabled = false;
		pauseButton.enabled = true;
	}
}

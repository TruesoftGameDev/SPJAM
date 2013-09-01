using UnityEngine;
using System.Collections;

[System.Serializable]
public enum Itens
{
	NovoJogo,
	Continuar,
	Creditos,
	Sair
}

public class MenuInicial : MonoBehaviour {
	
	public GUITexture novoJogo;
	public GUITexture continuar;
	public GUITexture creditos;
	public GUITexture sair;
	public Texture2D[] padrao;
	public Texture2D[] selecionados;
	
	private bool mudou = true;

	public Itens itens = Itens.NovoJogo;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			itens--;
			mudou = true;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			itens++;
			mudou = true;
		}
		if(mudou){
			if((int)itens<0)
				itens = Itens.Sair;
			if((int)itens>3)
				itens= Itens.NovoJogo;
			switch(itens)
			{
				case Itens.NovoJogo:
					novoJogo.texture = selecionados[0];
					continuar.texture = padrao[1];
					creditos.texture = padrao[2];
					sair.texture = padrao[3];
					break;
				case Itens.Continuar:
					novoJogo.texture = padrao[0];
					continuar.texture = selecionados[1];
					creditos.texture = padrao[2];
					sair.texture = padrao[3];
					break;
				case Itens.Creditos:
					novoJogo.texture = padrao[0];
					continuar.texture = padrao[1];
					creditos.texture = selecionados[2];
					sair.texture = padrao[3];
					break;
				case Itens.Sair:
					novoJogo.texture = padrao[0];
					continuar.texture = padrao[1];
					creditos.texture = padrao[2];
					sair.texture = selecionados[3];
					break;			
			}
			mudou = false;
		}
		if(Input.GetKeyDown(KeyCode.Return))
		{
			switch(itens)
			{
				case Itens.NovoJogo:
					if(PlayerPrefs.HasKey("Checkpoint"))
					{
						Application.LoadLevel("Apagar save");
					}
					else
					{
						Application.LoadLevel("Prototipo");
					}
					break;
				case Itens.Continuar:
					if(PlayerPrefs.HasKey("Checkpoint"))
					{
						Application.LoadLevel("Prototipo");
					}
					break;
				case Itens.Creditos:
					
					break;
				case Itens.Sair:
					Application.Quit();
					break;			
			}
		}
	}
}


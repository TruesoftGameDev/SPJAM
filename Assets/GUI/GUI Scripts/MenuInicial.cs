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
	
	public bool ativado = true;
	public bool credito = false;
	
	public GameObject newGame;
	public GameObject cont;
	public GameObject credits;
	public GameObject quit;
	public Texture2D[] padrao;
	public Texture2D[] selecionados;
	private bool mudou = true;

	public Itens itens = Itens.NovoJogo;
	
	private Material novoJogo;
	private Material continuar;
	private Material creditos;
	private Material sair;
	
	public string nomeDaCena = "Inicio";
	
	void Start()
	{
		novoJogo = newGame.GetComponent<Renderer>().material;
		continuar = cont.GetComponent<Renderer>().material;
		creditos = credits.GetComponent<Renderer>().material;
		sair = quit.GetComponent<Renderer>().material;
	}
	
	void Update () {
		if(ativado)	
		{
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
						novoJogo.mainTexture = selecionados[0];
						continuar.mainTexture = padrao[1];
						creditos.mainTexture = padrao[2];
						sair.mainTexture = padrao[3];
						break;
					case Itens.Continuar:
						novoJogo.mainTexture = padrao[0];
						continuar.mainTexture = selecionados[1];
						creditos.mainTexture = padrao[2];
						sair.mainTexture = padrao[3];
						break;
					case Itens.Creditos:
						novoJogo.mainTexture = padrao[0];
						continuar.mainTexture = padrao[1];
						creditos.mainTexture = selecionados[2];
						sair.mainTexture = padrao[3];
						break;
					case Itens.Sair:
						novoJogo.mainTexture = padrao[0];
						continuar.mainTexture = padrao[1];
						creditos.mainTexture = padrao[2];
						sair.mainTexture = selecionados[3];
						break;			
				}
				mudou = false;
			}
			if(credito)
			{
				if(Input.GetKeyDown(KeyCode.Escape))
				{
					ativado = true;
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toMenu();
					credito = false;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Return))
		{
			switch(itens)
			{
				case Itens.NovoJogo:
					if(PlayerPrefs.HasKey("Checkpoint"))
					{
						Debug.Log ("camera");
						GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toNovoJogo();
						this.ativado = false;
						GameObject.FindGameObjectWithTag("NovoJogo").GetComponent<NewGameMenu>().ativado = true;
					}
					else
					{
						Application.LoadLevel(nomeDaCena);
					}
					break;
				case Itens.Continuar:
					if(PlayerPrefs.HasKey(nomeDaCena));
					{
						Application.LoadLevel(2);
					}
					break;
				case Itens.Creditos:
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toCreditos();
					this.ativado = false;
					this.credito = true;
					break;
				case Itens.Sair:
					Application.Quit();
					break;			
			}
		}
	}
}


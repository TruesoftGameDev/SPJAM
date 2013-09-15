using UnityEngine;
using System.Collections;

[System.Serializable]
public enum Itens
{
	NovoJogo,
	Creditos,
	Sair
}

public class MenuInicial : MonoBehaviour {
	
	public bool ativado = true;
	public bool credito = false;
	
	public GameObject newGame;
	public GameObject credits;
	public GameObject quit;
	public Texture2D[] padrao;
	public Texture2D[] selecionados;
	private bool mudou = true;

	public Itens itens = Itens.NovoJogo;
	
	private Material novoJogo;
	private Material creditos;
	private Material sair;
	
	private float delay = 1.0f;
	private bool ativando = false;
	private bool ativandoCreditos = false;
	
	private bool tocou = false;
	
	
	void Start()
	{
		if(PlayerPrefs.GetString("MenuStatus")=="Levels")
		{
			//Debug.Log ("AQUI");
			ativado=false;
			GameObject.FindGameObjectWithTag("MenuTelas").GetComponent<TecladoTelas>().ativado = true;
			PlayerPrefs.SetString("MenuStatus","Normal");
		}
		
		novoJogo = newGame.GetComponent<Renderer>().material;
		creditos = credits.GetComponent<Renderer>().material;
		sair = quit.GetComponent<Renderer>().material;
	}
	
	
	public void TouchNovoJogo()
	{
		itens = Itens.NovoJogo;
		tocou = true;
		mudou = true;
	}
	public void TouchSair()
	{
		itens = Itens.Sair;	
		tocou = true;
		mudou = true;
	}
	public void TouchCreditos()
	{
		itens = Itens.Creditos;
		tocou = true;
		mudou = true;
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
				if((int)itens>2)
					itens= Itens.NovoJogo;
				switch(itens)
				{
					case Itens.NovoJogo:
						novoJogo.mainTexture = selecionados[0];
						creditos.mainTexture = padrao[2];
						sair.mainTexture = padrao[3];
						break;
					
					case Itens.Creditos:
						novoJogo.mainTexture = padrao[0];
						creditos.mainTexture = selecionados[2];
						sair.mainTexture = padrao[3];
						break;
					case Itens.Sair:
						novoJogo.mainTexture = padrao[0];
						creditos.mainTexture = padrao[2];
						sair.mainTexture = selecionados[3];
						break;			
				}
				mudou = false;
			}	
		
		
			if(Input.GetKeyDown(KeyCode.Return) || tocou)
			{
				if(tocou)
					tocou = false;
				switch(itens)
				{
					case Itens.NovoJogo:
						Debug.Log ("camera");
						GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toNovoJogo();
						GameObject.FindGameObjectWithTag("MenuTelas").GetComponent<TecladoTelas>().ativar();
						this.ativado = false;
						break;
					case Itens.Creditos:
						GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toCreditos();
						this.ativado = false;
						ativaCredito();
						break;
					case Itens.Sair:
						Application.Quit();
						break;			
				}
			}
		}
		if(credito)
		{
			if(Input.GetKeyDown(KeyCode.Escape) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
			{
				ativa();
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toMenu();
				credito = false;
			}
		}
		if(ativando)
		{
			if(delay > 0)
			{
				delay -= Time.deltaTime;	
			}
			else
			{
				ativado = true;
				ativando = false;
				delay = 1;
			}
		}
		if(ativandoCreditos)
		{
			if(delay > 0)
			{
				delay -= Time.deltaTime;	
			}
			else
			{
				credito = true;
				ativandoCreditos = false;
				delay = 1;
			}
		}
	}
	
	public void ativa()
	{
		if(!ativado)
		{
			ativando = true;	
		}
	}
	public void ativaCredito()
	{
		
		if(!credito)
		{
			ativandoCreditos = true;	
		}
	}

}


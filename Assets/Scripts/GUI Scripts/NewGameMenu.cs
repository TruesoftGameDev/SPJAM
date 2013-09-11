using UnityEngine;
using System.Collections;

public enum Options
{
	Sim,
	Nao
}

public class NewGameMenu : MonoBehaviour {
	
	public bool ativado = false;
	public GameObject yes;
	public GameObject no;
	public Texture2D[] padrao;
	public Texture2D[] selecionado;
	
	public Options options = Options.Sim;
	
	private Material sim;
	private Material nao;
	
	private bool tocou = false;
	
	void Start()
	{
		sim = yes.renderer.material;
		nao = no.renderer.material;
	}
	
	void Update () {
		if(ativado){
			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				options++;	
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				options--;	
			}
			if((int)options<0)
				options = Options.Nao;
			if((int)options>1)
				options = Options.Sim;
			
			
			switch(options)
			{
				case Options.Sim:
					sim.mainTexture = selecionado[0];
					nao.mainTexture = padrao[1];
					break;
				case Options.Nao:
					nao.mainTexture = selecionado[1];
					sim.mainTexture = padrao[0];
					break;
			}
			
			if(Input.GetKeyDown(KeyCode.Return) || tocou)
			{
				tocou = false;
				switch(options)
				{
					case Options.Sim:
						PlayerPrefs.DeleteAll();
						Application.LoadLevel("Inicio");
						break;
					case Options.Nao:
						GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toMenu();
						this.ativado = false;
						GameObject.FindGameObjectWithTag("MenuInicial").GetComponent<MenuInicial>().ativa();
						break;
				}
			}
		}
	}
	
	public void TouchSim()
	{
		tocou = true;
		options = Options.Sim;
	}
	public void TouchNao()
	{
		tocou = true;
		options = Options.Nao;
	}
}

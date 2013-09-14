using UnityEngine;
using System.Collections;



public class ContinueMenu : MonoBehaviour {
	
	public GameObject yes;
	public GameObject no;
	public Texture2D[] padrao;
	public Texture2D[] selecionado;
	
	public Options options = Options.Sim;
	
	private Material sim;
	private Material nao;
	
	private bool touch;
	
	void Start()
	{
		sim = yes.renderer.material;
		nao = no.renderer.material;
	}
	
	void Update () {
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
		
		if(Input.GetKeyDown(KeyCode.Return) || touch)
		{
			switch(options)
		{
			case Options.Sim:
				Application.LoadLevel(PlayerPrefs.GetString("Tela Atual"));
				break;
			case Options.Nao:
				Application.LoadLevel("Menu inicial");
				break;
		}
		}
	}
	
	public void touchSim()
	{
		options = Options.Sim;
		touch = true;
	}
	public void touchNao()
	{
		options = Options.Nao;
		touch = true;
	}
}

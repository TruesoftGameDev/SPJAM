using UnityEngine;
using System.Collections;



public class ContinueMenu : MonoBehaviour {
	
	public GUITexture sim;
	public GUITexture nao;
	public Texture2D[] padrao;
	public Texture2D[] selecionado;
	
	public Options options = Options.Sim;
	
	
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
				sim.texture = selecionado[0];
				nao.texture = padrao[1];
				break;
			case Options.Nao:
				nao.texture = selecionado[1];
				sim.texture = padrao[0];
				break;
		}
		
		if(Input.GetKeyDown(KeyCode.Return))
		{
			switch(options)
		{
			case Options.Sim:
				PlayerPrefs.DeleteAll();
				Application.LoadLevel("Tela01/inicial");
				break;
			case Options.Nao:
				Application.LoadLevel("Menu inicial");
				break;
		}
		}
	}
}

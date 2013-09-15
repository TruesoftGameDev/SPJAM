using UnityEngine;
using System.Collections;

public class TecladoTelas : MonoBehaviour {

	public GameObject[] telas;
	public int selecionado;
	public bool ativado = false;
	bool ativando = false;
	private float delay = 1.0f;
	
	void Start () {
	
	}
	
	
	void Update () {
		if(ativado)
		{
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				selecionado--;
				if(selecionado < 0)
					selecionado = telas.Length-1;
			}
			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				selecionado++;
				if(selecionado > telas.Length-1)
					selecionado = 0;
			}
			if(Input.GetKeyDown(KeyCode.Return))
				telas[selecionado].SendMessage("touch");
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				GameObject.FindGameObjectWithTag("MenuInicial").GetComponent<MenuInicial>().ativa();
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuCamera>().toMenu();
				ativado = false;
				
			}
			
			foreach(GameObject a in telas)
			{
				a.SendMessage("deselecionar");	
			}
			telas[selecionado].SendMessage("selecionar");
		}
		else if(ativando)
		{
			if(delay > 0)
				delay-=Time.deltaTime;
			else
			{
				delay = 1.0f;
				ativado = true;
				ativando = false;
			}
		}
		
	}
	public void ativar()
	{
		ativando = true;
	}
}

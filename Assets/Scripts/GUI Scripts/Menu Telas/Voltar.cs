using UnityEngine;
using System.Collections;

public class Voltar : MonoBehaviour {

	public Texture2D padrao;
	public Texture2D selected;
	
	private bool selecionado;
	
	// Update is called once per frame
	void Update () {
		if(selecionado)
			renderer.material.mainTexture = selected;
		else
			renderer.material.mainTexture = padrao;
	}
	public void voltar()
	{
		selecionado = true;
	}
	public void soltar()
	{
		selecionado = false;	
	}
}

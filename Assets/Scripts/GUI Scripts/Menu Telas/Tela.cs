using UnityEngine;
using System.Collections;

public class Tela : MonoBehaviour {

	public string nomeDaTela;
	public Renderer NumOrbs;
	public Renderer Orb;
	
	public Texture2D normal;
	public Texture2D selecionado;
	public Texture2D completo;
	
	private bool completa = false;
	
	public bool isSelected = false;
	private bool touched = false;
	
	void Start () {
		string status = PlayerPrefs.GetString(nomeDaTela+"Status");
		//Debug.Log (status);
		//Debug.Log (nomeDaTela+"Status");
		/*switch(status)
		{
			case "Completa":
				completa = true;
				NumOrbs.enabled = true;
				Orb.enabled = true;
				NumOrbs.gameObject.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(nomeDaTela+"Recorde").ToString();
				break;
			default:
				completa = false;
				NumOrbs.enabled = false;
				Orb.enabled = false;
				break;
		}*/
		
		
		if(status == "Completa")
		{
			completa = true;
			NumOrbs.enabled = true;
			Orb.enabled = true;
			NumOrbs.gameObject.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(nomeDaTela+"Recorde").ToString();
		}
		else
		{
			completa = false;
			NumOrbs.enabled = false;
			Orb.enabled = false;
		}
	
	}
	
	void Update () {
		
		if(isSelected)
		{
			renderer.material.mainTexture = selecionado;
			NumOrbs.gameObject.GetComponent<TextMesh>().color = Color.black;
		}
		else if(completa)
		{
			renderer.material.mainTexture = completo;
			NumOrbs.gameObject.GetComponent<TextMesh>().color = Color.white;
		}
		else
		{
			renderer.material.mainTexture = normal;
			NumOrbs.gameObject.GetComponent<TextMesh>().color = Color.black;
		}
		
		
	
	}
	public void touch()
	{
		Application.LoadLevel(nomeDaTela);	
	}
	public void selecionar()
	{
		isSelected = true;
	}
	public void deselecionar()
	{
		isSelected = false;	
	}
}

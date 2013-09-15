using UnityEngine;
using System.Collections;

public class FimDeTela : MonoBehaviour {

	public float tempo;
	private float tp;
	public bool isRecord = false;
	public GameObject RecordeObj;
	public GameObject RecordeAtualTextObj;
	public GameObject PontuacaoObj;
	
	
	private Renderer Recorde;
	private TextMesh RecordeAtualText;
	private TextMesh Pontuacao;
	
	void Start () {
		tp = tempo;
		Recorde = RecordeObj.GetComponent<Renderer>();
		RecordeAtualText = RecordeAtualTextObj.GetComponent<TextMesh>();
		Pontuacao = PontuacaoObj.GetComponent<TextMesh>();
		
		
		string tela = PlayerPrefs.GetString("Nivel Atual");
		//Debug.Log(tela);
		int valPontuacao = PlayerPrefs.GetInt(tela+"OrbsTemp");
		//Debug.Log (valPontuacao);
		int valRecorde = PlayerPrefs.GetInt(tela+"Recorde",0);
		if(!PlayerPrefs.HasKey(tela+"Recorde") || valPontuacao>valRecorde)
		{
			Recorde.enabled = true;
			Pontuacao.text = valPontuacao.ToString();
			RecordeAtualText.text = valPontuacao.ToString();
			PlayerPrefs.SetInt(tela+"Recorde",valPontuacao);
		}
		else
		{
			Recorde.enabled = false;
			Pontuacao.text = valPontuacao.ToString();
			RecordeAtualText.text = valRecorde.ToString();
		}
		
		PlayerPrefs.SetString(tela+"Status","Completa");
		
		PlayerPrefs.SetString("MenuStatus","Levels");
		//Debug.Log (PlayerPrefs.GetString(tela+"Status"));
		//Debug.Log(tela+"Status");
	}
	
	
	// Update is called once per frame
	void Update () {
		tp -= Time.deltaTime;
		if(tp<0)
		{
			Application.LoadLevel("Menu inicial");	
		}
		if(Input.GetKeyDown(KeyCode.Delete))
			PlayerPrefs.DeleteAll();
	}
}

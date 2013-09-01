using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	AttributesController controller;
	public GUIText OrbGUIText;
	public GUIText LifeGUIText;
	
	void Start()
	{
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<AttributesController>();	
	}
	
	
	// Update is called once per frame
	void Update () {
		OrbGUIText.text = controller.orbs.ToString();
		LifeGUIText.text = controller.vidas.ToString();
	}
}

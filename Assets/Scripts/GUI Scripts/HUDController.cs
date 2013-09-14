using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	AttributesController controller;
	public GUIText OrbGUIText;
	
	void Start()
	{
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<AttributesController>();	
	}
	
	
	// Update is called once per frame
	void Update () {
		OrbGUIText.text = controller.orbs.ToString();
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float velocidade = 3.0f;
	public float pulo = 8.0f;
	public float gravidade = 20.0f;
	private Vector3 movimento;
	public int perspectiva = 1;
	public GameObject cameraSideRun;
	public GameObject cameraTopRun;
	
	void Start () {
		if(perspectiva == 1)
		{
			toSideCamera();
		}
		else if(perspectiva == 2)
		{
			toTopCamera();
		}
		else
		{
			Debug.Log ("Erro camera");	
		}
		
		
	}
	
	
	void Update () {
		
		
		
		//Garante que sempre fique na posiçao 0 do eixo X;
		transform.position = new Vector3(0,transform.position.y, transform.position.z);	
		
		CharacterController characterController = GetComponent<CharacterController>();
		
		if(characterController.isGrounded)
		{
			movimento = Vector3.back;
			movimento = transform.TransformDirection(movimento);
			movimento *= velocidade;
			if(Input.GetKey(KeyCode.UpArrow))
			{
                movimento.y = pulo;
			}
			
		}
		movimento.y -= gravidade*Time.deltaTime;
		characterController.Move(movimento);
	}
	
	
	
	//Teste de colisoes de morte, troca de camera
	void OnControllerColliderHit(ControllerColliderHit colisor)
	{
		
		if(colisor.collider.gameObject.tag == "DeathCollider")
		{
			Debug.Log ("Entrou");
			SendMessage("Dead");
		}
	}
	private void toSideCamera(){
		cameraSideRun.camera.enabled = true;
		cameraTopRun.camera.enabled = false;
	}
	private void toTopCamera(){
		cameraSideRun.camera.enabled = false;
		cameraTopRun.camera.enabled = true;
	}
}

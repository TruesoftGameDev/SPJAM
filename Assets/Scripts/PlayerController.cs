using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float velocidade = 3.0f;
	public bool canJump = true;
	public bool jumping = false;
	public bool doubleJump = false;
	public float pulo = 8.0f;
	public float gravidade = 20.0f;
	public float velocidadeLateral = 0.5f;
	public bool rasteira = false;
	public float tempoRasteira = 1.0f;
	public  float tmpRasteira;
	
	private Vector3 movimento;
	public int perspectiva = 1;
	public GameObject cameraSideRun;
	public GameObject cameraTopRun;
	
	void Start () {
		switch(perspectiva){
			case 1:
				toSideCamera();
				break;
			case 2:
				toTopCamera();
				break;
			default:
				Debug.Log ("Erro cameras!");
				break;
		}
		tmpRasteira = tempoRasteira;
		
	}
	
	
	void Update () {
		
		
		CharacterController characterController = GetComponent<CharacterController>();
		//Movimenta o personagem para frente
		movimento = Vector3.forward;
		movimento = transform.TransformDirection(movimento);
		movimento *= velocidade;
		switch(perspectiva)
		{
			case 1:
				//Garante que sempre fique na posiçao 0 do eixo X;
				transform.position = new Vector3(0,transform.position.y, transform.position.z);	
				
				if(characterController.isGrounded)
				{
					canJump = true;
					doubleJump = false;
					jumping = false;
					if(rasteira == true)
					{
						if(tmpRasteira >= 0)
						{
							tmpRasteira -= Time.deltaTime;
						}
						else
						{
							rasteira = false;
							transform.localScale = new Vector3(1,1,1);
							transform.position = new Vector3(transform.position.x, 1,transform.position.z);
						}
					}
					
				
					if(Input.GetKey(KeyCode.DownArrow)&& !rasteira)
					{
						rasteira = true;
						transform.localScale*=0.5f;
						canJump = false;
					}
					
				}
				if(Input.GetKeyDown(KeyCode.UpArrow) && (canJump))
				{
	                movimento.y = pulo;
					if(jumping)
					{
						doubleJump = true;
						canJump = false;
					}
					else
					{
						jumping = true;
					}	
				}
				break;
			case 2:
				
				if(Input.GetKey(KeyCode.LeftArrow))
				{
					movimento += Vector3.left*velocidadeLateral;
				}
				if(Input.GetKey(KeyCode.RightArrow))
				{
					movimento += Vector3.right*velocidadeLateral;
				}
				
				break;
			
			default:
				Debug.Log ("Erro, perpectiva inexistente!");
				break;
		}
		movimento.y -= gravidade*Time.deltaTime;
		characterController.Move(movimento);
	}
	void trocaPerspectiva(int codPerspectiva)
	{
		switch(codPerspectiva)
		{
			case 1:
				toSideCamera();
				this.perspectiva = 1;
				break;
			case 2:
				toTopCamera();
				this.perspectiva = 2;
				break;
			default:
				
				break;
		}
	}
	
	//Teste de colisoes de morte, troca de camera
	void OnControllerColliderHit(ControllerColliderHit colisor)
	{
		
		switch(colisor.collider.gameObject.tag)
		{
			case "DeathCollider":
				SendMessage("Dead");
				break;
			case "Perspectiva1":
				trocaPerspectiva(1);
				colisor.collider.enabled = false;
				break;
			case "Perspectiva2":
				trocaPerspectiva(2);
				colisor.collider.enabled = false;
				break;
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

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
	public bool pause = false;
	
	private Vector3 movimento;
	public int perspectiva = 1;
	public GameObject cameraSideRun;
	public GameObject cameraTopRun;
	
	void Start () {
		
		animation["Run"].speed = 3.0f;
		animation["Sliding"].speed = 3.0f;
		
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
		
		if(!pause){		
			CharacterController characterController = GetComponent<CharacterController>();
			//Movimenta o personagem para frente
			movimento = Vector3.forward;
			movimento = transform.TransformDirection(movimento);
			movimento *= velocidade;
			switch(perspectiva)
			{
				case 1:
					atualizaPerspectiva1(characterController);
					break;
				case 2:
					atualizaPerspectiva2(characterController);
					break;
				
				default:
					Debug.Log ("Erro, perpectiva inexistente!");
					break;
			}
			movimento.y -= gravidade*Time.deltaTime;
			characterController.Move(movimento);
			}
	}
	public void trocaPerspectiva(int codPerspectiva)
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
	
	private void atualizaPerspectiva1(CharacterController characterController)
	{
		//Garante que sempre fique na posiçao 0 do eixo X;
		transform.position = new Vector3(0,transform.position.y, transform.position.z);	
		
		if(characterController.isGrounded)
		{
			canJump = true;
			doubleJump = false;
			jumping = false;
		
			
			;
		
			if(rasteira == true)
			{
				if(tmpRasteira >= 0)
				{
					tmpRasteira -= Time.deltaTime;
				}
				else
				{
					rasteira = false;
					transform.position = new Vector3(transform.position.x, 2.5f,transform.position.z);
					characterController.center = new Vector3(characterController.center.x, 0.08f, characterController.center.z);
					animation.CrossFade("Run",1.5f);
					characterController.height *=15;
					
				}
			}
			else
				animation.Play("Run");
			
		
			if(Input.GetKey(KeyCode.DownArrow)&& !rasteira)
			{
				rasteira = true;
				characterController.height /=15;
				characterController.center = new Vector3(characterController.center.x, 0.70f, characterController.center.z);
				canJump = false;
				animation.Play("Sliding",PlayMode.StopAll);
			}
			
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) && (canJump))
		{
            movimento.y = pulo;
			if(jumping)
			{
				doubleJump = true;
				canJump = false;
				animation.Play("DoubleJump",PlayMode.StopAll);
			}
			else
			{
				jumping = true;
				animation.Play("Jump",AnimationPlayMode.Mix);
			}	
		}
	}
	private void atualizaPerspectiva2(CharacterController characterController)
	{
		Renderer r = gameObject.GetComponentInChildren<Renderer>();
		if(!animation.isPlaying)
				animation.Play("Run");
		
		Debug.Log(r.transform.position.x);
		
		if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -11)
		{
			movimento += Vector3.left*velocidadeLateral;
		}
		if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 11)
		{
			movimento += Vector3.right*velocidadeLateral;
		}
	}
	
	//Teste de colisoes de morte, troca de camera
	void OnControllerColliderHit(ControllerColliderHit colisor)
	{
		
		switch(colisor.collider.gameObject.tag)
		{
			case "DeathCollider":
				SendMessage("DeadCollider");
				
				break;
			case "Perspectiva1":
				trocaPerspectiva(1);
				colisor.collider.enabled = false;
				break;
			case "Perspectiva2":
				trocaPerspectiva(2);
				colisor.collider.enabled = false;
				break;
			case "Checkpoint":
				Checkpoint ck = colisor.gameObject.GetComponent<Checkpoint>();
				Checkpoints controller = GameObject.FindGameObjectWithTag("CheckpointController").GetComponent<Checkpoints>();
				controller.gravaCheckpoint(ck.id);
				colisor.collider.enabled = false;
				break;
		}
	}
	private void toSideCamera(){
		cameraSideRun.SetActive(true);
		cameraTopRun.SetActive(false);
	}
	private void toTopCamera(){
		cameraSideRun.SetActive(false);
		cameraTopRun.SetActive(true);
	}
}

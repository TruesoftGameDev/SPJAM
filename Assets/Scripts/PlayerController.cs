using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	//Velocidade
	public float velocidade = 3.0f;
	//Velocidade lateral (Perspectiva 2)
	public float velocidadeLateral = 0.5f;
	
	//Pulo
	public bool canJump = true;
	public bool jumping = false;
	public bool doubleJump = false;
	public float pulo = 8.0f;
	//Gravidade
	public float gravidade = 20.0f;
	
	//Rasteira
	/*
	public bool rasteira = false;
	public float tempoRasteira = 1.0f;
	public  float tmpRasteira;
	*/
	//Pause
	public bool pause = false;
	
	//Proximo movimento
	private Vector3 movimento;
	//Cameras
	public int perspectiva = 1;
	public GameObject cameraSideRun;
	public GameObject cameraTopRun;
	
	//Som de pulo
	public AudioSource jumpSound;
	
	//Touch
	private bool touching = false;
	
	void Start () {
		
		//Define velocidade de animaçao
		animation["Run"].speed = 3.0f;
		animation["Sliding"].speed = 3.0f;
		
		//Atualiza perspectiva
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
		//tmpRasteira = tempoRasteira;
		
	}
	
	
	void Update () {
		
		//Gerencia movimentaçao
		if(!pause){		
			CharacterController characterController = GetComponent<CharacterController>();
			//Movimenta o personagem para frente
			movimento = Vector3.forward;
			movimento = transform.TransformDirection(movimento);
			movimento *= velocidade;
			//Atualiza movimentaçao e checa controles de acordo com a perspectiva
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
			//Aplica gravidade
			movimento.y -= gravidade*Time.deltaTime;
			//Aplica movimentaçao
			characterController.Move(movimento);
			}
	}
	//Troca perspectiva
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
		//Chega toques
		if(Input.touchCount > 0)
		{
			touching = true;	
			
		}
		else
		{
			touching = false;	
		}
		
		
		//Se estiver no chao, passa para animaçao de corrida
		if(characterController.isGrounded)
		{
			canJump = true;
			doubleJump = false;
			jumping = false;
			
			
			animation.Play("Run");
			
			/*
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
			*/
		}
		
		//Roda animaçao de queda 
		else if(!jumping)
		{
			animation.Play("DoubleJump");
		}
		
		//Gerencia controles de pulo
		if((Input.GetKeyDown(KeyCode.UpArrow) || (touching && Input.GetTouch(0).phase == TouchPhase.Began)) && (canJump) )
		{
            //Pulo duplo
			if(jumping)
			{
				Debug.Log ('D');
				doubleJump = true;
				canJump = false;
				animation.Play("DoubleJump",PlayMode.StopAll);
				Instantiate(jumpSound);
				touching = false;
				movimento.y = pulo;
			}
			//Pulo
			else if(!jumping)
			{
				Instantiate(jumpSound);
				jumping = true;
				animation.Play("Jump",AnimationPlayMode.Mix);
				Debug.Log ('S');
				movimento.y = pulo;
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
			case "Portal":
				Application.LoadLevel("Final");
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

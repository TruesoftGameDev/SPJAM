using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {
	
	
	public Transform target;
	public float speed = 20;
	
	public Transform menuInicial;
	public Transform novoJogo;
	public Transform creditos;
	
	

	void Start()
	{
		transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
	}
	
	void Update () {
		float temp =target.position.x-transform.position.x;
		
		if(temp > 1.5f || temp < -1.5f)
		{
			if(target.position.x > transform.position.x)
			{
				if(speed*Time.deltaTime > temp)
					transform.position += (Vector3.right*speed*Time.deltaTime)/1000;
				else
					transform.position += (Vector3.right*speed*Time.deltaTime);	
			}
			else
			{
				if(speed*Time.deltaTime < temp)
					transform.position += (Vector3.left*speed*Time.deltaTime)/1000;	
				else
					transform.position += (Vector3.left*speed*Time.deltaTime);	
			}
		}
	}
	public void toMenu()
	{
		target = menuInicial;	
	}
	public void toNovoJogo()
	{
		target = novoJogo;
	}
	public void toCreditos()
	{
		target = creditos;
	}
	
}

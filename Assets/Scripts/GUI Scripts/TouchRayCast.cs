using UnityEngine;
using System.Collections;


public class TouchRayCast : MonoBehaviour {
	public string mensagemToque;
	public string mensagemMovendo;
	public string mensagemFimToque;
	
	public string tagDoAlvo;
	
	void Update () {
		if(Input.touchCount>0)
		{
			foreach(Touch a in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay(a.position);
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(ray,out hit))
				{
					if(hit.collider.tag == tagDoAlvo)
					{
						switch(a.phase)
						{
							case TouchPhase.Began:
								transform.parent.SendMessage(mensagemToque,SendMessageOptions.DontRequireReceiver);
								gameObject.SendMessage(mensagemToque,SendMessageOptions.DontRequireReceiver);
								break;
							case TouchPhase.Moved:
								transform.parent.SendMessage(mensagemMovendo,SendMessageOptions.DontRequireReceiver);
								gameObject.SendMessage(mensagemMovendo,SendMessageOptions.DontRequireReceiver);
								break;
							case TouchPhase.Canceled:
								transform.parent.SendMessage(mensagemFimToque,SendMessageOptions.DontRequireReceiver);
								gameObject.SendMessage(mensagemFimToque,SendMessageOptions.DontRequireReceiver);
								break;
						}
					}
				}	
			}
		}
	}
}

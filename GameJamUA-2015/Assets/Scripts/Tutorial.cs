using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	public GameObject chainedTutorial;

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Salchicha")
		{
			if(chainedTutorial)
			{
				chainedTutorial.SetActive(true);
			}

			Destroy(gameObject);
		}
	}
}

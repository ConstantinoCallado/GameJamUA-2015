using UnityEngine;
using System.Collections;

public class CocineroBehaviour : MonoBehaviour {

    private bool cambioGiro = false;
    Salchicha player = Salchicha.playerRef;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        foreach(Transform centinela in GetComponentsInChildren<Transform>())
        {
            Debug.DrawRay(transform.position, (centinela.position - transform.position), Color.red);
        }

        if (!cambioGiro)
        {
            transform.Rotate(Vector3.up, 1f);
            if (transform.eulerAngles.y >= 88f && transform.eulerAngles.y <= 92f)
                cambioGiro = true;
        }
        else       //Umbrales sucios para detectar cambio de direccion  
        {
            transform.Rotate(Vector3.up, -1f);
            if (transform.eulerAngles.y >= 268f && transform.eulerAngles.y <= 272f)
                cambioGiro = false;
        }

        if (player.transform.position.z > GameObject.Find("CentinelaIzq").transform.position.z &&
            player.transform.position.z < GameObject.Find("CentinelaDer").transform.position.z)
            Debug.Log("MUERE!!!!");
	}
}

using UnityEngine;
using System.Collections;

public class CocineroBehaviour : MonoBehaviour {

    private bool cambioGiro = false;
    Salchicha player;
    private Centinela[] centinelas = new Centinela[2];
	// Use this for initialization
	void Awake () {

        player = Salchicha.playerRef;
        centinelas = GetComponentsInChildren<Centinela>();
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

        if (player.transform.position.z > centinelas[0].transform.position.z &&
            player.transform.position.z < centinelas[1].transform.position.z)
            Debug.Log("MUERE!!!!");
	}
}

using UnityEngine;
using System.Collections;

public class CocineroBehaviour : MonoBehaviour {

    private bool cambioGiro = false;
    public float velocidadGiro = 0.5f;
	
	// Update is called once per frame
	void Update () {

        if (!cambioGiro)
        {
            transform.Rotate(Vector3.up, velocidadGiro);
            if (transform.eulerAngles.y >= 88f && transform.eulerAngles.y <= 92f)
                cambioGiro = true;
        }
        else       //Umbrales sucios para detectar cambio de direccion  
        {
            transform.Rotate(Vector3.up, -velocidadGiro);
            if (transform.eulerAngles.y >= 268f && transform.eulerAngles.y <= 272f)
                cambioGiro = false;
        }

	}
}

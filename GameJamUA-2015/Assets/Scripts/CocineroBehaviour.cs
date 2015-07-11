using UnityEngine;
using System.Collections;

public class CocineroBehaviour : MonoBehaviour {

    private bool cambioGiro = false;
    public float velocidadGiro = 30f;
	public float cantidadGiro = 90;

	// Update is called once per frame
	void Update () {

        if (!cambioGiro)
        {
            transform.Rotate(Vector3.up, velocidadGiro * Time.deltaTime);
			if (transform.eulerAngles.y >= cantidadGiro -2  && transform.eulerAngles.y <= cantidadGiro + 2)
                cambioGiro = true;
        }
        else       //Umbrales sucios para detectar cambio de direccion  
        {
			transform.Rotate(Vector3.up, -velocidadGiro * Time.deltaTime);
			if (transform.eulerAngles.y >= (360 - cantidadGiro) - 2 && transform.eulerAngles.y <= (360 - cantidadGiro) + 2)
                cambioGiro = false;
        }

	}
}

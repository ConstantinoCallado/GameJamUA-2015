using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {

    public Transform target;
    private LineRenderer linea;

	// Use this for initialization
	void Awake () {

        linea = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        linea.SetPosition(0, transform.position);
        linea.SetPosition(1, target.position);
	}
}

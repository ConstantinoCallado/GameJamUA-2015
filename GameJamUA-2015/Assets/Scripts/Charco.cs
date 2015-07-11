using UnityEngine;
using System.Collections;

public class Charco : MonoBehaviour {

    public Object charco;
    public GameObject agua;

    private bool derramado = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Encimera" && !derramado)
        {
            Vector3 posToSpawn = GetComponent<Collider>().transform.position;
            GameObject aux = (GameObject)Instantiate(charco,new Vector3(posToSpawn.x,other.transform.position.y+0.157f,posToSpawn.z),Quaternion.Euler(new Vector3(90,0,0)));
            Vector3 finalScale = aux.transform.localScale;
            aux.transform.localScale = Vector3.zero;
            derramado = true;
            Destroy(agua);
            StartCoroutine(Derramando(aux,finalScale));
        }
    }

    IEnumerator Derramando(GameObject aux,Vector3 finalScale)
    {
        while(aux.transform.localScale.sqrMagnitude < finalScale.sqrMagnitude)
        {
            aux.transform.localScale += Vector3.one * 0.1f * Time.deltaTime;
            yield return new WaitForEndOfFrame();

        }
    }
}


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Salchicha : MonoBehaviour 
{
	public Rigidbody rigidBodyDerecha;
	public Rigidbody rigidBodyIzquierda;
    public static Salchicha playerRef;
	public List<Toxico> listaSucia = new List<Toxico>();
	const float fuerza = 200;

	const float toxicidadMaxima = 100; 
	public float toxicidadActual = 0;

	public Slider sliderToxicidad;

	public Renderer rendererSalchicha;
	public SkinnedMeshRenderer meshRenderer;

	public Texture spriteWASD;
	public Texture spriteFlechas;

	public Transform centroTextoL;
	public Transform centroTextoR;

	private bool isCortado = false;
	public Mesh meshCortado;
	public CharacterJoint juntaACortar1;
	public CharacterJoint juntaACortar2;

	public bool respawning = false;

    void Awake()
    {
        playerRef = this;
    }

	void Update () 
	{
		sliderToxicidad.value = toxicidadActual / toxicidadMaxima;
		checkUserInput();

		if(rigidBodyDerecha.transform.position.y < -1 && !respawning)
		{
			StartCoroutine(corutinaRespawn(1.5f));
		}
	}

	private void checkUserInput()
	{
		if(Input.GetKey(KeyCode.A))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, fuerza * Time.deltaTime));
		}
		else if(Input.GetKey(KeyCode.D))
		{
			rigidBodyIzquierda.AddForce(new Vector3(0, 0, -fuerza * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.W))
		{
			rigidBodyIzquierda.AddForce(new Vector3(fuerza * Time.deltaTime, 0, 0));
		}
		else if(Input.GetKey(KeyCode.S))
		{
			rigidBodyIzquierda.AddForce(new Vector3(-fuerza * Time.deltaTime, 0, 0));
		}
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, fuerza * Time.deltaTime));
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(0, 0, -fuerza * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(fuerza * Time.deltaTime, 0, 0));
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			rigidBodyDerecha.AddForce(new Vector3(-fuerza * Time.deltaTime, 0, 0));
		}
	}

    public void RemoveRandomShit()
    {
		int randomIndex = Random.Range(0, listaSucia.Count);
        
		if(listaSucia.Count>0)
		{
			if(listaSucia[randomIndex] != null)
			{
				toxicidadActual -= listaSucia[randomIndex].toxicidad;
				Destroy(listaSucia[randomIndex].gameObject); 
			}
			listaSucia.RemoveAt(randomIndex);
    	}
	}

	public void OnGUI()
	{
		float scale = Screen.width / 600;
		Vector2 position = Camera.main.WorldToScreenPoint(centroTextoL.position);
		GUI.DrawTexture(new Rect(position.x - (scale * spriteWASD.width / 2) , Screen.height - (position.y + (scale * spriteWASD.height /2)), scale * spriteWASD.width, scale * spriteWASD.height), spriteWASD);
	
		position = Camera.main.WorldToScreenPoint(centroTextoR.position);
		GUI.DrawTexture(new Rect(position.x - (scale * spriteFlechas.width / 2), Screen.height - (position.y + (scale * spriteFlechas.height / 2)), scale * spriteFlechas.width, scale * spriteFlechas.height), spriteFlechas);
	}

	public void Cortar ()
	{
		if(!respawning)
		{
			meshRenderer.sharedMesh = meshCortado;
			Destroy (juntaACortar1);
			Destroy (juntaACortar2);
			isCortado = true;
			StartCoroutine(corutinaRespawn(1.5f));
		}
	}

	public void Kill()
	{
		Bandeja.bandejaRef.Respawn();
		DestroyImmediate(gameObject);
	}

	public IEnumerator corutinaRespawn(float tiempo)
	{
		respawning = true;

		yield return new WaitForSeconds(tiempo);

		Kill();
	}
}

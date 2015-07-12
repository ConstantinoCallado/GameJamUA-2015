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
	
	public float toxicidadActual = 0;

	public Slider sliderToxicidad;

	public Renderer rendererSalchicha;
	public SkinnedMeshRenderer meshRenderer;
    public Mesh salchichaElec;
	public Texture spriteWASD;
	public Texture spriteFlechas;
    public Material materialElec;

	public Transform centroTextoL;
	public Transform centroTextoR;

	private bool isCortado = false;
    private bool isElectrocutado = false;
    private bool isQuemado = false;

	public Mesh meshCortado;
	public CharacterJoint juntaACortar1;
	public CharacterJoint juntaACortar2;

	public bool respawning = false;

	private float toxicidadMaxima;

	public bool showUI = true;

    void Awake()
    {
		showUI = true;
        playerRef = this;
    }

	void Start()
	{
		toxicidadMaxima = LevelManager.GetToxicidad();
	}


	void Update () 
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}

		sliderToxicidad.value = toxicidadActual / toxicidadMaxima;

        if(!isElectrocutado)
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

		SoundManager.soundManagerRef.audioRodar.volume = (rigidBodyDerecha.velocity.sqrMagnitude + rigidBodyIzquierda.velocity.sqrMagnitude);
	}

    public void RemoveRandomShit()
    {
		SoundManager.soundManagerRef.audioLimpiar.Play();

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
		if(showUI)
		{
			double scale = Screen.height / 1000.0;
		
			Vector2 position = Camera.main.WorldToScreenPoint(centroTextoL.position);
			GUI.DrawTexture(new Rect((float)(position.x - (scale * spriteWASD.width / 2)), 
			                         (float)(Screen.height - (position.y + (scale * spriteWASD.height /2))), (float)(scale * spriteWASD.width), 

			                         (float)(scale * spriteWASD.height)), spriteWASD);
		
			position = Camera.main.WorldToScreenPoint(centroTextoR.position);
			GUI.DrawTexture(new Rect((float)(position.x - (scale * spriteFlechas.width / 2)), (float)(Screen.height - (position.y + (scale * spriteFlechas.height / 2))), (float) (scale * spriteFlechas.width), (float)(scale * spriteFlechas.height)), spriteFlechas);
		}
	}

	public void Cortar ()
	{
		if(!respawning)
		{
			SoundManager.soundManagerRef.audioCortar.Play();
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

    public void Electrocutar()
    {
        if(!isElectrocutado)
        {
			SoundManager.soundManagerRef.audioElect.Play();
            isElectrocutado = true;
            StartCoroutine(Electrificar());
            
            StartCoroutine(corutinaRespawn(1.3f));
        }
    }

    public IEnumerator Electrificar()
    {
        //Mesh auxMesh = meshRenderer.sharedMesh;
        Material auxMat = meshRenderer.material;

        int zaps = 0;
        while(zaps < 5)
        {
           //meshRenderer.sharedMesh = salchichaElec;
            meshRenderer.material = materialElec;
            yield return new WaitForSeconds(0.1f);
            //meshRenderer.sharedMesh = auxMesh;
            meshRenderer.material = auxMat;
            yield return new WaitForSeconds(0.1f);
            zaps++;
        }
    }

    public void Quemar()
    {
        if (!isQuemado)
        {
            isQuemado = true;
            StartCoroutine(Quemazon());

            StartCoroutine(corutinaRespawn(1.3f));
        }
    }

    public IEnumerator Quemazon()
    {
        Material mat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;

        while(true)
        {
            mat.color = Color.Lerp(mat.color, Color.black, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }
    }

	public void Freeze(Transform parent)
	{
		transform.parent = parent;
		rigidBodyDerecha.isKinematic = true;
		rigidBodyIzquierda.isKinematic = true;
	}
}

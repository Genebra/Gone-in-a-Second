using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpriteClick2 : MonoBehaviour
{
	private string HighlightName;
	private Sprite HighlightedSprite;
	private Sprite NormalSprite;
	public Texture BoxTexture;
	private float x, y, z;
	public bool showGUI = false;
	private Sprite sp;
	private SpriteRenderer sr;
	public static float oldCameraOrthoSize;
	public static Vector3 oldCameraPosition;
	private Camera camera;
	public static bool ZoomedIn = false;
	private static GameObject[] sprites;
	public static GameObject ProgressBar;
	public static GameObject VisitButton;
	public static GameObject BackButton;
	public static GameObject Followers;
    public static GameObject Logo;
    public static GameObject FactionManager;

	void OnLeftClick()
	{
		foreach(var sprite in sprites)
		{
			sprite.GetComponent<SpriteClick2>().showGUI = false;
		}
		VisitButton.SetActive(true);
		BackButton.SetActive(true);
		ProgressBar.SetActive(false);
		Followers.SetActive(false);
        Logo.SetActive(false);
        FactionManager.SetActive(false);
        GameObject.Find("BarFill").GetComponent<UnityEngine.UI.Image>().enabled = false;
        GameObject.Find("FollowersNumber").GetComponent<UnityEngine.UI.Text>().enabled = false;
        showGUI = true;
		//ZoomedIn = true;
		x = this.transform.position.x;
		y = this.transform.position.y;
		z = camera.transform.position.z;
		camera.orthographicSize = 2.5f;
		camera.transform.position = new Vector3(x, y, z);
		VisitButton.transform.position = new Vector3(0, 0, 0);
		BackButton.transform.position = new Vector3(0, 0, 0);
		if (this.gameObject.name == "Church")
		{
			VisitButton.transform.Translate(new Vector3(-4.20f, 1.7f, 0));
			BackButton.transform.Translate(new Vector3(-3.20f, 1.7f, 0));
			VisitButton.GetComponent<VisitScript2>().sceneToLoad = "InsideChurch2";
		}
		else if (this.gameObject.name == "HeadquartersExterior")
		{
			VisitButton.transform.Translate(new Vector3(2.9f, -1.37f, 0));
			BackButton.transform.Translate(new Vector3(3.9f, -1.37f, 0));
			VisitButton.GetComponent<VisitScript2>().sceneToLoad = "InsideHeadquarters";
		}
		else if (this.gameObject.name == "PoliticianBuilding")
		{
			VisitButton.transform.Translate(new Vector3(-0.85f, .36f, 0));
			BackButton.transform.Translate(new Vector3(.15f, .36f, 0));
			VisitButton.GetComponent<VisitScript2>().sceneToLoad = "InsideParliament2";
		}else if( this.gameObject.name == "CultistIsland")
        {
            VisitButton.transform.Translate(new Vector3(4.9f, 3.42f, 0));
            BackButton.transform.Translate(new Vector3(5.9f, 3.42f, 0));
            VisitButton.GetComponent<VisitScript2>().sceneToLoad = "InsideCult2";
        }else if (this.gameObject.name == "MilitaryExterior")
        {
            VisitButton.transform.Translate(new Vector3(-8.4f, -2.33f, 0));
            BackButton.transform.Translate(new Vector3(-7.4f, -2.33f, 0));
            VisitButton.GetComponent<VisitScript2>().sceneToLoad = "InsideMilitary2";
        }
    }

	void OnMouseOver()
	{
		if(this.HighlightedSprite != null)
			this.GetComponent<SpriteRenderer>().sprite = this.HighlightedSprite;
	}

	void OnMouseExit()
	{
		if(this.NormalSprite != null)
			this.GetComponent<SpriteRenderer>().sprite = this.NormalSprite;
	}


	void OnGUI()
	{
        GUI.depth = 1;
		if (showGUI)
		{
            
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
			//get sprite size
			Vector3 topLeft = transform.position + sp.bounds.min;
			Vector3 bottomRight = transform.position + sp.bounds.max;
			Vector3 topLeftScreenSpace = Camera.main.WorldToScreenPoint(topLeft);
			Vector3 bottomRightScreenSpace = Camera.main.WorldToScreenPoint(bottomRight);
			Vector3 size = bottomRightScreenSpace - topLeftScreenSpace;
            GUI.DrawTexture(new Rect(screenPosition.x - ((3f/2f)*size.x), screenPosition.y-(size.y/2), (size.x), size.y/2f), BoxTexture);

        }
		
	}
	// Use this for initialization
	void Start () {
		sp = this.GetComponent<SpriteRenderer>().sprite;
		sr = this.GetComponent<SpriteRenderer>();
		this.sr.sprite.texture.filterMode = FilterMode.Point;
		camera = Camera.main;
		oldCameraOrthoSize = camera.orthographicSize;
		oldCameraPosition = camera.transform.position;
		sprites = GameObject.FindGameObjectsWithTag("sprite");
		HighlightName = this.name + "Highlight";
		this.HighlightedSprite = Resources.Load<Sprite>("Sprites/" + this.HighlightName);
		this.NormalSprite = Resources.Load<Sprite>("Sprites/" + this.name);
		if (HighlightedSprite != null)
			HighlightedSprite.texture.filterMode = FilterMode.Point;
		if (NormalSprite != null)
			NormalSprite.texture.filterMode = FilterMode.Point;

		ProgressBar = GameObject.FindGameObjectWithTag("ProgressBar").gameObject;
		if(VisitButton == null)
			VisitButton = GameObject.FindGameObjectWithTag("Visit");
	
		VisitButton.SetActive(false);
		if(BackButton == null)
			BackButton = GameObject.FindGameObjectWithTag("Back");
		if(BackButton.active)
			BackButton.SetActive(false);
		if (VisitButton.active)
			VisitButton.SetActive(false);
		if (Followers == null)
			Followers = GameObject.Find("Followers");
        if (Logo== null)
            Logo = GameObject.Find("logo");
        if (FactionManager == null)
            FactionManager = GameObject.Find("FactionManager");
	}

	// Update is called once per frame
	void Update ()
	{		
		//Debug.Log("Collider xSize: " + xSize + " ySize: " + ySize);
	}
}
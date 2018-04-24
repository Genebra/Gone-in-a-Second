using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{

	private GameObject[] sprites;

	private GameObject Followers;
	// Use this for initialization
	void OnLeftClick()
	{
		foreach (var sprite in sprites)
		{
			sprite.GetComponent<SpriteClick>().showGUI = false;
            sprite.GetComponent<WriteLocalInfo>().showText = false;
		}
		//ZoomedIn = false;
		Camera.main.transform.position = SpriteClick.oldCameraPosition;
		Camera.main.orthographicSize = SpriteClick.oldCameraOrthoSize;
		this.gameObject.SetActive(false);
		SpriteClick.ProgressBar.SetActive(true);
		SpriteClick.VisitButton.SetActive(false);
		SpriteClick.Followers.SetActive(true);
        SpriteClick.Logo.SetActive(true);
        SpriteClick.FactionManager.SetActive(true);
        GameObject.Find("BarFill").GetComponent<UnityEngine.UI.Image>().enabled = true;
		GameObject.Find("FollowersNumber").GetComponent<UnityEngine.UI.Text>().enabled = true;

	}

	void Start () {
		sprites = GameObject.FindGameObjectsWithTag("sprite");
		Followers = GameObject.Find("Followers");
		//ProgressBar = GameObject.FindGameObjectWithTag("ProgressBar");
		//this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

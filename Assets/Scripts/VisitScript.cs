using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisitScript : MonoBehaviour {

	// Use this for initialization
	public string sceneToLoad = "InsideChurch";
	
	void OnLeftClick()
	{
	//		Debug.Log("HEY");
			SceneManager.LoadScene(sceneToLoad);
        switch (sceneToLoad)
        {
            case "InsideChurch":
                MapManager.ClickedChurch = true;
                break;
            case "InsideCult":
                MapManager.ClickedCult = true;
                break;
            case "InsideHeadquarters":
                MapManager.ClickedHQ = true;
                break;
            case "InsideMilitary":
                MapManager.ClickedArmy = true;
                break;
            case "InsideParliament":
                MapManager.ClickedPolitics = true;
                break;

        }
    }


	void Start ()
	{
		//this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

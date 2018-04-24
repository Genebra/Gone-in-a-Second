using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisitScript2 : MonoBehaviour
{

    // Use this for initialization
    public string sceneToLoad = "InsideChurch2";

    void OnLeftClick()
    {
        SceneManager.LoadScene(sceneToLoad);
        switch (sceneToLoad)
        {
            case "InsideChurch2":
                MapManager.ClickedChurch = true;
                break;
            case "InsideCult2":
                MapManager.ClickedCult = true;
                break;
            case "InsideHeadquarters":
                MapManager.ClickedHQ = true;
                break;
            case "InsideMilitary2":
                MapManager.ClickedArmy = true;
                break;
            case "InsideParliament2":
                MapManager.ClickedPolitics = true;
                break;

        }
    }


    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

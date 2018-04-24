using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public static bool isSaved = false;
    public GameObject popup;

    public int route;

    public static bool ClickedChurch;
    public static bool ClickedArmy;
    public static bool ClickedPolitics;
    public static bool ClickedCult;
    public static bool ClickedHQ;

    public static GameObject Church;
    public static GameObject Army;
    public static GameObject HQ;
    public static GameObject Cult;
    public static GameObject Politics;

    public static int mapNumber = 1;
    public static bool shouldReset = false;

    private int nVisited;
    public bool visitedChurch;
    public bool visitedArmy;
    public bool visitedPolitics;
    public bool visitedCult;
    public bool visitedHQ;

    public bool visitedChurch2;
    public bool visitedArmy2;
    public bool visitedPolitics2;
    public bool visitedCult2;
    public bool visitedHQ2;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Map")
        {
            Church = GameObject.Find("Church");
            Army = GameObject.Find("MilitaryExterior");
            Cult = GameObject.Find("CultistIsland");
            HQ = GameObject.Find("HeadquartersExterior");
            Politics = GameObject.Find("PoliticianBuilding");

            if (ClickedChurch)
            {
                if (!visitedChurch)
                {
                    nVisited++;
                    visitedChurch = true;
                
                }
                Church.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedArmy)
            {
                if (!visitedArmy)
                {
                    nVisited++;
                    visitedArmy = true;
                }
                Army.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedCult)
            {
                if (!visitedCult)
                {
                    nVisited++;
                    visitedCult = true;
                }
                Cult.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedPolitics)
            {
                if (!visitedPolitics)
                {
                    nVisited++;
                    visitedPolitics = true;
                }
                Politics.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedHQ)
            {
                if (!visitedHQ)
                {
                    visitedHQ = true;
                }
                HQ.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        else if (scene.name == "Map2")
        {
            Church = GameObject.Find("Church");
            Army = GameObject.Find("MilitaryExterior");
            Cult = GameObject.Find("CultistIsland");
            HQ = GameObject.Find("HeadquartersExterior");
            Politics = GameObject.Find("PoliticianBuilding");


            if (shouldReset)
            {
                switch (instance.route)
                {
                    case 0:
                        Church.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedChurch = false;
                        Army.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedArmy = false;
                        Cult.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedCult = false;
                        Politics.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedPolitics = false;
                        HQ.GetComponent<BoxCollider2D>().enabled = false;
                        ClickedHQ = true;
                        shouldReset = false;
                        break;
                    case 1:
                        Church.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedChurch = false;
                        Army.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedArmy = false;
                        Cult.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedCult = false;
                        Politics.GetComponent<BoxCollider2D>().enabled = false;
                        ClickedPolitics = true;
                        HQ.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedHQ = false;
                        shouldReset = false;
                        break;
                    case 2:
                        Church.GetComponent<BoxCollider2D>().enabled = false;
                        ClickedChurch = true;
                        Army.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedArmy = false;
                        Cult.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedCult = false;
                        Politics.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedPolitics = false;
                        HQ.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedHQ = false;
                        shouldReset = false;
                        break;
                    case 3:
                        Church.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedChurch = false;
                        Army.GetComponent<BoxCollider2D>().enabled = false;
                        ClickedArmy = true;
                        Cult.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedCult = false;
                        Politics.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedPolitics = false;
                        HQ.GetComponent<BoxCollider2D>().enabled = true;
                        ClickedHQ = false;
                        shouldReset = false;
                        break;
                }
            }

            if (ClickedChurch)
            {
                if (!visitedChurch2)
                {
                    nVisited++;
                    visitedChurch2 = true;
                }
                Church.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedArmy)
            {
                if (!visitedArmy2)
                {
                    nVisited++;
                    visitedArmy2 = true;
                }
                Army.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedCult)
            {
                if (!visitedCult2)
                {
					if (nVisited == 0)
						nVisited = 1;
                    nVisited++;
                    visitedCult2 = true;
                }
                Cult.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedPolitics)
            {
                if (!visitedPolitics2)
                {
                    nVisited++;
                    visitedPolitics2 = true;
                }
                Politics.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (ClickedHQ)
            {
                if (!visitedHQ2)
                {
                    visitedHQ2 = true;
                }
                HQ.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    // Use this for initialization
    void Start()
    {



        nVisited = 0;

        if (instance == null)
        {
            instance = this;
            visitedChurch = false;
            visitedArmy = false;
            visitedPolitics = false;
            visitedCult = false;
            visitedHQ = false;

            visitedChurch2 = false;
            visitedArmy2 = false;
            visitedPolitics2 = false;
            visitedCult2 = false;
            visitedHQ2 = false;

            if (!isSaved)
                instance.Save();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Save()
    {
        isSaved = true;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (nVisited >2 && mapNumber!= 2 && !popup.activeInHierarchy)
        {
            shouldReset = true;
            SceneManager.LoadScene("IntermScene");
            nVisited = 0;
            mapNumber = 2;
        }
        else if (nVisited > 2 && mapNumber == 2 && !popup.activeInHierarchy)
        {

            SceneManager.LoadScene("EndScene");
        }
    }
}

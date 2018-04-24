using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour {

    // Use this for initialization
    public static int GainedFollowers;
    public static int ChurchGainedRep;
    public static int ArmyGainedRep;
    public static int PoliticsGainedRep;
    public static int CultGainedRep;
    public static GameObject Popup;
    public static GameObject Followers;
    public static GameObject GainedChurch;
    public static GameObject GainedPolitics;
    public static GameObject GainedArmy;
    public static GameObject GainedCult;
    public bool saved = false;


    public static PopupManager instance;
    public static bool shouldDisplay = false;

    void Awake () {
        if(instance == null) {
            instance = this;
            if(Popup == null)
            Popup = GameObject.Find("PopUp");
            if (Followers == null)
                Followers = GameObject.Find("GainedFollowers");
            if (GainedChurch == null)
                GainedChurch = GameObject.Find("GainedChurch");
            if (GainedPolitics == null)
                GainedPolitics = GameObject.Find("GainedPolitics");

            if (GainedArmy == null)
                GainedArmy = GameObject.Find("GainedArmy");
            if (GainedCult == null)
                GainedCult = GameObject.Find("GainedCult");
            if(!instance.saved)
                instance.DontDestroyOnLoad();
        //    if (!shouldDisplay)
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if(!shouldDisplay)
            Popup.SetActive(false);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLoaded;
    }

    private void DontDestroyOnLoad()
    {
        saved = true;
        DontDestroyOnLoad(this);
    }

    private void OnLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Map" || scene.name == "Map2")
        {
            if (shouldDisplay == true)
            {
                Popup.SetActive(true);

                if (GainedFollowers >= 0)
                    Followers.GetComponent<Text>().text = "+" + GainedFollowers;
                else
                    Followers.GetComponent<Text>().text = "" + GainedFollowers;
              
                if (ChurchGainedRep >= 0)
                    GainedChurch.GetComponent<Text>().text = "+" + ChurchGainedRep + "%" + " Rep";
                else
                    GainedChurch.GetComponent<UnityEngine.UI.Text>().text = "" + ChurchGainedRep +"%" + " Rep";
                if (ArmyGainedRep >= 0)
                    GainedArmy.GetComponent<UnityEngine.UI.Text>().text = "+" + ArmyGainedRep + "%" + " Rep";
                else
                    GainedArmy.GetComponent<UnityEngine.UI.Text>().text = "" + ArmyGainedRep + "%" + " Rep";
                if (PoliticsGainedRep >= 0)
                    GainedPolitics.GetComponent<UnityEngine.UI.Text>().text = "+" + PoliticsGainedRep + "%" + " Rep";
                else
                    GainedPolitics.GetComponent<UnityEngine.UI.Text>().text = "" + PoliticsGainedRep + "%" + " Rep";
                if (CultGainedRep >= 0)
                    GainedCult.GetComponent<UnityEngine.UI.Text>().text = "+" + CultGainedRep + "%" + " Rep";
                else
                    GainedCult.GetComponent<UnityEngine.UI.Text>().text = "" + CultGainedRep + "%" + " Rep";

            }
        }
    } 

}

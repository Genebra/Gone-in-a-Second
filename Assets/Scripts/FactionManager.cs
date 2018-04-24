using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactionManager : MonoBehaviour {

	struct Progress
	{
		public Image positiveProgress;
		public Image negativeProgress;
	}

	public static float ClericGoodValue = 0.0f;
	public static float ClericBadValue = 0.0f;
    public static float ArmyGoodValue = 0.0f;
    public static float ArmyBadValue = 0.0f;
    public static float CultGoodValue = 0.0f;
    public static float CultBadValue = 0.0f;
    public static float PoliticGoodValue = 0.0f;
	public static float PoliticBadValue = 0.0f;
	private float totalScore = 100.0f;
	private Progress ClericProgress;
	private Progress PoliticProgress;
    private Progress ArmyProgress;
    private Progress CultProgress;
    // Use this for initialization
    void Start () {
		PoliticProgress = new Progress();
		ClericProgress = new Progress();
        ArmyProgress = new Progress();
        CultProgress = new Progress();
        PoliticProgress.positiveProgress = GameObject.Find("PoliticalGreenBar").GetComponent<Image>();
		PoliticProgress.negativeProgress = GameObject.Find("PoliticalRedBar").GetComponent<Image>();
		ClericProgress.positiveProgress = GameObject.Find("ClericGreenBar").GetComponent<Image>();
		ClericProgress.negativeProgress = GameObject.Find("ClericRedBar").GetComponent<Image>();
        ArmyProgress.positiveProgress = GameObject.Find("ArmyGreenBar").GetComponent<Image>();
        ArmyProgress.negativeProgress = GameObject.Find("ArmyRedBar").GetComponent<Image>();
        CultProgress.positiveProgress = GameObject.Find("CultGreenBar").GetComponent<Image>();
        CultProgress.negativeProgress = GameObject.Find("CultRedBar").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
	{
		PoliticProgress.positiveProgress.fillAmount = PoliticGoodValue/totalScore;
		PoliticProgress.negativeProgress.fillAmount = PoliticBadValue/totalScore;
		ClericProgress.positiveProgress.fillAmount = ClericGoodValue/totalScore;
		ClericProgress.negativeProgress.fillAmount = ClericBadValue/totalScore;
	    ArmyProgress.positiveProgress.fillAmount = ArmyGoodValue / totalScore;
	    ArmyProgress.negativeProgress.fillAmount = ArmyBadValue / totalScore;
	    CultProgress.positiveProgress.fillAmount = CultGoodValue / totalScore;
	    CultProgress.negativeProgress.fillAmount = CultBadValue / totalScore;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScript : MonoBehaviour {

	// Use this for initialization
	public static float CurrentProgress = 100;
    public static float CurrentFollowers = 0;
	public float EndProgress = 100;
	private bool ShowGUI = false;
	private SpriteRenderer sr;
    private GameObject progressFill;

    void Start ()
	{
		ShowGUI = true;
		sr = this.GetComponent<SpriteRenderer>();
        progressFill = GameObject.Find("BarFill");
   }

	void OnGUI()
	{
        if (ShowGUI) {
            GameObject.Find("BarFill").GetComponent<UnityEngine.UI.Image>().fillAmount = (CurrentProgress/EndProgress);        
        }

    }

    public void SetGUI(bool b)
    {
        this.ShowGUI = b;
    }
	// Update is called once per frame
	void Update ()
	{

        GameObject.Find("FollowersNumber").GetComponent<UnityEngine.UI.Text>().text = WriteDialogue.finalScore.ToString();
        GameObject.Find("BarFill").GetComponent<UnityEngine.UI.Image>().fillAmount = (CurrentProgress / EndProgress);

	}
}

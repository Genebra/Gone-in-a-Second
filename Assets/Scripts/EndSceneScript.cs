using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(MapManager.instance.route == 0)
        {
            if(MapManager.instance.visitedArmy2 && MapManager.instance.visitedChurch2)
            {
                this.GetComponent<Text>().text = "With everyone by your side you were able to kill abaddon not long after it arrived. " +
                    "There were a few casualties but even so, the world was saved and you accomplished you mission successfully.";
            }
            else if (MapManager.instance.visitedArmy2 && MapManager.instance.visitedPolitics2)
            {
                this.GetComponent<Text>().text = "With everyone by your side you were able to kill abaddon not long after it arrived. " +
                    "There were a few casualties but even so, the world was saved and you accomplished you mission successfully.";
            }
            else if (MapManager.instance.visitedChurch2 && MapManager.instance.visitedPolitics2)
            {
                this.GetComponent<Text>().text = "With everyone by your side you were able to kill abaddon not long after it arrived. " +
                    "There were a few casualties but even so, the world was saved and you accomplished you mission successfully.";
            }
            else if (MapManager.instance.visitedArmy2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to attack and kill both father Marcus and mayor Bill, dealing a huge blow to you and everyone." +
                    " Even so, you and everyone else faced Abaddon and were able to kill it, at the cost of many many lives. In the end the world was saved but it doesn't feel like a success...";
            }
            else if (MapManager.instance.visitedChurch2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to attack and kill both General Douglas and mayor Bill, dealing a huge blow to you and everyone. " +
                    "Even so, you and everyone else faced Abaddon and were able to kill it, at the cost of many lives. In the end the world was saved but it doesn't feel like a success...";
            }
            else if (MapManager.instance.visitedPolitics2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to attack and kill both General Douglas and father Marcus, dealing a huge blow to you and everyone." +
                    " Even so, you and everyone else faced Abaddon and were able to kill it, at the cost of many lives. In the end the world was saved but it doesn't feel like a success...";
            }
        }
        else if (MapManager.instance.route == 1)
        {
            if (MapManager.instance.visitedArmy2 && MapManager.instance.visitedChurch2)
            {
                this.GetComponent<Text>().text = "With the help of general Douglas' and father Marcus' support you were able to defeat Abadonn. " +
                    "It was a tough battle, and many lives were lost, but in the end, the world was saved and you accomplished you mission successfully.";
            }
            if (MapManager.instance.visitedArmy2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to kill one of your allies, father Marcus. " +
                    "With only you and the military's help, you were hopeless against the coming of Abaddon.";
            }
            if (MapManager.instance.visitedChurch2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to kill one of your allies, general Douglas. " +
                    "With only you and father marcus' help, you were hopeless against the coming of Abaddon.";
            }
        }
        else if (MapManager.instance.route == 2)
        {
            if (MapManager.instance.visitedArmy2 && MapManager.instance.visitedPolitics2)
            {
                this.GetComponent<Text>().text = "With the help of general Douglas' and mayor Bill's support you were able to defeat Abadonn. " +
                    "It was a tough battle, and many lives were lost, but in the end, the world was saved and you accomplished you mission successfully.";
            }
            if (MapManager.instance.visitedArmy2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to kill one of your allies, mayor Bill." +
                    " With only you and the military's help, you were hopeless against the coming of Abaddon.";
            }
            if (MapManager.instance.visitedPolitics2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to kill one of your allies, general Douglas. " +
                    "With only you and mayor bills' help, you were hopeless against the coming of Abaddon.";
            }
        }
        else if (MapManager.instance.route == 3)
        {
            if (MapManager.instance.visitedPolitics2 && MapManager.instance.visitedChurch2)
            {
                this.GetComponent<Text>().text = "With the help of general Douglas' and mayor Bill's support you were able to defeat Abadonn. " +
                    "It was a tough battle, and many lives were lost, but in the end, the world was saved and you accomplished you mission successfully.";
            }
            if (MapManager.instance.visitedChurch2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to kill one of your allies, mayor Bill." +
                    " With only you and father marcus' help, you were hopeless against the coming of Abaddon.";
            }
            if (MapManager.instance.visitedPolitics2 && MapManager.instance.visitedCult2)
            {
                this.GetComponent<Text>().text = "Right before Abaddon arrived, the cultists were able to kill one of your allies, father Marcus." +
                    " With only you and mayor Bill's help, you were hopeless against the coming of Abaddon.";
            }
        }

    }
}

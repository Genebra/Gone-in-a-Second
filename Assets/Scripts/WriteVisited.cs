using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteVisited : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.instance.visitedChurch && MapManager.instance.visitedPolitics && MapManager.instance.visitedArmy)
        {
            this.GetComponent<Text>().text = "The Cultists saw that you were gainning followers to try and kill Abaddon, and so they came for you. " +
                "They stormed your house to try and shoot you but Jack heroically jumped in front of the gun. He is dead, you feel alone and and only have two more weeks to prepare.\n\n" +
                "Make it count.";

            MapManager.instance.route = 0;

        }
        else if (MapManager.instance.visitedChurch && MapManager.instance.visitedCult && MapManager.instance.visitedArmy)
        {
            this.GetComponent<Text>().text = "The Cultist anticipated that you would try to get the Mayor on your side and so they assassinated him. " +
                "You have only two more weeks before Abaddon arrives.\n\nMake it count.";

            MapManager.instance.route = 1;
        }
        else if (MapManager.instance.visitedCult && MapManager.instance.visitedPolitics && MapManager.instance.visitedArmy)
        {
            this.GetComponent<Text>().text = "The Cultist anticipated that you would try to get father marcus to help you and so they assassinated him." +
                "You have only two more weeks before abaddon arrives. Make it count.";

            MapManager.instance.route = 2;
        }
        else if (MapManager.instance.visitedChurch && MapManager.instance.visitedPolitics && MapManager.instance.visitedCult)
        {
            this.GetComponent<Text>().text = "The cultist anticipated that you would try to get the military on your side and so they assassinated General Douglas, your only contact in the army." + "" +
                "You have only two more weeks before abaddon arrives. Make it count.";

            MapManager.instance.route = 3;
        }

    }
}

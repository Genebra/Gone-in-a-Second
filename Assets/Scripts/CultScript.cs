using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultScript : CharClick {

    // Use this for initialization
    protected override void OnLeftClick()
    {
        if (!onDial)
        {
            onDial = true;
            showGUI = true;
            GameObject.Find("CharacterNear").GetComponent<SpriteRenderer>().sortingOrder = 1;
            GameObject.Find("CultistFigure").GetComponent<SpriteRenderer>().sortingOrder = 1;
                
        }
    }
}

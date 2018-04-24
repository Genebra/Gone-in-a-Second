using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryScript : CharClick {

    protected override void OnLeftClick()
    {
        if (!onDial)
        {
            onDial = true;
            showGUI = true;
            GameObject.Find("CharacterNear").GetComponent<SpriteRenderer>().sortingOrder = 1;
            GameObject.Find("GeneralFigure").GetComponent<SpriteRenderer>().sortingOrder = 1;
            
        }
    }

}

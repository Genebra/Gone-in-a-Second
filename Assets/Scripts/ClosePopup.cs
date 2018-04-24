using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour {

	public void OnLeftClick()
    {
        if(GameObject.Find("PopUp") != null)
           GameObject.Find("PopUp").SetActive(false);
        PopupManager.shouldDisplay = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButtonScript : MonoBehaviour {

	// Use this for initialization
	void OnLeftClick()
	{
		SceneManager.LoadScene("Map");
	}
}

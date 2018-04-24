using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript2 : MonoBehaviour
{

    private GameObject[] sprites;

    private GameObject Followers;
    // Use this for initialization
    void OnLeftClick()
    {
        foreach (var sprite in sprites)
        {
            sprite.GetComponent<SpriteClick2>().showGUI = false;
            sprite.GetComponent<WriteLocalInfo>().showText = false;
        }
        //ZoomedIn = false;
        Camera.main.transform.position = SpriteClick2.oldCameraPosition;
        Camera.main.orthographicSize = SpriteClick2.oldCameraOrthoSize;
        this.gameObject.SetActive(false);
        SpriteClick2.ProgressBar.SetActive(true);
        SpriteClick2.VisitButton.SetActive(false);
        SpriteClick2.Followers.SetActive(true);
        SpriteClick2.Logo.SetActive(true);
        SpriteClick2.FactionManager.SetActive(true);
        GameObject.Find("BarFill").GetComponent<UnityEngine.UI.Image>().enabled = true;
        GameObject.Find("FollowersNumber").GetComponent<UnityEngine.UI.Text>().enabled = true;

    }

    void Start()
    {
        sprites = GameObject.FindGameObjectsWithTag("sprite");
        Followers = GameObject.Find("Followers");
        //ProgressBar = GameObject.FindGameObjectWithTag("ProgressBar");
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

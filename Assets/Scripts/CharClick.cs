using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharClick : MonoBehaviour {

    public Texture DialogueTexture;
    public Sprite DialogueSprite;
    private Sprite CharSprite;
    protected bool showGUI, onDial;
    private int sHeight, sWidth;
    private Sprite HighlightSprite;

    protected virtual void Start () {
        showGUI = false;
        onDial = false;
        this.HighlightSprite = Resources.Load<Sprite>("Sprites/" + this.name + "Highlight") as Sprite;
		this.CharSprite = Resources.Load<Sprite>("Sprites/" + this.name) as Sprite;

	}

    private void OnMouseOver()
    {
        if(this.GetComponent<SpriteRenderer>().sprite == CharSprite)
          this.GetComponent<SpriteRenderer>().sprite = HighlightSprite;
    }

    private void OnMouseExit()
    {
        if (this.GetComponent<SpriteRenderer>().sprite == HighlightSprite)
             this.GetComponent<SpriteRenderer>().sprite = CharSprite;
    }

    protected virtual void OnGUI()
    {
        GUI.depth = 5;
        if(showGUI)
        {
            this.GetComponent<SpriteRenderer>().sprite = DialogueSprite;
            //GUI.DrawTexture(new Rect((sWidth/9),(sHeight/1.5f),sWidth*0.8f, sHeight*0.3f) , DialogueTexture);
        }
    }

    protected virtual void OnLeftClick()
    {
        if (!onDial)
        {
            onDial = true;
            showGUI = true;
            sHeight = Screen.height;
            sWidth = Screen.width;

            transform.Translate(new Vector3(5f, 1.49f, 0f));
            GameObject.Find("CharacterNear").transform.Translate(new Vector3(7.0f, 0.05f, 0f));
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);            
        }
    }

    public bool IsOnDial()
    {
        return onDial;
    }


}

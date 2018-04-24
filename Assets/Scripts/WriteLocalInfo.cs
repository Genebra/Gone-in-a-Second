using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteLocalInfo : MonoBehaviour {

    public bool showText = false;
    private Sprite sp;
    private Text TextComp;

    public GUISkin skin;

    void Start()
    {
        showText = false;
        TextComp = GetComponent<Text>();
        sp = GetComponent<SpriteRenderer>().sprite;
    }

    void OnGUI()
    {
        GUI.depth = 0;

        if (this.showText)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            //get sprite size
            Vector3 topLeft = transform.position + sp.bounds.min;
            Vector3 bottomRight = transform.position + sp.bounds.max;
            Vector3 topLeftScreenSpace = Camera.main.WorldToScreenPoint(topLeft);
            Vector3 bottomRightScreenSpace = Camera.main.WorldToScreenPoint(bottomRight);
            Vector3 size = bottomRightScreenSpace - topLeftScreenSpace;
            GUI.TextArea(new Rect(screenPosition.x - ((3f / 2f) * size.x) + 10f, screenPosition.y - (size.y / 2) + 10f, (size.x) - 20f, (size.y / 2f) - 20f),
                TextComp.text, skin.GetStyle("Style1"));
        }
    }

    void OnLeftClick()
    {
        showText = true;
    }

    void OnRightClick()
    {
        showText = false;
    }
}

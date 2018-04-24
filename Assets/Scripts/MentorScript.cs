using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MentorScript : CharClick
	{

		protected override void OnLeftClick()
		{
        if (!onDial)
        {
            onDial = true;
            showGUI = true;
            transform.Translate(new Vector3(0, 1.9f, 0));
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            GameObject.Find("CharacterNear").transform.Translate(new Vector3(7.0f, 0.05f, 0f));
        }
		}
	}

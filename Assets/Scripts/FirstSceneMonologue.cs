using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Assets.Scripts { 
public class FirstSceneMonologue : WriteDialogue {


    // Use this for initialization
    private GameObject background;
    private Camera main;
    bool firstAnimation = true;
    SpriteRenderer bgrenderer;
        public float fadeInTime = 1f;
        public float fadeOutTime = 1f;
        public float delayToFadeOut = 3f;
        public float delayToFadeIn = 3f;

        public SpriteRenderer sprite;
        GameObject abaddon;

    public Color spriteColor = Color.white;

        protected override void Start()
    {
        base.Start();
        background = GameObject.Find("HeadquartersInterior");
        main = Camera.main;
        sprite = background.GetComponent<SpriteRenderer>();
            abaddon = GameObject.Find("Abaddon");
            abaddon.SetActive(false);
    }
    protected override void Update()
    {
        Conversation();
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
                index++;
                finishedTyping = false;
        }
    }
    protected override void Conversation()
	{
        if (index < 2)
        {
            background.SetActive(false);
        }
        else if (index == 2)
        {
                background.SetActive(true);
                StartCoroutine("FadeIn");
                return;
        }else if(index == 4)
        {
                StopCoroutine("FadeIn");
                StartCoroutine("FadeOut");
        }else if(index == 5)
            {
                StopCoroutine("FadeOut");
                abaddon.SetActive(true);
                sprite = abaddon.GetComponent<SpriteRenderer>();
                StartCoroutine("FadeIn");
            }
            else if (index == 6)
            {
                StopCoroutine("FadeIn");
                StartCoroutine("FadeOut");

            }
            else if(index == 7)
            {
                StopCoroutine("FadeOut");
                SceneManager.LoadScene("InsideHeadquarters");
            }
        
        DialogueCanvas.SetActive(true);
        dialogueText.SetActive(true);
        
        if (index < currNode.dialogue.Count)    //still has something to write
        {
            //_dlg.text = currNode.dialogue[index];
            if (!isTyping && !finishedTyping) StartCoroutine(TypeText(currNode.dialogue[index], _dlg));
        }
        else
        {
           // SceneManager.LoadScene("Map");
        }

        if (index + 1 == currNode.dialogue.Count && currNode.optionList.Count > 0) //got to the end of the node
        {
            isOption = true;
        }

        if (isOption) //writes the options found on node
        {
            _timer.StartTimer();

            if (currNode.optionList.Count > 0)
            {
                opt1Text.SetActive(true);
                opt2Text.SetActive(true);
                opt3Text.SetActive(true);

                _opt1.text = currNode.optionList[0].text;
                _opt2.text = currNode.optionList[1].text;
                _opt3.text = currNode.optionList[2].text;
            }
        }
        else
        {
            opt1Text.SetActive(false);
            opt2Text.SetActive(false);
            opt3Text.SetActive(false);
        }
    }

        IEnumerator FadeCycle()
        {
            if (firstAnimation)
            {
                firstAnimation = false;
            }else
            {
                yield return null;
            }
            float fade = 0f;
            float startTime;
            while (true)
            {
                startTime = Time.time;
                while (fade < 1f)
                {
                    fade = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeInTime);
                    spriteColor.a = fade;
                    sprite.color = spriteColor;
                    yield return null;
                }
                //Make sure it's set to exactly 1f
                fade = 1f;
                spriteColor.a = fade;
                sprite.color = spriteColor;
                yield return new WaitForSeconds(delayToFadeOut);

                startTime = Time.time;
                while (fade > 0f)
                {
                    fade = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeOutTime);
                    spriteColor.a = fade;
                    sprite.color = spriteColor;
                    yield return null;
                }
                fade = 0f;
                spriteColor.a = fade;
                sprite.color = spriteColor;
                yield return new WaitForSeconds(delayToFadeIn);
            }
        }


        IEnumerator FadeOut()
        {

            float fade = 1f;
            float startTime;
            while (fade != 0)
            {

            
            startTime = Time.time;
            while (fade > 0f)
            {
                fade = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeOutTime);
                spriteColor.a = fade;
                sprite.color = spriteColor;
                yield return null;
            }
            fade = 0f;
            spriteColor.a = fade;
            sprite.color = spriteColor;
                yield break;
            }
        }
        IEnumerator FadeIn()
        {
            float fade = 0f;
            float startTime;
            while (fade != 1)
            {
                startTime = Time.time;
                while (fade < 1f)
                {
                    fade = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeInTime);
                    spriteColor.a = fade;
                    sprite.color = spriteColor;
                    yield return null;
                }
                //Make sure it's set to exactly 1f
                fade = 1f;
                spriteColor.a = fade;
                sprite.color = spriteColor;
                yield break;
            }
        }
    }

}


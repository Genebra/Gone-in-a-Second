using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class WriteDialogue : MonoBehaviour
{
    public Graph charGraph;
    public Node currNode;
    public static int finalScore = 0;
    protected bool isOption;
    private int nodeIndex = 0;
    protected int index = 0;
    protected int choice;
    private int phase = 0;
    public Image popup;
    private bool isPopup;
    private bool hasAnswer;
    private bool isTarget;

    public float delay = 0.05f;
    protected bool isTyping = false;
    protected bool finishedTyping = false;

    public GameObject dialogueText, opt1Text, opt2Text, opt3Text, opt4Text, keyindication;
    public GameObject NPC;
    public string TextToLoad;
    protected Text _dlg, _opt1, _opt2, _opt3, _opt4;
    protected TimerScript _timer;
    protected GameObject MapButton;
    protected GameObject DialogueCanvas;

    private void Awake()
    {
        _timer = this.GetComponent<TimerScript>();
        _dlg = dialogueText.GetComponent<Text>();
        _opt1 = opt1Text.GetComponent<Text>();
        _opt2 = opt2Text.GetComponent<Text>();
        _opt3 = opt3Text.GetComponent<Text>();
        _opt4 = opt4Text.GetComponent<Text>();

        dialogueText.SetActive(false);
        opt1Text.SetActive(false);
        opt2Text.SetActive(false);
        opt3Text.SetActive(false);
        opt4Text.SetActive(false);

        keyindication.SetActive(false);
        popup.gameObject.SetActive(false);
    }

    protected virtual void Start()
    {
        charGraph = DialogueLoader.fullDialogue[TextToLoad];
        currNode = charGraph.nodeList[nodeIndex];

        isOption = false;
        isPopup = false;
        isTarget = false;

        choice = -1;
        if (DialogueCanvas == null) DialogueCanvas = GameObject.Find("DialogueCanvas");

        MapButton = GameObject.Find("MapButton");
        DialogueCanvas.SetActive(false);
        PopupManager.CultGainedRep = 0;
        PopupManager.ArmyGainedRep = 0;
        PopupManager.ChurchGainedRep = 0;
        PopupManager.PoliticsGainedRep = 0;
        PopupManager.GainedFollowers = 0;
    }

    protected virtual void Update()
    {
        Conversation();

        if (Input.GetKeyDown(KeyCode.Alpha1) && isOption)
        {
            choice = 0;
            _timer.StopTimer();
            hasAnswer = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isOption)
        {
            choice = 1;
            _timer.StopTimer();
            hasAnswer = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isOption)
        {
            choice = 2;
            _timer.StopTimer();
            hasAnswer = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && isOption)
        {
            choice = 3;
            _timer.StopTimer();
            hasAnswer = true;
        }

        if (_timer.GetTimeLeft() <= 0 && isOption)
        {
            choice = 3;
            _timer.StopTimer();
            hasAnswer = true;
        }

        if (choice != -1)
        {
            popup.gameObject.SetActive(false);
            finalScore += currNode.optionList[choice].score;

            if (currNode.optionList[choice].factionChurch < 0)
                FactionManager.ClericBadValue += Mathf.Abs(currNode.optionList[choice].factionChurch);
            FactionManager.ClericGoodValue += currNode.optionList[choice].factionChurch;

            if (currNode.optionList[choice].factionPolitics < 0)
                FactionManager.PoliticBadValue += Mathf.Abs(currNode.optionList[choice].factionPolitics);
            FactionManager.PoliticGoodValue += currNode.optionList[choice].factionPolitics;

            if (currNode.optionList[choice].factionArmy < 0)
                FactionManager.ArmyBadValue += Mathf.Abs(currNode.optionList[choice].factionArmy);
            FactionManager.ArmyGoodValue += currNode.optionList[choice].factionArmy;

            if (currNode.optionList[choice].factionCult < 0)
                FactionManager.CultBadValue += Mathf.Abs(currNode.optionList[choice].factionCult);
            FactionManager.CultGoodValue += currNode.optionList[choice].factionCult;

            PopupManager.CultGainedRep += currNode.optionList[choice].factionCult;
            PopupManager.ArmyGainedRep += currNode.optionList[choice].factionArmy;
            PopupManager.ChurchGainedRep += currNode.optionList[choice].factionChurch;
            PopupManager.PoliticsGainedRep += currNode.optionList[choice].factionPolitics;
            PopupManager.GainedFollowers += currNode.optionList[choice].score;
            ChangeNode();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isPopup)
        {
            popup.gameObject.SetActive(false);
            isOption = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            if (!isOption && !isPopup && NPC.GetComponent<CharClick>().IsOnDial())
            {
                index++;
                finishedTyping = false;
            }
        }

    }

    protected virtual void Conversation()
    {
        MapButton.SetActive(false);

        if (NPC.GetComponent<CharClick>().IsOnDial())
        {
            keyindication.SetActive(true);
            DialogueCanvas.SetActive(true);
            dialogueText.SetActive(true);

            if (index < currNode.dialogue.Count)    //still has something to write
            {
                _dlg.text = currNode.dialogue[index];
            }
            else
            {
                ChangeNode();
            }

            if (index + 1 == currNode.dialogue.Count && currNode.optionList.Count > 0) //The end of the node was reached and has options
            {
                isPopup = true;
            }

            if (isPopup)
            {
                keyindication.SetActive(false);
                popup.gameObject.SetActive(true);
            }

            if (isOption) //writes the options found on node
            {
                isTarget = true;
                keyindication.SetActive(false);
                _timer.StartTimer();

                opt1Text.SetActive(true);
                opt2Text.SetActive(true);
                opt3Text.SetActive(true);
                opt4Text.SetActive(true);

                _opt1.text = currNode.optionList[0].text;
                _opt2.text = currNode.optionList[1].text;
                _opt3.text = currNode.optionList[2].text;
                _opt4.text = currNode.optionList[3].text;
            }
            else
            {
                opt1Text.SetActive(false); opt2Text.SetActive(false); opt3Text.SetActive(false); opt4Text.SetActive(false);
            }
        }
    }

    private void ChangeNode()
    {
        if (nodeIndex + 1 >= charGraph.nodeList.Count)
        {
            if(SceneManager.GetActiveScene().name != "InsideHeadquarters")
               ProgressScript.CurrentProgress -= 20;
            if (MapManager.mapNumber == 1)
                SceneManager.LoadScene("Map");
            else {
            SceneManager.LoadScene("Map2");
        }

            PopupManager.shouldDisplay = true;
            return;
        }

        if (isTarget)
        {
            currNode = charGraph.nodeList[nodeIndex].optionList[choice].target; //Goes to target
            isTarget = false;                                                   //Wont visit it again

            isOption = false;                                                   //No options in targets
            isPopup = false;                                                    //So no pop ups

            _timer.RestartTimer();
            choice = -1;
            index = 0;                                                          //Restarts conversation in target
        }
        else
        {
            nodeIndex++;                                                        //Exited a target and wrote all lines in there so time to change node
            currNode = charGraph.nodeList[nodeIndex];
            isTarget = false;                                                   //Goes to papa node and not target node

            isOption = false;                                                   //Options and popup will be triggered later
            isPopup = false;

            _timer.RestartTimer();
            choice = -1;
            index = 0;                                                          //Restarts conversation in main node
        }

        Debug.Log("Node index:" + nodeIndex);
        Debug.Log("Node count:" + charGraph.nodeList.Count);
    }

    public int GetIndex()
    {
        return index;
    }

    protected IEnumerator TypeText(string fullText, Text component)
    {
        finishedTyping = false;
        isTyping = true;
        for (int i = 0; i < fullText.Length; i++)
        {
            component.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        isTyping = false;
        finishedTyping = true;
    }
}

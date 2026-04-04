using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogChat : MonoBehaviour
{
    [SerializeField] GameObject canvasDialog;
    [SerializeField] Image imageCanvas;
    [SerializeField] TextMeshProUGUI textCanvas;
    [SerializeField] TextMeshProUGUI nameCanvas;
    [SerializeField] Button buttonCanvas;
    [SerializeField] List<DialogTable> dialogTable = new List<DialogTable>();
    private bool isShop;
    [SerializeField] int phase;
    [SerializeField] int round;
    [SerializeField] char letter;
    [SerializeField] int sentenceRound;
    [SerializeField] bool typing;
    //private Movement playerMv;

    private void Start()
    {
        
        canvasDialog = GameObject.Find("ShopAndDialogCanvas").transform.GetChild(0).gameObject;
        imageCanvas = canvasDialog.transform.GetChild(0).GetComponent<Image>();
        textCanvas = canvasDialog.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        nameCanvas = canvasDialog.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        buttonCanvas = canvasDialog.transform.GetChild(3).GetComponent<Button>();
        //shopkeeperSys = GameObject.Find("EventSystem").GetComponent<ShopkeeperSystem>();
        //playerMv = GameObject.Find("Player").GetComponent<Movement>();
        //playerMv.enabled = false;
    }

    public void startDailog()
    {
        
    }
    public void nextDialog()
    {
        //playerMv.enabled = false;
        if (typing == false)
        {

            if (sentenceRound >= dialogTable[phase].dialogAndEventActive[0].dialog.Length)
            {
                sentenceRound = 0;
                canvasDialog.SetActive(false);
                //playerMv.enabled = true;
            }
            else
            {
                imageCanvas.sprite = dialogTable[phase].characterProfile[sentenceRound];
                nameCanvas.text = dialogTable[phase].characterName[sentenceRound];
                textCanvas.text = "";
                StartCoroutine(Type());
            }
        }
    }

    IEnumerator Type()
    {
        typing = true;
        yield return new WaitForSeconds(0.05f);

        if (sentenceRound >= dialogTable[phase].dialogAndEventActive[0].dialog.Length)
        {
            sentenceRound = 0;
            canvasDialog.SetActive(false);
        }
        else if (round != dialogTable[phase].dialogAndEventActive[0].dialog[sentenceRound].Length)
        {
            foreach (string word in dialogTable[phase].dialogAndEventActive[0].dialog[sentenceRound].Split(""))
            {
                textCanvas.text += word[round];
                round++;
                yield return (StartCoroutine(Type()));
            }
        }
        else
        {
            if (dialogTable[phase].dialogAndEventActive[0].eventActiveTime[0] != "")
            {
                if (sentenceRound == int.Parse(dialogTable[phase].dialogAndEventActive[0].eventActiveTime[0].Split(" ")[0]))
                {
                    dialogTable[phase].eventActive.Invoke();
                }
            }
            typing = false;
            sentenceRound += 1;
            round = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public bool PuedeHablar,SoloPuedeMirar, SoloMirar, LookAt;
    public Transform npc, Player;
    public float TurnSpeed;
    Quaternion rotGoal;
    Vector3 Direction;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)]private string[] dialogueLines;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        LookAt= false;
        TurnSpeed = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        if (LookAt)
        {
            Direction = (Player.position - transform.position).normalized;
            rotGoal = Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, TurnSpeed);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!didDialogueStart)
                {
                    StartDialogue();
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }
            }
        }
        else if (SoloPuedeMirar && SoloMirar)
        {
            Direction = (Player.position - transform.position).normalized;
            rotGoal = Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, TurnSpeed);
        }

    }

    void StartDialogue()
    {
        didDialogueStart= true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex ++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart= false;
            dialoguePanel.SetActive(false);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PuedeHablar)
            {
                LookAt = true;
            }
            else if (SoloPuedeMirar)
            {
                SoloMirar = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LookAt = false;
            SoloMirar = false;
            StopAllCoroutines();
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
        }
    }
}

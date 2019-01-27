using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnTimer : MonoBehaviour
{
    public float timeToWait = 5;

    private DialogueRunner dialogueRunner;
    private Yarn.Unity.Example.ExampleDialogueUI dialogueUI;

    private void Start()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
        dialogueUI = GetComponent<Yarn.Unity.Example.ExampleDialogueUI>();
    }

    [YarnCommand("startTimer")]
    public void StartTimer(string nodeToStart)
    {
        StartCoroutine(RunTimer(nodeToStart));
    }

    IEnumerator RunTimer(string nodeToStart)
    {
        Debug.Log("I RUN!");
        float time = 0;
        do
        {
            yield return null;
            if(!dialogueUI.optionsActive)
            {
                Debug.Log("<color=red>I BREAK</color>");
                yield break;
            }
            Debug.Log("I TIME");
            time += Time.deltaTime;
        }
        while (time < timeToWait);

        dialogueUI.StopAllCoroutines();
        dialogueUI.StartCoroutine(dialogueUI.DissappearButtons());
        Debug.Log("I STOPPED!");
        dialogueRunner.Stop();

        dialogueRunner.StartDialogue(nodeToStart);

    }
}

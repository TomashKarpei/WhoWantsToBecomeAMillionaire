using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public MilManager milManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Poprawna odpowiedz");
            milManager.correct();
        }
        else
        {
            Debug.Log("Zla odpowiedz");
            milManager.wrong();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;


public class MilManager : MonoBehaviour
{
    public List<PytaniaIOdpowiedzi> PiO;
    public GameObject[] options;
    public int currentQuestion;
    public int numberOfQuestion = 1;
    public int numberOfAnswered = 0;
    public int corAnswer;
    public int currentMoney;
    int IlPytan;
    float time = 3;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI QNumText;
    public TextMeshProUGUI ResMoney;
    public TextMeshProUGUI ResQ;
    public Button pauza;

    //MenuPauzy
    public Button returnToGame;
    public Button restart;
    public Button helpm;
    public Button endGame;

    public GameObject HelpMen;

    //help buttons
    public GameObject ftft;
    public GameObject ftftActive;
    public GameObject ftftUsed;

    public GameObject changeQuestion;
    public GameObject changeQuestionActive;
    public GameObject changeQuestionUsed;

    public GameObject noGO;
    public GameObject noGOActive;
    public GameObject noGOUsed;

    public GameObject mp;
    public GameObject gra;
    public GameObject KonGry;

    //Pytania
    public GameObject aB;
    public GameObject bB;
    public GameObject cB;
    public GameObject dB;

    //Sprajty
    public Sprite zwLewy;
    public Sprite zwPrawy;
    public Sprite poprLewy;
    public Sprite poprPrawy;
    public Sprite zlyLewy;
    public Sprite zlyPrawy;

    Image IzwLewy;
    Image IzwPrawy;
    Image IpoprLewy;
    Image IpoprPrawy;
    Image IzlyLewy;
    Image IzlyPrawy;

    private string name;

    public bool pauseIsActive = false;
    public bool ftftPhase = false;
    public bool changeQuestionPhase = false;
    public bool noGOPhase = false;


    private void Start()
    {
        gra.SetActive(true);
        IlPytan = PiO.Count;
        QNumText.text = numberOfQuestion.ToString() + "/" + IlPytan.ToString();
        generateQuestion();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            pause();
        }
        
    }

    public void GameOver()
    {
        gra.SetActive(false);
        KonGry.SetActive(true);
        ResMoney.text = "$ " + currentMoney.ToString();
        ResQ.text = (numberOfAnswered).ToString() + "/" + IlPytan.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void helpMenu()
    {
        HelpMen.SetActive(true);
        mp.SetActive(false);
    }

    public void closeHelp()
    {
        HelpMen.SetActive(false);
        mp.SetActive(true);
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        changeColorToDefault();
        numberOfQuestion++;
        QNumText.text = numberOfQuestion.ToString() + "/" + IlPytan.ToString();
        PiO.RemoveAt(currentQuestion);
        generateQuestion();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator ExecuteAfterGO(float time)
    {
        yield return new WaitForSeconds(time);
        changeColorToDefault();
        GameOver();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void FiftyFifty()
    {
        if (ftftPhase == false)
        {
            ftft.SetActive(false);
            ftftActive.SetActive(true);
            ftftPhase = true;
            int rr1 = Random.Range(0, 4);
            int rr2 = Random.Range(0, 4);
            while (rr1 == corAnswer)
            {
                rr1 = Random.Range(0, 4);
            }
            while (rr2 == rr1 || rr2 == corAnswer)
            {
                rr2 = Random.Range(0, 4);
            }

            if (rr1 == 0 || rr2 == 0)
            {
                aB.SetActive(false);
            }
            if (rr1 == 1 || rr2 == 1)
            {
                bB.SetActive(false);
            }
            if (rr1 == 2 || rr2 == 2)
            {
                cB.SetActive(false);
            }
            if (rr1 == 3 || rr2 == 3)
            {
                dB.SetActive(false);
            }
        }
    }
    
    public void changeColorToCorrect()
    {
        if (corAnswer == 0)
        {
            aB.GetComponent<Image>().sprite = poprLewy;
        }
        else if (corAnswer == 1)
        {
            bB.GetComponent<Image>().sprite = poprPrawy;
        }
        else if (corAnswer == 2)
        {
            cB.GetComponent<Image>().sprite = poprLewy;
        }
        else if (corAnswer == 3)
        {
            dB.GetComponent<Image>().sprite = poprPrawy;
        }
    }

    public void changeColorToWrong()
    {
        if (name == "OdpA")
        {
            aB.GetComponent<Image>().sprite = zlyLewy;
        }
        else if (name == "OdpB")
        {
            bB.GetComponent<Image>().sprite = zlyPrawy;
        }
        else if (name == "OdpC")
        {
            cB.GetComponent<Image>().sprite = zlyLewy;
        }
        else if (name == "OdpD")
        {
            dB.GetComponent<Image>().sprite = zlyPrawy;
        }
    }

    public void changeColorToDefault()
    {
        aB.GetComponent<Image>().sprite = zwLewy;
        bB.GetComponent<Image>().sprite = zwPrawy;
        cB.GetComponent<Image>().sprite = zwLewy;
        dB.GetComponent<Image>().sprite = zwPrawy;
    }

    public void DifQest()
    {
        if (changeQuestionPhase == false)
        {
            changeQuestion.SetActive(false);
            changeQuestionActive.SetActive(true);
            changeQuestionPhase = true;

            if (noGOPhase == true)
            {
                noGOActive.SetActive(false);
                noGO.SetActive(true);
                noGOPhase = false;
            }

            if (ftftPhase == true)
            {

                ftftActive.SetActive(false);
                ftftUsed.SetActive(true);
                aB.SetActive(true);
                bB.SetActive(true);
                cB.SetActive(true);
                dB.SetActive(true);
                ftftPhase = false;
            }

            StartCoroutine(ExecuteAfterTime(time));

            changeQuestionActive.SetActive(false);
            changeQuestionUsed.SetActive(true);
            changeQuestionPhase = false;
        }
    }

    public void noGameOver()
    {
        if (noGOPhase == false)
        {
            noGO.SetActive(false);
            noGOActive.SetActive(true);
            noGOPhase = true;
        }
        else
        {
            noGOActive.SetActive(false);
            noGO.SetActive(true);
            noGOPhase = false;
        }
        
    }

    public void pause()
    {
        if (pauseIsActive == false)
        {
            mp.SetActive(true);
            gra.SetActive(false);
            pauseIsActive = true;
        }
        else
        {
            gra.SetActive(true);
            HelpMen.SetActive(false);
            mp.SetActive(false);
            pauseIsActive = false;
        }
    }

    public void correct()
    {
        changeColorToCorrect();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //dodawanie pieniedzy
        if (currentMoney == 0)
        {
            currentMoney = 100;
        }
        else if (numberOfQuestion > 10 && numberOfQuestion < 15)
        {
            currentMoney = currentMoney/2 * 3;
        }
        else if (numberOfQuestion == 15)
        {
            currentMoney = 1000000;
        }
        else
        {
            currentMoney = currentMoney * 2; //numberOfQuestion;
        }
        moneyText.text = "$ " + currentMoney.ToString();

        if (noGOPhase == true)
        {
            noGOActive.SetActive(false);
            noGOUsed.SetActive(true);
            noGOPhase = false;
        }

        if (ftftPhase == true)
        {
            
            ftftActive.SetActive(false);
            ftftUsed.SetActive(true);
            aB.SetActive(true);
            bB.SetActive(true);
            cB.SetActive(true);
            dB.SetActive(true);
            ftftPhase = false;
        }

        numberOfAnswered++;

        StartCoroutine(ExecuteAfterTime(time));

    }

    public void wrong()
    {
        name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        changeColorToCorrect();
        changeColorToWrong();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (ftftPhase == true)
        {

            ftftActive.SetActive(false);
            ftftUsed.SetActive(true);
            aB.SetActive(true);
            bB.SetActive(true);
            cB.SetActive(true);
            dB.SetActive(true);
            ftftPhase = false;
        }

        if (noGOPhase == true)
        {
            noGOActive.SetActive(false);
            noGOUsed.SetActive(true);
            noGOPhase = false;

            StartCoroutine(ExecuteAfterTime(time));
        }
        else
        {
            StartCoroutine(ExecuteAfterGO(time));
        }
        
        //PiO.RemoveAt(currentQuestion);
        //generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PiO[currentQuestion].Answers[i];

            if (PiO[currentQuestion].CorrectAnswer == i + 1)
            {
                corAnswer = i;
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (PiO.Count > 0)
        {
            currentQuestion = Random.Range(0, PiO.Count);
            QNumText.text = numberOfQuestion.ToString() + "/" + IlPytan.ToString();
            QuestionText.text = PiO[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Nie ma pytan");
            GameOver();
        }
    }


}

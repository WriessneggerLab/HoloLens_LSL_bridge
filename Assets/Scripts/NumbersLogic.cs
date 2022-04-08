using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class NumbersLogic : MonoBehaviour
{
    private TMP_Text mainFieldText;
    private GameObject gameField;
    private GameObject startButton;
    private TMP_Text titleBarText;
    private GameObject finalScore;
    private TMP_Text finalScoreText;

    private TMP_Text[] answerButtons;

    private const int LVL_TIME = 12;//*5*5;
    private const int TIME_ANSWER_1 = 12;
    private const int TIME_ANSWER_2 = 6;
    private const int TIME_ANSWER_3 = 3;
    private const int QUESTIONS = LVL_TIME / TIME_ANSWER_1 + LVL_TIME / TIME_ANSWER_2 + LVL_TIME / TIME_ANSWER_3;

    private int result;
    private int chosenAnswer = 0;
    private int correctAnswer = 0;
    private DateTime startTime;
    private int questionCounter = 1;
    private int lvl_time = TIME_ANSWER_1;
    private bool gameStarted = false;
    System.Random rnd;

    private List<bool> answers;

    private void Start()
    {
        rnd = new System.Random();
        answers = new List<bool>();
        answerButtons = new TMP_Text[3];

        mainFieldText = GetComponent<TMP_Text>();
        startButton = GameObject.Find("Start Button");
        gameField = GameObject.Find("Game");
        titleBarText = GameObject.Find("Title TitleBar Numbers").GetComponent<TMP_Text>();
        answerButtons[0] = GameObject.Find("Button Answer 1 Text").GetComponent<TMP_Text>();
        answerButtons[1] = GameObject.Find("Button Answer 2 Text").GetComponent<TMP_Text>();
        answerButtons[2] = GameObject.Find("Button Answer 3 Text").GetComponent<TMP_Text>();
        finalScore = GameObject.Find("Final Score");
        finalScoreText = GameObject.Find("Final Score Text").GetComponent<TMP_Text>(); ;
        finalScore.SetActive(false);

        gameField.SetActive(false);
    }

    private void Update()
    {
        if (gameStarted == true)
        {
            // Next calculation
            if ((DateTime.Now - startTime).TotalSeconds >= lvl_time*questionCounter)
            {
                questionCounter++;

                if (chosenAnswer != 0)
                    WriteResult(Int32.Parse(answerButtons[chosenAnswer - 1].text), correctAnswer);
                else
                    WriteResult(123456, correctAnswer);

                if (chosenAnswer != 0)
                {
                    answerButtons[chosenAnswer - 1].color = Color.white;
                    chosenAnswer = 0;
                }

                correctAnswer = SetNumbers(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 4));
            }

            // Next levels and quit
            if (questionCounter - 1 == (LVL_TIME / TIME_ANSWER_1) && lvl_time == TIME_ANSWER_1)
            {
                Log.AddText($"{questionCounter}-1 == {LVL_TIME}/{TIME_ANSWER_1}");
                questionCounter = 1;
                startTime = DateTime.Now;
                lvl_time = TIME_ANSWER_2;
                titleBarText.text = $"{lvl_time} seconds per question.";

                LslSend.SendOutlet("Start - Level 2");
            }
            else if (questionCounter - 1 == (LVL_TIME / TIME_ANSWER_2) && lvl_time == TIME_ANSWER_2)
            {
                questionCounter = 1;
                startTime = DateTime.Now;
                lvl_time = TIME_ANSWER_3;
                titleBarText.text = $"{lvl_time} seconds per question.";

                LslSend.SendOutlet("Start - Level 3");
            }
            else if (questionCounter - 1 == (LVL_TIME / TIME_ANSWER_3) && lvl_time == TIME_ANSWER_3)
            {
                gameField.SetActive(false);

                LslSend.SendOutlet("End");

                finalScore.SetActive(true);
                finalScoreText.text += $"{answers.Count(c => c == true)} / {answers.Count()}";
            }
        }
    }

    public void StartButtonBress()
    {
        startTime = DateTime.Now;

        gameField.SetActive(true);
        startButton.SetActive(false);

        titleBarText.text = $"{TIME_ANSWER_1} seconds per question.";

        //Send LSL
        LslSend.SendOutlet("Start - Level 1");


        Log.AddText($"Game started! {QUESTIONS} Questions incoming!");

        correctAnswer = SetNumbers(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 4));
        gameStarted = true;
    }

    public void AnswerButtonPressed(int _answer)
    {
        if (chosenAnswer == _answer)
        {
            answerButtons[_answer - 1].color = Color.white;
            chosenAnswer = 0;
        }
        else
        {
            answerButtons[_answer - 1].color = Color.green;
            if (chosenAnswer != 0)
                answerButtons[chosenAnswer - 1].color = Color.white;
            chosenAnswer = _answer;
        }
    }

    private int SetNumbers(int _first, int _second, int _operation)
    {
        if (_operation == 1)
        {
            result = _first + _second;
            mainFieldText.text = $"{_first} + {_second} = ___";
        }
        else if (_operation == 2)
        {
            result = _first - _second;
            mainFieldText.text = $"{_first} - {_second} = ___";
        }
        else if (_operation == 3)
        {
            result = _first * _second;
            mainFieldText.text = $"{_first} * {_second} = ___";
        }

        int rightAnswer = rnd.Next(0, 3);

        for (int i = 0; i < 3; i++)
        {
            if (rightAnswer == i)
            {
                answerButtons[i].text = result.ToString();
            }
            else
            {
                int op = rnd.Next(0, 2);

                if (op == 0)
                    answerButtons[i].text = (result + rnd.Next(0,30)).ToString();
                else
                    answerButtons[i].text = (result - rnd.Next(0,30)).ToString();
            }
        }

        return result;
    }

    private void WriteResult(int _chosenAnswer, int _rightAnswer)
    {
        if (_chosenAnswer == 123456)
        {
            answers.Add(false);
        }
        else
        {
            if (_chosenAnswer == _rightAnswer)
                answers.Add(true);
            else
                answers.Add(false);
        }
    }

    public void ResetScene()
    {
        LslSend.SendOutlet("Reset");

        SceneManager.LoadScene("Main");
    }

}

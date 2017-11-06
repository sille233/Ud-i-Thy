using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class quizScript : MonoBehaviour {

    public string[] correctAnswers, questions;
    public string[][] answers = new string[2][];
    public Text[] labels;
    public Text questionLabel;
    //private string chosenAnswer;
    private int answerCount = 0;
    private int score = 0;

    // Use this for initialization
    void Start () {
        loadQA();
        loadNewQuestion();
        Debug.Log(questions.Length);
	}

    private void loadQA() {
        answers[0] = new string[3] {"rødhals", "blåfugl", "kanarie"};
        answers[1] = new string[3] { "struds", "påfugl", "ørn" };
        correctAnswers = new string[2] {"rødhals", "ørn" };
        questions = new string[2] { "hvilken fugl er det?", "hvad med den her?" };
    }

    public void questionPicked() {
        GameObject pickedButton = EventSystem.current.currentSelectedGameObject;
        string pickedAnswer = pickedButton.GetComponentInChildren<Text>().text;
        checkAnswer(pickedAnswer);
        loadNewQuestion();
    }

    private void checkAnswer(string pickedAnswer) {
        if (answerCount < questions.Length && pickedAnswer == correctAnswers[answerCount]) {
            score++;
            Debug.Log("du gættede rigtigt");
        };
        answerCount++;
    }

    public void loadNewQuestion() {
        if (answerCount< questions.Length) {
            for (int i = 0; i < labels.Length; i++) {
                labels[i].text = answers[answerCount][i];
                questionLabel.text = questions[answerCount];
            }
        }
        //labels[0].text = "potato";
    }
}

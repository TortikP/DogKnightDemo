using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsUI : MonoBehaviour
{

    public TMP_Text question;
    public Button[] answers;
    public GameObject questionField;
    public GameObject resultField;
    private Test[] test = new Test[3];
    int currentQuestion;
    // Start is called before the first frame update
    void Start()
    {
        test[0] = new Test {
            question = "Сколько вам лет",
            answers = new Answer[] {
                new Answer
                {
                    answerText = "18",
                    isCorrect = true
                },
                new Answer
                {
                    answerText = "19",
                    isCorrect = false
                },
                new Answer
                {
                    answerText = "20",
                    isCorrect = false
                }
            }
        };
        test[1] = new Test
        {
            question = "Как вас зовут",
            answers = new Answer[] {
                new Answer
                {
                    answerText = "Иван",
                    isCorrect = true
                },
                new Answer
                {
                    answerText = "Олег",
                    isCorrect = false
                },
                new Answer
                {
                    answerText = "Вася",
                    isCorrect = false
                }
            }

        };
        test[2] = new Test
        {
            question = "Во сколько встаете",
            answers = new Answer[] {
                new Answer
                {
                    answerText = "8:00",
                    isCorrect = true
                },
                new Answer
                {
                    answerText = "7:30",
                    isCorrect = false
                },
                new Answer
                {
                    answerText = "6:00",
                    isCorrect = false
                }
            }
        };
        Generate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Generate()
    {
        if (currentQuestion < test.Length)
        {
            int i = 0;
            System.Random rand = new System.Random();
            test[currentQuestion].answers = test[currentQuestion].answers.OrderBy(x => rand.Next()).ToArray();
            foreach (var answer in test[currentQuestion].answers)
            {
                question.text = test[currentQuestion].question;
                answers[i].GetComponentInChildren<TMP_Text>().text = answer.answerText;
                i++;
            }
        }
        else
        {
            questionField.SetActive(false);
            resultField.SetActive(true);
        }
    }

    public void QuestionAnswer(int num)
    {
        if (test[currentQuestion].answers[num].isCorrect)
        {
            currentQuestion++;
            print("Correct Answer");
            Generate();
        }
        else
        {
            print("Incorrect Answer");
        }
    }
}

class Test
{
    public string question;
    public Answer[] answers;
}

class Answer {
    public string answerText;
    public bool isCorrect;
}


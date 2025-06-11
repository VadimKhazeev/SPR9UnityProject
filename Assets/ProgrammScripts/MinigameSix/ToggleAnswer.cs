using UnityEngine;

public class ToggleAnswer : MonoBehaviour
{
    public AnswerType answerType; // Тип ответа: верный, неверный или нейтральный
}

public enum AnswerType
{
    Correct,   // Верный
    Neutral,   // Нейтральный
    Incorrect  // Неверный
}

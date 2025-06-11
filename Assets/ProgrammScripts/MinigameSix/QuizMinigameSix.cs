using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizMinigameSix : MonoBehaviour
{
    public Slider scoreSlider; // Ссылка на Slider
    public Button doneButton;  // Ссылка на кнопку "Готово"
    public Toggle[] toggles;   // Массив всех Toggles
    public Text scoreText;     // Ссылка на текстовое поле для текущих очков

    [Header("Game Settings")]
    [Tooltip("Число, которое нужно набрать для активации кнопки")]
    public int maxScore = 10;  // Максимальное количество очков (видимо в инспекторе)
    [Tooltip("Минимальное число очков, которое может быть у игрока")]
    public int minScore = -5;  // Минимальное количество очков (видимо в инспекторе)

    private int currentScore = 0; // Текущий счёт игрока
    private HashSet<Toggle> processedToggles = new HashSet<Toggle>(); // Список обработанных Toggles

    void Start()
    {
        // Устанавливаем диапазон для Slider
        scoreSlider.minValue = minScore;
        scoreSlider.maxValue = maxScore;

        // Устанавливаем начальный текст
        UpdateScoreText();

        // Отключаем кнопку "Готово" в начале
        doneButton.interactable = false;

        // Привязываем обработчик событий ко всем Toggle
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate { OnToggleChanged(toggle); });
        }
    }

    void OnToggleChanged(Toggle changedToggle)
    {
        // Если Toggle уже обработан, пропускаем
        if (processedToggles.Contains(changedToggle))
            return;

        // Определяем тип ответа на Toggle
        AnswerType answer = changedToggle.GetComponent<ToggleAnswer>().answerType;

        // Изменяем счёт в зависимости от ответа
        if (changedToggle.isOn)
        {
            if (answer == AnswerType.Correct)
                currentScore += 1;
            else if (answer == AnswerType.Incorrect)
                currentScore -= 1;

            // Добавляем Toggle в список обработанных
            processedToggles.Add(changedToggle);
        }

        // Обновляем значение слайдера
        currentScore = Mathf.Clamp(currentScore, minScore, maxScore);
        scoreSlider.value = currentScore;

        // Обновляем текст текущих очков
        UpdateScoreText();

        // Активируем кнопку, если достигнут максимум
        doneButton.interactable = (currentScore == maxScore);
    }

    void UpdateScoreText()
    {
        // Обновляем текстовое поле с текущими очками
        scoreText.text = $"{currentScore}";
    }
}

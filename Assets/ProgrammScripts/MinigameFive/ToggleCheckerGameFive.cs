using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleCheckerGameFive : MonoBehaviour
{
    public List<Toggle> correctToggles; // Список верных Toggle
    public Button doneButton; // Кнопка "Готово"
    
    public List<GameObject> winObjects; // Объекты, которые активируются при победе
    public List<GameObject> loseObjects; // Объекты, которые активируются при поражении

    // Структура для хранения неверных Toggle и связанных объектов
    [System.Serializable]
    public class IncorrectToggleData
    {
        public Toggle toggle; // Неверный Toggle
        public List<GameObject> relatedObjects; // Объекты, связанные с этим Toggle
    }

    public List<IncorrectToggleData> incorrectToggleDataList; // Список неверных Toggle с объектами
    public List<GameObject> correctToggleObjects; // Объекты, связанные с верными Toggle

    void Start()
    {
        doneButton.interactable = false; // Изначально кнопка не активна

        // Добавляем обработчики для каждого Toggle
        foreach (var toggle in correctToggles)
        {
            toggle.onValueChanged.AddListener(delegate { CheckToggles(); });
        }

        foreach (var incorrectData in incorrectToggleDataList)
        {
            incorrectData.toggle.onValueChanged.AddListener(delegate { CheckToggles(); });
        }
    }

    void CheckToggles()
    {
        bool anySelected = false;

        // Проверка, выбрано ли хотя бы одно значение
        foreach (var toggle in correctToggles)
        {
            if (toggle.isOn)
            {
                anySelected = true;
                break;
            }
        }
        foreach (var incorrectData in incorrectToggleDataList)
        {
            if (incorrectData.toggle.isOn)
            {
                anySelected = true;
                break;
            }
        }

        doneButton.interactable = anySelected;
    }

    public void OnDoneButtonClicked()
    {
        bool hasIncorrect = false;
        int correctSelectedCount = 0;

        // Активируем объекты, связанные с верными Toggle, и считаем их количество
        for (int i = 0; i < correctToggles.Count; i++)
        {
            if (correctToggles[i].isOn)
            {
                correctToggleObjects[i].SetActive(true);
                correctSelectedCount++;
            }
        }

        // Проверяем и активируем объекты, связанные с неверными Toggle
        foreach (var incorrectData in incorrectToggleDataList)
        {
            if (incorrectData.toggle.isOn)
            {
                hasIncorrect = true; // Если выбран неверный, устанавливаем флаг

                // Активируем связанные объекты
                foreach (var obj in incorrectData.relatedObjects)
                {
                    obj.SetActive(true);
                }
            }
        }

        // Проверка на поражение
        if (hasIncorrect || correctSelectedCount != correctToggles.Count)
        {
            ActivateObjects(loseObjects); // Активируем объекты поражения
        }
        else if (correctSelectedCount == correctToggles.Count)
        {
            ActivateObjects(winObjects); // Активируем объекты победы
        }
    }

    private void ActivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }
}

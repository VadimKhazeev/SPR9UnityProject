using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UniqueButtonClickCounter : MonoBehaviour
{
    public int requiredUniqueClicks = 3;  // Количество уникальных нажатий для активации объектов
    public List<Button> buttons;  // Список кнопок, назначаемых через инспектор
    public List<GameObject> objectsToActivate;  // Список объектов для активации
    public List<GameObject> objectsToDeactivate;  // Список объектов для деактивации

    private HashSet<Button> clickedButtons = new HashSet<Button>();

    private void Start()
    {
        // Привязываем метод к событию OnClick каждой кнопки в списке
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.onClick.AddListener(() => OnButtonClick(button));
            }
        }
    }

    // Метод для обработки нажатий на кнопки
    private void OnButtonClick(Button button)
    {
        if (!clickedButtons.Contains(button))
        {
            clickedButtons.Add(button);
            Debug.Log("Нажата уникальная кнопка: " + button.name);

            // Проверка, достигнуто ли необходимое количество уникальных нажатий
            if (clickedButtons.Count >= requiredUniqueClicks)
            {
                ActivateObjects();
                DeactivateObjects();
            }
        }
    }

    // Метод для активации всех объектов из списка
    private void ActivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
                Debug.Log("Объект " + obj.name + " активирован!");
            }
        }
    }

    // Метод для деактивации всех объектов из списка
    private void DeactivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                Debug.Log("Объект " + obj.name + " деактивирован!");
            }
        }
    }
}

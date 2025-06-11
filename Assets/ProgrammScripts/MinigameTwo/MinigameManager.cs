using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour {
    [System.Serializable]
    public class SlotGroup {
        public List<ItemSlotMinigameTwo> slots; // Слоты в группе
        public int requiredCorrectCount; // Требуемое количество правильных карточек
        public GameObject successObject; // Объект при успехе группы
        public GameObject failureObject; // Объект при ошибке группы
    }

    public List<ItemSlotMinigameTwo> slots; // Все слоты
    public List<GameObject> globalSuccessObjects; // Глобальные объекты при успехе
    public List<GameObject> globalFailureObjects; // Глобальные объекты при ошибке
    public List<SlotGroup> slotGroups; // Группы слотов

    // Проверка всех слотов и групп при нажатии кнопки "Готово"
    public void OnReadyButton() {
        bool allGlobalCorrect = true;

        foreach (var group in slotGroups) {
            int correctCount = 0;

            foreach (var slot in group.slots) {
                slot.CheckCard(); // Проверяем карточку в каждом слоте
                if (slot.IsCorrect()) {
                    correctCount++;
                }
            }

            // Проверяем, достигли ли нужного количества правильных карточек
            if (correctCount >= group.requiredCorrectCount) {
                if (group.successObject != null) group.successObject.SetActive(true);
                if (group.failureObject != null) group.failureObject.SetActive(false);
            } else {
                if (group.failureObject != null) group.failureObject.SetActive(true);
                if (group.successObject != null) group.successObject.SetActive(false);
                allGlobalCorrect = false;
            }
        }

        foreach (var slot in slots) {
            if (!slot.IsCorrect()) {
                allGlobalCorrect = false;
            }
        }

        // Включаем глобальные объекты
        if (allGlobalCorrect) {
            foreach (var obj in globalSuccessObjects) obj.SetActive(true);
            foreach (var obj in globalFailureObjects) obj.SetActive(false);
        } else {
            foreach (var obj in globalFailureObjects) obj.SetActive(true);
            foreach (var obj in globalSuccessObjects) obj.SetActive(false);
        }
    }

    // Сброс всех слотов и групп при нажатии кнопки "Сброс"
    public void OnResetButton() {
        foreach (var slot in slots) {
            slot.ResetSlot();
        }

        foreach (var obj in globalSuccessObjects) obj.SetActive(false);
        foreach (var obj in globalFailureObjects) obj.SetActive(false);

        foreach (var group in slotGroups) {
            foreach (var slot in group.slots) {
                slot.ResetSlot();
            }

            if (group.successObject != null) group.successObject.SetActive(false);
            if (group.failureObject != null) group.failureObject.SetActive(false);
        }
    }
}

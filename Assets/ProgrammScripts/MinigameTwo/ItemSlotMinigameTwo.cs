using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotMinigameTwo : MonoBehaviour, IDropHandler {
    public List<int> validCardIDs; // Список ID подходящих карточек
    public bool allowEmptyAsCorrect = false; // Учитывать ли пустой слот как правильный
    public List<GameObject> successObjects; // Список объектов при успехе
    public List<GameObject> failureObjects; // Список объектов при ошибке
    private Card currentCard; // Текущая вставленная карточка

    // Устанавливаем карточку в слот
    public void SetCard(Card card) {
        currentCard = card;
    }

    // Удаляем карточку из слота
    public void RemoveCard() {
        currentCard = null;
    }

    // Проверяем, является ли слот правильным
    public bool IsCorrect() {
        if (currentCard == null && allowEmptyAsCorrect) {
            return true; // Пустой слот считается правильным
        }

        return currentCard != null && validCardIDs.Contains(currentCard.cardID);
    }

    // Включаем SuccessObjects при правильной карточке
    public void ActivateSuccess() {
        foreach (var obj in successObjects) {
            if (obj != null) obj.SetActive(true);
        }
        foreach (var obj in failureObjects) {
            if (obj != null) obj.SetActive(false);
        }
    }

    // Включаем FailureObjects при неправильной карточке
    public void ActivateFailure() {
        foreach (var obj in failureObjects) {
            if (obj != null) obj.SetActive(true);
        }
        foreach (var obj in successObjects) {
            if (obj != null) obj.SetActive(false);
        }
    }

    // Логика при перетаскивании карточки в слот
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            if (currentCard != null) {
                return; // Слот уже занят
            }

            Card card = eventData.pointerDrag.GetComponent<Card>();
            if (card != null) {
                // Устанавливаем карточку дочерним объектом слота
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                // Сохраняем ссылку на текущую карточку
                SetCard(card);
            }
        }
    }

    // Удаляем карточку, если она покидает слот
    public void OnCardRemoved(Card card) {
        if (currentCard == card) {
            currentCard.ReturnToOriginalParent(); // Возвращаем карточку
            RemoveCard();
        }
    }

    // Проверка карточки по нажатию кнопки "Готово"
    public void CheckCard() {
        if (IsCorrect()) {
            ActivateSuccess();
        } else {
            ActivateFailure();
        }
    }

    // Сброс состояния слота
    public void ResetSlot() {
        if (currentCard != null) {
            currentCard.ReturnToOriginalParent();
            currentCard = null;
        }

        foreach (var obj in successObjects) {
            if (obj != null) obj.SetActive(false);
        }
        foreach (var obj in failureObjects) {
            if (obj != null) obj.SetActive(false);
        }
    }
}

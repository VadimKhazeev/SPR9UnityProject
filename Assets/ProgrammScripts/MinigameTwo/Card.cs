using UnityEngine;

public class Card : MonoBehaviour {
    public int cardID; // Уникальный ID карточки
    public Transform originalParent; // Исходный родитель карточки

    // Возвращаем карточку к оригинальному родителю
    public void ReturnToOriginalParent() {
        if (originalParent != null) {
            transform.SetParent(originalParent);
            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}

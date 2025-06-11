using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCheckManager : MonoBehaviour
{
    public List<ItemSlot> itemSlots; // ������ ������
    public Button checkButton;

    public GameObject objectToDisable; // ������, ����������� ��� ���������� ������

    private void Start()
    {
        checkButton.onClick.AddListener(CheckAnswers);
    }

    private void CheckAnswers()
    {
        bool allCorrect = true;

        foreach (ItemSlot slot in itemSlots)
        {
            bool isSlotCorrect = slot.CheckAnswer();
            slot.HandleObjectsActivation();

            if (!isSlotCorrect)
            {
                allCorrect = false;
            }
        }

        if (allCorrect)
        {
            objectToDisable.SetActive(false);
        }
    }
}

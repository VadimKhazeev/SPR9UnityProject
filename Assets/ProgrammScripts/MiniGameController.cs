using Naninovel;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    // ������ UI ��������� ��� ����-���
    public List<GameObject> miniGameUIs;

    // ������ ���� ���������� ��� ������ ����-����
    public List<string> customVariableNames;

    private ICustomVariableManager variableManager;
    private List<string> previousVariableValues;

    void Start()
    {
        // ���������, ��� ���������� ���������� ������������� ���������� UI ���������
        if (miniGameUIs.Count != customVariableNames.Count)
        {
            Debug.LogError("���������� UI ��������� � ���������� �� ���������.");
            return;
        }

        // �������� ������ ��� ������ � �����������
        variableManager = Engine.GetService<ICustomVariableManager>();

        // �������������� ������ ���������� �������� ����������
        previousVariableValues = new List<string>();

        // ��� ������ ���������� ��������� ��������� ���������
        for (int i = 0; i < customVariableNames.Count; i++)
        {
            string initialValue = variableManager.GetVariableValue(customVariableNames[i]);
            previousVariableValues.Add(initialValue);
            CheckMiniGameState(i, initialValue);
        }
    }

    void Update()
    {
        // ��� ������ ���������� ��������� ������� ��������� � ���������, ���� ��� ����������
        for (int i = 0; i < customVariableNames.Count; i++)
        {
            string currentVariableValue = variableManager.GetVariableValue(customVariableNames[i]);

            // ���� �������� ����������, ��������� ��������� ��������������� ����-����
            if (currentVariableValue != previousVariableValues[i])
            {
                CheckMiniGameState(i, currentVariableValue);
                previousVariableValues[i] = currentVariableValue;
            }
        }
    }

    void CheckMiniGameState(int index, string variableValue)
    {
        // ���� ���������� �� ���������������� ��� ����� ������ ������, ��������� ��������������� UI �������
        if (string.IsNullOrEmpty(variableValue))
        {
            miniGameUIs[index].SetActive(false);
            return;
        }

        // ���� ���������� ����� "1", ���������� ��������������� UI �������
        if (variableValue == "1")
        {
            miniGameUIs[index].SetActive(true);
        }
        // ���� ���������� ����� "0", ������������ ��������������� UI �������
        else if (variableValue == "0")
        {
            miniGameUIs[index].SetActive(false);
        }
    }
}

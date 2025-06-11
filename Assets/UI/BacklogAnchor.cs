using UnityEngine;

public class BacklogAnchor : MonoBehaviour
{
    public RectTransform pcUI;   // UI ��� ��
    public RectTransform mobileUI;  // UI ��� ���������

    void Start()
    {
        AdjustUI();
    }

    void AdjustUI()
    {
        if (Application.isMobilePlatform)
        {
            // ��� ��������� ���������, UI ����� �������� ���� �����
            mobileUI.anchorMin = new Vector2(0, 0);
            mobileUI.anchorMax = new Vector2(1, 1);
            mobileUI.offsetMin = Vector2.zero; // ������� �������
            mobileUI.offsetMax = Vector2.zero; // ������� �������
        }
        else
        {
            // ��� ��, UI ����� �������� �������� ������
            pcUI.anchorMin = new Vector2(0.4f, 0);  // �������� ������
            pcUI.anchorMax = new Vector2(1, 1);    // ������� ��������
            pcUI.offsetMin = Vector2.zero;
            pcUI.offsetMax = Vector2.zero;
        }
    }
}

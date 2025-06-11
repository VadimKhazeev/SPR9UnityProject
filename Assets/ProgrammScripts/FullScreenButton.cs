using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI

public class FullScreenToggleButton : MonoBehaviour
{
    public Image fullScreenButtonImage;  // ������ �� UI ������� ������ (��������)
    public Sprite fullScreenSprite;      // ������ ��� �������������� ������
    public Sprite windowedSprite;        // ������ ��� �������� ������

    // ����� ��� ������ ��� ������� ������
    public void ToggleFullScreen()
    {
        // ��������, ������������ �� ������� ������������� �����
        if (Screen.fullScreen == false)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }

        // ��������� ����������� ������
        UpdateButtonImage();
    }

    // ����� ��� ���������� ����������� ������
    void UpdateButtonImage()
    {
        if (Screen.fullScreen)
        {
            fullScreenButtonImage.sprite = fullScreenSprite;  // ����������� ��� �������������� ������
        }
        else
        {
            fullScreenButtonImage.sprite = windowedSprite;    // ����������� ��� �������� ������
        }
    }

    // ������������� ��������� �� ������
    void Start()
    {
        // ������ ������� �� ������ (��� �������, ��� � ��� ���� Button ���������)
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ToggleFullScreen);
        }

        UpdateButtonImage();
    }
}

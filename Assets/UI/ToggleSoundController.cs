using UnityEngine;
using UnityEngine.UI;
using UISwitcher; // ���������� ������������ ���� UISwitcher

public class ToggleSoundController : MonoBehaviour
{
    // ������ �� ������
    public Button toggleSoundButton;

    // ������ �� UISwitcher
    public UISwitcher.UISwitcher soundSwitcher;

    // ���������� ��� �������� ��������� (�������/��������)
    private bool isSoundOn = true;

    void Start()
    {
        // ��������� ��������� ��� ������
        toggleSoundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        // ����������� ���������
        isSoundOn = !isSoundOn;

        if (isSoundOn)
        {
            // �������� ��������� UISwitcher
            soundSwitcher.Activate();
        }
        else
        {
            // ��������� ��������� UISwitcher
            soundSwitcher.Deactivate();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using Naninovel;

public class ToggleSoundMobile : MonoBehaviour
{
    // ������ �� ������
    public Button toggleSoundButton;

    // ���������� ��� �������� ��������� �����
    private bool isMuted = false;

    // ������ �� ����� �������� Naninovel
    private IAudioManager audioManager;

    // ���������� ��� �������� ��������� �������� ���������
    private float initialBgmVolume;
    private float initialSfxVolume;
    private float initialVoiceVolume;

    // ������ �� Slider ��� ����������� ���������
    public Slider volumeSlider;

    void Start()
    {
        // �������� ������ �� ����� �������� Naninovel
        audioManager = Engine.GetService<IAudioManager>();

        // ��������� ��������� �������� ���������
        initialBgmVolume = audioManager.BgmVolume;
        initialSfxVolume = audioManager.SfxVolume;
        initialVoiceVolume = audioManager.VoiceVolume;

        // ��������� ��������� ��� ������
        toggleSoundButton.onClick.AddListener(ToggleSoundMute);

        // ��������� ��������� ��� ��������� �������� Slider
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // ������������� Slider � �������� ���������, ���� ���� �������
        //volumeSlider.gameObject.SetActive(!isMuted);

        // ������������� ������� �������� ��������� ��� Slider
        volumeSlider.value = initialBgmVolume;
    }

    // ����� ��� ���������� ��� ��������� �����
    void ToggleSoundMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            // ��������� ����
            audioManager.BgmVolume = 0f;
            audioManager.SfxVolume = 0f;
            audioManager.VoiceVolume = 0f;

            // ������������ Slider
            volumeSlider.gameObject.SetActive(false);
        }
        else
        {
            // �������� ���� � ��������� �������� ���������
            audioManager.BgmVolume = initialBgmVolume;
            audioManager.SfxVolume = initialSfxVolume;
            audioManager.VoiceVolume = initialVoiceVolume;

            // ���������� Slider
            volumeSlider.gameObject.SetActive(true);
        }
    }

    // ����� ��� ��������� ��������� ����� Slider
    void SetVolume(float value)
    {
        // ������������� ��������� ��� ���� ����� �����
        audioManager.BgmVolume = value;
        audioManager.SfxVolume = value;
        audioManager.VoiceVolume = value;

        // ��������� ��������� ��������, ���� �� ����� ���������
        initialBgmVolume = value;
        initialSfxVolume = value;
        initialVoiceVolume = value;
    }
}

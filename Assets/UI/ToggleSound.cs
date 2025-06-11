using UnityEngine;
using UnityEngine.UI;
using Naninovel;

public class ToggleSound : MonoBehaviour
{
    // ��� ������ �� ������
    public Button toggleSoundButton;

    // ������ �� ����������� ��� ��������� �����
    public Image soundButtonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    // ���������� ��� �������� ��������� �����
    private bool isMuted = false;

    // ������ �� ����� �������� Naninovel
    private IAudioManager audioManager;

    // ���������� ��� �������� ��������� �������� ���������
    private float initialBgmVolume;
    private float initialSfxVolume;
    private float initialVoiceVolume;

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

        // ������������� ��������� ����������� ������
        UpdateButtonImage();
    }

    void Update()
    {
        // ���������, ���� �� ������ ������� M
        if (Input.GetKeyDown(KeyCode.M))
        {
            // �������� ����� ������������ �����
            ToggleSoundMute();
        }
    }

    void ToggleSoundMute()
    {
        // ����������� ��������� �����
        isMuted = !isMuted;

        if (isMuted)
        {
            // ��������� ����
            audioManager.BgmVolume = 0f;
            audioManager.SfxVolume = 0f;
            audioManager.VoiceVolume = 0f;
        }
        else
        {
            // �������� ����
            audioManager.BgmVolume = initialBgmVolume;
            audioManager.SfxVolume = initialSfxVolume;
            audioManager.VoiceVolume = initialVoiceVolume;
        }

        // ��������� ����������� ������
        UpdateButtonImage();
    }

    void UpdateButtonImage()
    {
        if (isMuted)
        {
            soundButtonImage.sprite = soundOffSprite;
        }
        else
        {
            soundButtonImage.sprite = soundOnSprite;
        }
    }
}

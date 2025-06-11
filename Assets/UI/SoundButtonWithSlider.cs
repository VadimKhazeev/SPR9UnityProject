using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SoundButtonWithSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Slider volumeSlider;    // ������ �� Slider
    public float hideDelay = 5.0f; // �������� ����� �������� Slider
    private Coroutine hideCoroutine;

    void Start()
    {
        // ���������, ��� Slider ���������� �����
        volumeSlider.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ������������� �������, ���� ��� ��������
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        // ���������� Slider ��� ���������
        volumeSlider.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ��������� �������� ��� ������� Slider ����� �������� �����
        hideCoroutine = StartCoroutine(HideSliderAfterDelay());
    }

    private IEnumerator HideSliderAfterDelay()
    {
        // ���� �������� ���������� �������
        yield return new WaitForSeconds(hideDelay);

        // �������� Slider, ���� ����� �� ���������
        volumeSlider.gameObject.SetActive(false);
    }
}

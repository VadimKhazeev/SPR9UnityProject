using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Naninovel;

public class ProgressBar : MonoBehaviour
{
    public Slider slider; // ������ �� ��������� Slider � Unity UI
    //public Text valueText; // ������ �� ��������� Text, ������� �������� �������� � ������� ������
    public static string ProgressScore;
   // public GameObject EncyclopediaMechanic; // ����� ������������
   // public GameObject SaveMechanic; // ����� ������ ����������
   // public GameObject SoundAndMusic;
   // public GameObject FullScrean;

    private void Start()
    {
        StartCoroutine(CoroutineSample());
        // ������������� ��������� �������� ��������
        slider.value = 0; // ��������, ��������� �������� �� ��������� � 0f
    }

    private IEnumerator CoroutineSample()
    {
        while (true)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            ProgressScore = variableManager.GetVariableValue("Progress");
            // �������� �������� � ������� ������ �� ���������� Text
            string valueString = ProgressScore;

            // �������� ������������� �������� � ��� int
            if (int.TryParse(valueString, out int valueInt))
            {
                //EncyclopediaMechanic.SetActive(true); // �������� ������������
               // SaveMechanic.SetActive(true);
               // SoundAndMusic.SetActive(true);
               // FullScrean.SetActive(true);
                // ���� �������������� ������ �������, ������������� ��� � Slider
                slider.value = valueInt;
            }
            else
            {
                // ��������� ������, ���� �������� �� ����� ���� ������������� � int
                Debug.Log("������ �������������� ������ � int");
            }

            yield return new WaitForSeconds(3);
        }
    }
}

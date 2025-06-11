using UnityEngine;
using Naninovel;
using System.Threading.Tasks;

public class Save : MonoBehaviour
{
    // ������ �� ��������� Animator
    public Animator animator;

    // ���� ����� ��������� ���������� ��������� ���� � ���������� ��������
    public async void OnButtonClick()
    {
        // ����� ������ ��������
        TriggerAnimation();

        // ���������� ����������
        var stateManager = Engine.GetService<IStateManager>();
        await stateManager.QuickSaveAsync();
    }

    // ����� ��� ������ ��������
    private void TriggerAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Clicker");
        }
        else
        {
            Debug.LogWarning("Animator �� ��������.");
        }
    }

    // ����� Update ���������� ������ ����
    private void Update()
    {
        // ���������, ���� �� ������ ������� S
        if (Input.GetKeyDown(KeyCode.S))
        {
            // �������� �����, ��� ����� ������ ������
            OnButtonClick();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    private float timeRemaining = 0; // ������
    public int countCol; // ���������� ������������
    public Text timer; // UI ������� �������
    public Text collision; // UI ������� ������������

    private void Update()
    {
        timeRemaining += Time.deltaTime; // ���������� ������
        timer.text = ("������� ������: " + (int)timeRemaining).ToString(); // ������� ������, �������� ������� �����
        collision.text = "������������: " + (countCol / 2).ToString(); // ������� ������������. ����� �� 2, ��� ��� ������ ������ ������������ ��������� ��� �����
    }

    public void Click() // �������� ��������
    {
        countCol = 0;
        timeRemaining = 0;
    }
}

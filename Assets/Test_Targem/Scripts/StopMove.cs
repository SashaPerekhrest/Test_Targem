using UnityEngine;

public class StopMove : MonoBehaviour
{
    public GameObject figure; // ���� ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GravityPoint") // ���� ��������� � ����� ����������
        {
            figure.transform.position = other.transform.position;     // ������ ������� ������ ��� � GravityPoint
            figure.GetComponent<ChangingGravity>().isMoved = false;   // �������, ��� ��� �� ���������
            figure.GetComponent<Rigidbody>().velocity = Vector3.zero; // �������� �� ��������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GravityPoint")
            GetComponentInParent<ChangingGravity>().isMoved = true; // �������, ��� ������ ��������� 
    }
}

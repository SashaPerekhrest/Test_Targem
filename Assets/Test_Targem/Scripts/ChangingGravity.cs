using UnityEngine;

public class ChangingGravity : MonoBehaviour
{
    public Transform worldGravityPoint; // ����� ����������
    public float force; // ���� ���������� � ������
    public bool isMoved; // ��������� �� ������
    public bool isHit; // ��������� �� ������
    private Rigidbody figureRB; // rigidbody ������
    private Vector3 deltaPos; // ������� ������� ��� �������� ������
    private float magnitude; // ��������, � ������� �������� ������
    public Material material; // �������� ��� ����� �����

    private void Awake() // ���������� ����������
    {
        figureRB = GetComponent<Rigidbody>();
        figureRB.centerOfMass = Vector3.zero;
        magnitude = 0;
    }

    void FixedUpdate()
    {
        if (isMoved)
        {
            deltaPos = worldGravityPoint.position - transform.position; // ��������� ������ ����� ������� � GP
            if (figureRB.velocity.magnitude > magnitude && isHit) // ���� �������� ������ ���������� � ��� ����, �� ������ �������� ����� � ������� GP
            {
                figureRB.velocity = deltaPos.normalized * force * Time.deltaTime;
                isHit = false;
            }
            magnitude = figureRB.velocity.magnitude; // ��������� ������ ��������
            figureRB.AddForce(deltaPos.normalized * force * Time.deltaTime, ForceMode.Impulse); // ��������� ����� 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isHit)
        {
            var speed = Random.Range(400, 900);                                          // ����� ��������� ������� ��� ������������
            var deltaPos = collision.collider.transform.position - transform.position;   // ��������� ������ ����� ������� � ������ �����
            var rotVector = Vector3.Cross(deltaPos, collision.transform.forward);        // ��������� ������ ��������

            collision.rigidbody.velocity = deltaPos.normalized * speed * Time.fixedDeltaTime * 5; // ����������� ������ ������, ����������� � ������
            collision.rigidbody.AddTorque(rotVector * speed, ForceMode.Acceleration);
            collision.collider.GetComponent<Renderer>().material = material;

            isHit = true; // ���������
            magnitude = float.MaxValue; // ����� �������� ����������� (������� ������ ��� ������� ����)
            worldGravityPoint.GetComponent<GameControll>().countCol++; // ������� ������������
        }
    }
}
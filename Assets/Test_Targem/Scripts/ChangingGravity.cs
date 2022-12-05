using UnityEngine;

public class ChangingGravity : MonoBehaviour
{
    public Transform worldGravityPoint; // центр гравитации
    public float force; // сила притяжения к центру
    public bool isMoved; // двигается ли фигура
    public bool isHit; // ударилась ли фигура
    private Rigidbody figureRB; // rigidbody фигуры
    private Vector3 deltaPos; // разница позиций для просчета физики
    private float magnitude; // скорость, с которой движется фигура
    public Material material; // материал для смены цвета

    private void Awake() // выставляем переменные
    {
        figureRB = GetComponent<Rigidbody>();
        figureRB.centerOfMass = Vector3.zero;
        magnitude = 0;
    }

    void FixedUpdate()
    {
        if (isMoved)
        {
            deltaPos = worldGravityPoint.position - transform.position; // вычисляем вектор между фигурой и GP
            if (figureRB.velocity.magnitude > magnitude && isHit) // если скорость фигуры возрастает и был удар, то меняем скорость ровно в сторону GP
            {
                figureRB.velocity = deltaPos.normalized * force * Time.deltaTime;
                isHit = false;
            }
            magnitude = figureRB.velocity.magnitude; // сохраняем старую скорость
            figureRB.AddForce(deltaPos.normalized * force * Time.deltaTime, ForceMode.Impulse); // добавляем новую 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isHit)
        {
            var speed = Random.Range(400, 900);                                          // берем случайную сорость для отталкивания
            var deltaPos = collision.collider.transform.position - transform.position;   // вычисляем вектор между фигурой и точкой удара
            var rotVector = Vector3.Cross(deltaPos, collision.transform.forward);        // вычисляем вектор поворота

            collision.rigidbody.velocity = deltaPos.normalized * speed * Time.fixedDeltaTime * 5; // отталкиваем другую фигуру, закручиваем и красим
            collision.rigidbody.AddTorque(rotVector * speed, ForceMode.Acceleration);
            collision.collider.GetComponent<Renderer>().material = material;

            isHit = true; // ударились
            magnitude = float.MaxValue; // новая скорость максимальна (убираем рандом для условия выше)
            worldGravityPoint.GetComponent<GameControll>().countCol++; // считаем столкновения
        }
    }
}
using UnityEngine;

public class StopMove : MonoBehaviour
{
    public GameObject figure; // наша фигура

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GravityPoint") // если врезались в точку гравитации
        {
            figure.transform.position = other.transform.position;     // ставим позицию фигуры как у GravityPoint
            figure.GetComponent<ChangingGravity>().isMoved = false;   // говорим, что она не двигается
            figure.GetComponent<Rigidbody>().velocity = Vector3.zero; // зануляем ее скорость
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GravityPoint")
            GetComponentInParent<ChangingGravity>().isMoved = true; // говорим, что фигура двигается 
    }
}

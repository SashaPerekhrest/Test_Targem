using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    private float timeRemaining = 0; // таймер
    public int countCol; // количество столкновений
    public Text timer; // UI элемент таймера
    public Text collision; // UI элемент столкновений

    private void Update()
    {
        timeRemaining += Time.deltaTime; // прибавляем таймер
        timer.text = ("Времени прошло: " + (int)timeRemaining).ToString(); // выводим таймер, обрезаем дробную часть
        collision.text = "Столкновений: " + (countCol / 2).ToString(); // выводим столкновения. делим на 2, так как каждая фигура регистрирует попадания при ударе
    }

    public void Click() // обнуляем счетчики
    {
        countCol = 0;
        timeRemaining = 0;
    }
}

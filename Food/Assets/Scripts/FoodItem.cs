using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private int maxHP; // Максимальное HP еды
    private int currentHP; // Текущее HP

    private void Start()
    {
        // maxHP будет установлен из GameManager в методе SpawnFood
    }

    public void SetMaxHP(int hp)
    {
        maxHP = hp; // Устанавливаем максимальное HP
        currentHP = maxHP; // Устанавливаем текущее HP
    }

    private void OnMouseDown()
    {
        OnClick(); // Обрабатываем клик по модели еды
    }

    public void OnClick()
    {
        int damage = GameManager.Instance.GetDamage(); // Получаем текущий урон
        currentHP -= damage; // Уменьшаем HP за текущий урон

        if (currentHP <= 0)
        {
            GameManager.Instance.AddFood(1); // Добавляем еду при уничтожении
            Destroy(gameObject); // Удаляем объект
            GameManager.Instance.IncreaseFoodHP(); // Увеличиваем HP еды для следующих объектов
            GameManager.Instance.FoodDestroyed(); // Уведомляем GameManager о разрушении еды
        }
    }
}

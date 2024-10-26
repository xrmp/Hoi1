using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int food; // Количество еды
    [SerializeField] private int damage = 1; // Начальный урон
    [SerializeField] private int clickDamageUpgradeCost = 1; // Стоимость улучшения урона за клик
    [SerializeField] private int autoClickUpgradeCost = 2; // Стоимость автоматического клика
    [SerializeField] private int foodMultiplierUpgradeCost = 2; // Стоимость увеличения еды

    [SerializeField] private int initialFoodHP = 10; // Начальное HP еды

    private int autoClickCount = 0; // Сколько раз куплен автоматический клик
    private int currentFoodHP; // Текущее HP еды
    private GameObject currentFood; // Ссылка на текущий объект еды

    [SerializeField] private GameObject[] foodPrefabs; // Массив префабов еды

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentFoodHP = initialFoodHP; // Устанавливаем начальное HP при старте
            SpawnFood(); // Спавним первую еду при старте игры
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddFood(int amount)
    {
        food += amount; // Добавляем еду
    }

    public int GetFood()
    {
        return food; // Возвращаем текущее количество еды
    }

    public int GetDamage()
    {
        return damage; // Возвращаем текущий урон
    }

    public int GetClickDamageUpgradeCost()
    {
        return clickDamageUpgradeCost; // Возвращаем стоимость улучшения урона за клик
    }

    public int GetAutoClickUpgradeCost()
    {
        return autoClickUpgradeCost; // Возвращаем стоимость автоматического клика
    }

    public int GetFoodMultiplierUpgradeCost()
    {
        return foodMultiplierUpgradeCost; // Возвращаем стоимость увеличения еды
    }

    public void IncreaseFoodHP()
    {
        currentFoodHP += 10; // Увеличиваем HP еды на 10
    }

    public void FoodDestroyed()
    {
        currentFood = null; // Сбрасываем ссылку на текущую еду
        SpawnFood(); // Создаём новую еду
    }

    public void SpawnFood()
    {
        // Если еда уже существует, не создаём новую
        if (currentFood == null)
        {
            GameObject foodItemPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            currentFood = Instantiate(foodItemPrefab); // Создаём новый объект еды
            FoodItem foodItem = currentFood.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                foodItem.SetMaxHP(currentFoodHP); // Устанавливаем максимальное HP для нового объекта еды
            }
        }
    }

    public bool UpgradeClickDamage()
    {
        if (food >= clickDamageUpgradeCost)
        {
            food -= clickDamageUpgradeCost;
            damage *= 2; // Увеличиваем урон
            clickDamageUpgradeCost *= 2; // Увеличиваем стоимость следующего улучшения
            return true; // Успешное улучшение
        }
        return false; // Не удалось улучшить
    }

    public bool UpgradeAutoClick()
    {
        if (autoClickCount < 10 && food >= autoClickUpgradeCost)
        {
            food -= autoClickUpgradeCost;
            autoClickCount++;
            autoClickUpgradeCost *= 10; // Увеличиваем стоимость следующего улучшения
            return true; // Успешное улучшение
        }
        return false; // Не удалось улучшить
    }

    public bool UpgradeFoodMultiplier()
    {
        if (food >= foodMultiplierUpgradeCost)
        {
            food -= foodMultiplierUpgradeCost; // Уменьшаем еду на стоимость
            foodMultiplierUpgradeCost *= 2; // Увеличиваем стоимость следующего улучшения
            return true; // Успешное улучшение
        }
        return false; // Не удалось улучшить
    }
}

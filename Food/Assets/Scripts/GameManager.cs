using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int food; // Количество еды
    [SerializeField] private int damage = 1; // Начальный урон
    [SerializeField] private int clickDamageUpgradeCost = 1; // Стоимость улучшения урона за клик
    [SerializeField] private int autoIncomeUpgradeCost = 2; // Стоимость улучшения автоматического дохода
    [SerializeField] private int foodMultiplierUpgradeCost = 2; // Стоимость увеличения еды
    [SerializeField] private int initialFoodHP = 10; // Начальное HP еды

    private int autoIncome = 1; // Начальный автоматический доход
    private int autoIncomeCount = 0; // Счетчик улучшений автоматического дохода
    private int currentFoodHP; // Текущее HP еды
    private GameObject currentFood; // Ссылка на текущий объект еды
    private bool autoIncomePurchased = false; // Флаг, показывает, куплен ли авто доход
    private float foodMultiplier = 1; // Множитель еды

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
        food += (int)(amount * foodMultiplier); // Увеличиваем еду с учетом множителя
    }

    private IEnumerator AutoIncomeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Ждем 1 секунду
            AddFood(autoIncome); // Добавляем автоматический доход
        }
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

    public int GetAutoIncomeUpgradeCost()
    {
        return autoIncomeUpgradeCost; // Возвращаем стоимость улучшения автоматического дохода
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

    public bool UpgradeAutoIncome()
    {
        if (autoIncomeCount < 10 && food >= autoIncomeUpgradeCost) // Максимум 10 улучшений
        {
            food -= autoIncomeUpgradeCost; // Уменьшаем количество еды на стоимость улучшения
            autoIncome *= 2; // Увеличиваем автоматический доход
            autoIncomeCount++; // Увеличиваем счетчик автоматического дохода
            autoIncomeUpgradeCost *= 2; // Увеличиваем стоимость следующего улучшения

            if (!autoIncomePurchased)
            {
                autoIncomePurchased = true; // Устанавливаем флаг
                StartCoroutine(AutoIncomeCoroutine()); // Запускаем корутину авто дохода
            }

            return true; // Успешное улучшение
        }
        return false; // Не удалось улучшить
    }

    public bool UpgradeFoodMultiplier()
    {
        if (food >= foodMultiplierUpgradeCost)
        {
            food -= foodMultiplierUpgradeCost; // Уменьшаем еду на стоимость
            foodMultiplier *= 2; // Увеличиваем множитель еды
            foodMultiplierUpgradeCost *= 2; // Увеличиваем стоимость следующего улучшения
            return true; // Успешное улучшение
        }
        return false; // Не удалось улучшить
    }
}

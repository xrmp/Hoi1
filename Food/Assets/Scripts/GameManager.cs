using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int food; // ���������� ���
    [SerializeField] private int damage = 1; // ��������� ����
    [SerializeField] private int clickDamageUpgradeCost = 1; // ��������� ��������� ����� �� ����
    [SerializeField] private int autoIncomeUpgradeCost = 2; // ��������� ��������� ��������������� ������
    [SerializeField] private int foodMultiplierUpgradeCost = 2; // ��������� ���������� ���
    [SerializeField] private int initialFoodHP = 10; // ��������� HP ���

    private int autoIncome = 1; // ��������� �������������� �����
    private int autoIncomeCount = 0; // ������� ��������� ��������������� ������
    private int currentFoodHP; // ������� HP ���
    private GameObject currentFood; // ������ �� ������� ������ ���

    [SerializeField] private GameObject[] foodPrefabs; // ������ �������� ���

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentFoodHP = initialFoodHP; // ������������� ��������� HP ��� ������
            SpawnFood(); // ������� ������ ��� ��� ������ ����
            StartCoroutine(AutoIncomeCoroutine()); // ��������� �������� ��������������� ������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddFood(int amount)
    {
        food += amount; // ����������� ���
    }

    private IEnumerator AutoIncomeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10); // ���� 1 �������
            AddFood(autoIncome); // ��������� �������������� �����
        }
    }

    public int GetFood()
    {
        return food; // ���������� ������� ���������� ���
    }

    public int GetDamage()
    {
        return damage; // ���������� ������� ����
    }

    public int GetClickDamageUpgradeCost()
    {
        return clickDamageUpgradeCost; // ���������� ��������� ��������� ����� �� ����
    }

    public int GetAutoIncomeUpgradeCost()
    {
        return autoIncomeUpgradeCost; // ���������� ��������� ��������� ��������������� ������
    }

    public int GetFoodMultiplierUpgradeCost()
    {
        return foodMultiplierUpgradeCost; // ���������� ��������� ���������� ���
    }

    public void IncreaseFoodHP()
    {
        currentFoodHP += 10; // ����������� HP ��� �� 10
    }

    public void FoodDestroyed()
    {
        currentFood = null; // ���������� ������ �� ������� ���
        SpawnFood(); // ������ ����� ���
    }

    public void SpawnFood()
    {
        if (currentFood == null)
        {
            GameObject foodItemPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            currentFood = Instantiate(foodItemPrefab); // ������ ����� ������ ���
            FoodItem foodItem = currentFood.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                foodItem.SetMaxHP(currentFoodHP); // ������������� ������������ HP ��� ������ ������� ���
            }
        }
    }

    public bool UpgradeClickDamage()
    {
        if (food >= clickDamageUpgradeCost)
        {
            food -= clickDamageUpgradeCost;
            damage *= 2; // ����������� ����
            clickDamageUpgradeCost *= 2; // ����������� ��������� ���������� ���������
            return true; // �������� ���������
        }
        return false; // �� ������� ��������
    }

    public bool UpgradeAutoIncome()
    {
        if (autoIncomeCount < 10 && food >= autoIncomeUpgradeCost) // �������� 10 ���������
        {
            food -= autoIncomeUpgradeCost; // ��������� ���������� ��� �� ��������� ���������
            autoIncome *= 2; // ����������� �������������� �����
            autoIncomeCount++; // ����������� ������� ��������������� ������
            autoIncomeUpgradeCost *= 2; // ����������� ��������� ���������� ���������
            return true; // �������� ���������
        }
        return false; // �� ������� ��������
    }

    public bool UpgradeFoodMultiplier()
    {
        // ����� ����� �������� ������, ��������, ����������� ���������� ���, ���������� � �����
        if (food >= foodMultiplierUpgradeCost)
        {
            food -= foodMultiplierUpgradeCost; // ��������� ��� �� ���������
            foodMultiplierUpgradeCost *= 2; // ����������� ��������� ���������� ���������
            // ��������, ����������� ���������� ���, ���������� ��� �����
            // ����� ����� �������� ��������������� ������, ���� ���������
            return true; // �������� ���������
        }
        return false; // �� ������� ��������
    }
}

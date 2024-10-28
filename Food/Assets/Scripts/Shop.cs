using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text foodAmountText; // Текст для отображения количества еды
    [SerializeField] private Text clickDamageCostText; // Текст для отображения стоимости улучшения урона за клик
    [SerializeField] private Text autoIncomeCostText; // Текст для отображения стоимости улучшения автоматического дохода
    [SerializeField] private Text foodMultiplierCostText; // Текст для отображения стоимости увеличения еды

    private void Start()
    {
        UpdateShopUI(); // Обновляем UI магазина при старте
    }

    private void Update()
    {
        UpdateFoodAmountText(); // Обновляем только количество еды
    }

    private void UpdateFoodAmountText()
    {
        foodAmountText.text = "Food: " + GameManager.Instance.GetFood();
    }

    public void UpdateShopUI()
    {
        clickDamageCostText.text = "Upgrade Click Damage: " + GameManager.Instance.GetClickDamageUpgradeCost();
        autoIncomeCostText.text = "Upgrade Auto Income: " + GameManager.Instance.GetAutoIncomeUpgradeCost();
        foodMultiplierCostText.text = "Upgrade Food Multiplier: " + GameManager.Instance.GetFoodMultiplierUpgradeCost();
    }

    public void BuyClickDamageUpgrade()
    {
        if (GameManager.Instance.UpgradeClickDamage())
        {
            UpdateShopUI(); // Обновляем UI после успешной покупки
        }
    }

    public void BuyAutoIncomeUpgrade()
    {
        if (GameManager.Instance.UpgradeAutoIncome())
        {
            UpdateShopUI(); // Обновляем UI после успешной покупки
        }
    }

    public void BuyFoodMultiplierUpgrade()
    {
        if (GameManager.Instance.UpgradeFoodMultiplier())
        {
            UpdateShopUI(); // Обновляем UI после успешной покупки
        }
    }
}

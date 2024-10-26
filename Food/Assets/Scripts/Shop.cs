using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text foodAmountText; // Текст для отображения количества еды
    [SerializeField] private Text clickDamageCostText; // Текст для отображения стоимости улучшения урона за клик
    [SerializeField] private Text autoClickCostText; // Текст для отображения стоимости автоматического клика
    [SerializeField] private Text foodMultiplierCostText; // Текст для отображения стоимости увеличения еды

    private void Start()
    {
        UpdateShopUI(); // Обновляем UI магазина при старте
    }

    private void UpdateShopUI()
    {
        foodAmountText.text = "Food: " + GameManager.Instance.GetFood();
        clickDamageCostText.text = "Upgrade Click Damage: " + GameManager.Instance.GetClickDamageUpgradeCost();
        autoClickCostText.text = "Upgrade Auto Click: " + GameManager.Instance.GetAutoClickUpgradeCost();
        foodMultiplierCostText.text = "Upgrade Food Multiplier: " + GameManager.Instance.GetFoodMultiplierUpgradeCost();
    }

    public void BuyClickDamageUpgrade()
    {
        if (GameManager.Instance.UpgradeClickDamage())
        {
            UpdateShopUI(); // Обновляем UI после успешной покупки
        }
    }

    public void BuyAutoClickUpgrade()
    {
        if (GameManager.Instance.UpgradeAutoClick())
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

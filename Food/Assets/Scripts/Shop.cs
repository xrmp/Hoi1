using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text foodAmountText; // ����� ��� ����������� ���������� ���
    [SerializeField] private Text clickDamageCostText; // ����� ��� ����������� ��������� ��������� ����� �� ����
    [SerializeField] private Text autoClickCostText; // ����� ��� ����������� ��������� ��������������� �����
    [SerializeField] private Text foodMultiplierCostText; // ����� ��� ����������� ��������� ���������� ���

    private void Start()
    {
        UpdateShopUI(); // ��������� UI �������� ��� ������
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
            UpdateShopUI(); // ��������� UI ����� �������� �������
        }
    }

    public void BuyAutoClickUpgrade()
    {
        if (GameManager.Instance.UpgradeAutoClick())
        {
            UpdateShopUI(); // ��������� UI ����� �������� �������
        }
    }

    public void BuyFoodMultiplierUpgrade()
    {
        if (GameManager.Instance.UpgradeFoodMultiplier())
        {
            UpdateShopUI(); // ��������� UI ����� �������� �������
        }
    }
}

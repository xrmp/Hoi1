using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text foodAmountText; // ����� ��� ����������� ���������� ���
    [SerializeField] private Text clickDamageCostText; // ����� ��� ����������� ��������� ��������� ����� �� ����
    [SerializeField] private Text autoIncomeCostText; // ����� ��� ����������� ��������� ��������� ��������������� ������
    [SerializeField] private Text foodMultiplierCostText; // ����� ��� ����������� ��������� ���������� ���

    private void Start()
    {
        UpdateShopUI(); // ��������� UI �������� ��� ������
    }

    private void Update()
    {
        UpdateFoodAmountText(); // ��������� ������ ���������� ���
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
            UpdateShopUI(); // ��������� UI ����� �������� �������
        }
    }

    public void BuyAutoIncomeUpgrade()
    {
        if (GameManager.Instance.UpgradeAutoIncome())
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

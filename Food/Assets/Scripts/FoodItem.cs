using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private int maxHP; // ������������ HP ���
    private int currentHP; // ������� HP

    private void Start()
    {
        // maxHP ����� ���������� �� GameManager � ������ SpawnFood
    }

    public void SetMaxHP(int hp)
    {
        maxHP = hp; // ������������� ������������ HP
        currentHP = maxHP; // ������������� ������� HP
    }

    private void OnMouseDown()
    {
        OnClick(); // ������������ ���� �� ������ ���
    }

    public void OnClick()
    {
        int damage = GameManager.Instance.GetDamage(); // �������� ������� ����
        currentHP -= damage; // ��������� HP �� ������� ����

        if (currentHP <= 0)
        {
            GameManager.Instance.AddFood(1); // ��������� ��� ��� �����������
            Destroy(gameObject); // ������� ������
            GameManager.Instance.IncreaseFoodHP(); // ����������� HP ��� ��� ��������� ��������
            GameManager.Instance.FoodDestroyed(); // ���������� GameManager � ���������� ���
        }
    }
}

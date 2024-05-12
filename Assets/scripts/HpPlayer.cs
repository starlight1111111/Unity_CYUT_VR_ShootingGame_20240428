using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : HpSystem
{
    [SerializeField, Header("����Ϥ�")]
    private Image imgHP;
    [SerializeField, Header("�����r")]
    private TMP_Text textHP;
    private float hpMax;

    private void Awake()
    {
        hpMax = hp;
        UpdateUI();
    }
    private string enemyattackarea = "�ĤH�����d��";
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains(enemyattackarea))
        {
            Damage(50);
        }
    }
    private void UpdateUI()
    {
        imgHP.fillAmount = hp / hpMax;
        textHP.text =$"HP {hp} / {hpMax}";
    }
    protected override void Damage(float damage)
    {
        if (hp <= 0) return;
        base.Damage(damage);
        UpdateUI();
    }
}

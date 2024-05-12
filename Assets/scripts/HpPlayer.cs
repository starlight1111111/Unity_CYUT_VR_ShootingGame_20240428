using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : HpSystem
{
    [SerializeField, Header("血條圖片")]
    private Image imgHP;
    [SerializeField, Header("血條文字")]
    private TMP_Text textHP;
    private float hpMax;

    private void Awake()
    {
        hpMax = hp;
        UpdateUI();
    }
    private string enemyattackarea = "敵人攻擊範圍";
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

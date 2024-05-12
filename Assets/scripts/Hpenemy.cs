using UnityEngine;

public class Hpenemy : HpSystem
{
    private string bulletName = "子彈";
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains(bulletName))
        {
            float attack = collision.gameObject.GetComponent<Bullet>().attack;
            Damage(attack);
        }
    }
    protected override  void Dead()
    {   
        //繼承父輩
        base.Dead();
        //刪除物件
        Destroy(gameObject);
    }
}

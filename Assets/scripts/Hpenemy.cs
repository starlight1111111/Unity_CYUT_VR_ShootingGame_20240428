using UnityEngine;

public class Hpenemy : HpSystem
{
    private string bulletName = "�l�u";
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
        //�~�Ӥ���
        base.Dead();
        //�R������
        Destroy(gameObject);
    }
}

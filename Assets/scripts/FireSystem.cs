using UnityEngine;

public class FireSystem : MonoBehaviour
{
    [SerializeField, Header("�l�u�w�s��")]
    private GameObject prefabBullet;
    [SerializeField, Header("�l�u�ͦ��I")]
    private Transform firepoint; 
    [SerializeField, Header("�l�u�t��"), Range(0,3000)]
    private float FireSpeed = 500;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) Firebullet();
    }
    private void Firebullet()
    {
        //�ͦ���(����,�y��,�s����)
        GameObject temp = Instantiate(prefabBullet,firepoint.position,Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * -FireSpeed);
    }
}

    

    


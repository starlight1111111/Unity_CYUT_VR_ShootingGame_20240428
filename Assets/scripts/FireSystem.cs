using UnityEngine;

public class FireSystem : MonoBehaviour
{
    [SerializeField, Header("子彈預製物")]
    private GameObject prefabBullet;
    [SerializeField, Header("子彈生成點")]
    private Transform firepoint; 
    [SerializeField, Header("子彈速度"), Range(0,3000)]
    private float FireSpeed = 500;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) Firebullet();
    }
    private void Firebullet()
    {
        //生成物(物件,座標,零角度)
        GameObject temp = Instantiate(prefabBullet,firepoint.position,Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * -FireSpeed);
    }
}

    

    


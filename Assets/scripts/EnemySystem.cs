using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField, Header("���a")]
    private Transform Playerpoint;
    [SerializeField, Header("���a�N�z��")]
    private NavMeshAgent agent;
    [SerializeField, Header("�ʵe���")]
    private Animator ani;
    [SerializeField, Header("�ĤH�����d��")]
    private GameObject Attackarea;

    private string parMove = "���ʼƭ�";
    private string paratt = "����";
    private bool isAttacking;

    private void Awake()
    {
        Move();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    private void Attack()
    {
        if (isAttacking) return;
        
        //�T�{�O�_�u��������
        //print($"<color=#6f9>�Z��:{agent.remainingDistance}</color>");
        
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            ani.SetTrigger(paratt);
            isAttacking = true;
            StartCoroutine(StartAttack());
        }
    }

    private void Move()
    {
        //�N�z�� �� �]�w�ت��a (���a���y��)
        agent.SetDestination(Playerpoint.position);
        // �ʵe��� �]�w�B�I��(�ѼƦW��)
        ani.SetFloat(parMove, agent.velocity.magnitude / agent.speed);
    }

    private IEnumerator StartAttack()
    {
        print("�����}�l");
        yield return new WaitForSeconds(0.05f);
        Attackarea.SetActive(true);
        print("�e�n����,�缾�a�y���ˮ`");
        yield return new WaitForSeconds(1.5f);
        print("��n����");
        Attackarea.SetActive(false);
        isAttacking = false;
    }
}

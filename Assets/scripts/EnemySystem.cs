using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField, Header("���a")]
    private Transform Playerpoint;
    [SerializeField, Header("���a�N�z��")]
    private NavMeshAgent agent;
    [SerializeField, Header("�ʵe���")]
    private Animator ani;
    
    private string parMove = "���ʼƭ�";
    private string paratt = "����";
    private bool isAttacking;

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
        }
    }

    private void Move()
    {
        //�N�z�� �� �]�w�ت��a (���a���y��)
        agent.SetDestination(Playerpoint.position);
        // �ʵe��� �]�w�B�I��(�ѼƦW��)
        ani.SetFloat(parMove, agent.velocity.magnitude / agent.speed);
    }
}

using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField, Header("玩家")]
    private Transform Playerpoint;
    [SerializeField, Header("玩家代理器")]
    private NavMeshAgent agent;
    [SerializeField, Header("動畫控制器")]
    private Animator ani;
    [SerializeField, Header("敵人攻擊範圍")]
    private GameObject Attackarea;

    private string parMove = "移動數值";
    private string paratt = "攻擊";
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
        
        //確認是否真的有攻擊
        //print($"<color=#6f9>距離:{agent.remainingDistance}</color>");
        
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            ani.SetTrigger(paratt);
            isAttacking = true;
            StartCoroutine(StartAttack());
        }
    }

    private void Move()
    {
        //代理器 的 設定目的地 (玩家的座標)
        agent.SetDestination(Playerpoint.position);
        // 動畫控制器 設定浮點數(參數名稱)
        ani.SetFloat(parMove, agent.velocity.magnitude / agent.speed);
    }

    private IEnumerator StartAttack()
    {
        print("攻擊開始");
        yield return new WaitForSeconds(0.05f);
        Attackarea.SetActive(true);
        print("前搖結束,對玩家造成傷害");
        yield return new WaitForSeconds(1.5f);
        print("後搖結束");
        Attackarea.SetActive(false);
        isAttacking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    public int enemyMaxHp = 100;                    // ���� �ִ� ü��
    public int enemyCurHp;                          // ���� ���� ü��
    public int enemyDamage = 5;                     // ���� ������
    public int enemyDefense = 5;                    // ���� ����
    public float enemyAttackSpeed = 1f;             // ���� ���ݼӵ�
    public float enemyMoveSpeed = 0.3f;             // ���� �̵��ӵ�

    public bool isBattle = false;               // ���� ������ üũ
    public bool isAttack = false;
    public bool attackPlayer = false;           // �÷��̾� ���� ������ üũ
    public float attackTimer;                   // ���� ��Ÿ��

    public Image enemyHPBar;                    // ���� ü�¹�

    public Animator enemyAnimator;              // ���� �ִϸ��̼�

    public PlayerCharacter playerCharacter;     // �÷��̾� ü���� ������ ��ũ��Ʈ


    // ��� ����Ʈ�� ���� ����
    public GameObject poolManager;
    private RectTransform enemyRect;
    public GameObject effectPrefab;
    public float defaultTime = 0.05f;
    public int offsetRange = 40;

    private void Awake()
    {
        enemyCurHp = enemyMaxHp;
        enemyAnimator = GetComponent<Animator>();
        enemyRect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        enemyCurHp = enemyMaxHp;
    }

    private void Update()
    {
        // ���
        if (enemyCurHp <= 0)
        {
            enemyAnimator.SetTrigger("Die");
        }

        // ü�¹� ������Ʈ
        enemyHPBar.fillAmount = (float)enemyCurHp / (float)enemyMaxHp;
    }

    void FixedUpdate()
    {
        if (!isBattle && !isAttack)
        {
            transform.Translate(enemyMoveSpeed * Time.deltaTime * Vector2.left);
        }

        if (isBattle)
        {
            transform.Translate(Vector3.zero);

            // ���� �ӵ� ��Ÿ��
            attackTimer += Time.deltaTime;

            // ���� ���� �ð�
            if (attackTimer >= enemyAttackSpeed)
            {
                isAttack = true;
                attackTimer = 0;
            }

            if (isAttack && attackTimer == 0)
            {
                // ����
                enemyAnimator.SetBool("isAttack", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerCharacter == null)
        {
            isBattle = true;
            attackPlayer = true;
            playerCharacter = collision.GetComponent<PlayerCharacter>();
        }

        else if (collision.CompareTag("PlayerTower"))
        {
            isBattle = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerCharacter == null)
        {
            isBattle = true;
            attackPlayer = true;
            playerCharacter = collision.GetComponent<PlayerCharacter>();
        }

        else if (collision.CompareTag("PlayerTower"))
        {
            isBattle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isBattle = false;
            attackPlayer = false;
            playerCharacter = null;
        }
    }

    public void EnemyDead()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);

        for(int i = 0; i < 40; i++) // 20���� ����Ʈ�� ��ȯ
        {
            EffectCreate();
        }
        
        FightManager.fightManager.activeEnemys.Remove(gameObject);
        gameObject.SetActive(false);
        isBattle = false;
        isAttack = false;
    }

    public void EnemyAttack()
    {
        if (attackPlayer)
        {
            if(playerCharacter != null)
            {
                playerCharacter.characterCurHP -= enemyDamage;
            }
        }
        else if (!attackPlayer)
        {
            FightManager.fightManager.curPlayerTowerHp -= enemyDamage;
        }
    }

    public void EnemyAttackEnd()
    {
        isAttack = false;
        enemyAnimator.SetBool("isAttack", false);
    }

    // ����Ʈ ����
    void EffectCreate()
    {
        // ���� ��ġ ���� ���ݾ� �����ϰ� ��� ��ġ�� ����
        float offsetX = Random.Range(-offsetRange, offsetRange);
        float offsetY = Random.Range(-offsetRange, offsetRange);

        // ����Ʈ ���� ��ġ ���� ���� ��ġ
        GameObject effect = Instantiate(effectPrefab, enemyRect);

        // ����Ʈ�� �θ� �����Ͽ� enemyRect�� �ڽ��� �ƴϰ� ����
        effect.transform.SetParent(enemyRect.transform.parent);

        // ����Ʈ ����
        RectTransform effectRectTransform = effect.GetComponent<RectTransform>();
        effectRectTransform.anchoredPosition = new Vector3(effectRectTransform.anchoredPosition.x + offsetX, effectRectTransform.anchoredPosition.y + offsetY, 0f); // ���ϴ� ��ġ�� ����
    }
}

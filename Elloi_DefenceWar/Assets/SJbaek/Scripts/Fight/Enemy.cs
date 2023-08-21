using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    public int enemyMaxHp = 100;                    // 몬스터 최대 체력
    public int enemyCurHp;                          // 몬스터 현재 체력
    public int enemyDamage = 5;                     // 몬스터 데미지
    public int enemyDefense = 5;                    // 몬스터 방어력
    public float enemyAttackSpeed = 1f;             // 몬스터 공격속도
    public float enemyMoveSpeed = 0.3f;             // 몬스터 이동속도

    public bool isBattle = false;               // 전투 중인지 체크
    public bool isAttack = false;
    public bool attackPlayer = false;           // 플레이어 공격 중인지 체크
    public float attackTimer;                   // 공격 쿨타임

    public Image enemyHPBar;                    // 몬스터 체력바

    public Animator enemyAnimator;              // 몬스터 애니메이션

    public PlayerCharacter playerCharacter;     // 플레이어 체력을 가져올 스크립트


    // 사망 이펙트를 위한 변수
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
        // 사망
        if (enemyCurHp <= 0)
        {
            enemyAnimator.SetTrigger("Die");
        }

        // 체력바 업데이트
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

            // 공격 속도 쿨타임
            attackTimer += Time.deltaTime;

            // 공격 가능 시간
            if (attackTimer >= enemyAttackSpeed)
            {
                isAttack = true;
                attackTimer = 0;
            }

            if (isAttack && attackTimer == 0)
            {
                // 공격
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

        for(int i = 0; i < 40; i++) // 20개의 이펙트를 소환
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

    // 이펙트 생성
    void EffectCreate()
    {
        // 생성 위치 에서 조금씩 랜덤하게 벗어난 위치로 생성
        float offsetX = Random.Range(-offsetRange, offsetRange);
        float offsetY = Random.Range(-offsetRange, offsetRange);

        // 이펙트 생성 위치 현재 적의 위치
        GameObject effect = Instantiate(effectPrefab, enemyRect);

        // 이펙트의 부모를 설정하여 enemyRect의 자식이 아니게 만듦
        effect.transform.SetParent(enemyRect.transform.parent);

        // 이펙트 생성
        RectTransform effectRectTransform = effect.GetComponent<RectTransform>();
        effectRectTransform.anchoredPosition = new Vector3(effectRectTransform.anchoredPosition.x + offsetX, effectRectTransform.anchoredPosition.y + offsetY, 0f); // 원하는 위치로 수정
    }
}

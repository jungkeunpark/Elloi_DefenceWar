using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    public int characterIndex;                  // 캐릭터 번호
    public int characterMaxHP;                  // 캐릭터 체력
    public int characterCurHP;                    
    public int characterDamage;                 // 캐릭터 공격력
    public int characterDefense;                // 캐릭터 방어력
    public float characterAttackSpeed;          // 캐릭터 공격속도
    public float characterMoveSpeed;            // 캐릭터 이동속도
    public int respawnCoolTime;                 // 캐릭터 소환쿨타임
    public int characterCost;                   // 캐릭터 비용
    public SpriteRenderer characterSpriteRenderer;       // 캐릭터 이미

    public bool isBattle = false;       // 전투 중인지 체크
    public bool isAttack = false;       // 공격 중인지 체크
    public bool isEnemy = false;
    public bool isTower = false;
    public float attackCoolTime;        // 공격 쿨타임

    public Enemy enemy;

    public void SetCharacterCardValues(int index)
    {
        // 값 불러오기
        characterIndex = GameManager.instance.partySetCardIndex[index];
        characterMaxHP = int.Parse(GameManager.instance.AllCharacter_List[characterIndex].Health);  
        characterCurHP = characterMaxHP;
        characterDamage = int.Parse(GameManager.instance.AllCharacter_List[characterIndex].Damage);
        characterDefense = int.Parse(GameManager.instance.AllCharacter_List[characterIndex].Defense);
        characterAttackSpeed = float.Parse(GameManager.instance.AllCharacter_List[characterIndex].AttackSpeed);
        characterMoveSpeed = float.Parse(GameManager.instance.AllCharacter_List[characterIndex].MoveSpeed);
        respawnCoolTime = int.Parse(GameManager.instance.AllCharacter_List[characterIndex].ResponeCoolTime);
        characterCost = int.Parse(GameManager.instance.AllCharacter_List[characterIndex].Cost);
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        characterSpriteRenderer.sprite = GameManager.instance.characterCardPrefabs[characterIndex].transform.GetChild(2).GetComponentInChildren<Image>().sprite;
        characterSpriteRenderer.flipX = true;
    }

    private void OnEnable()
    {
        characterCurHP = characterMaxHP;
    }

    private void Update()
    {
        // 사망
        if(characterCurHP <= 0)
        {
            ChracterDead();
        }
    }


    private void FixedUpdate()
    {
        if (!isBattle && !isAttack) 
        {
            transform.Translate((characterMoveSpeed / 100) * Time.deltaTime * Vector2.right);
        }
        else if(isBattle)
        {
            transform.Translate(Vector3.zero);

            // 공격 속도 쿨타임
            attackCoolTime += Time.deltaTime;

            if (attackCoolTime > characterAttackSpeed)
            {
                // 공격 시작
                isAttack = true;
                attackCoolTime = 0;
            }

            if (isAttack && attackCoolTime==0)
            {
                Debug.Log("플레이어 어택");
                StartCoroutine(Attack(enemy));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            isAttack = true;
            isBattle = true;
            isEnemy = true;
            isTower = false;
            enemy = collision.GetComponent<Enemy>();
        }

        else if (collision.CompareTag("EnemyTower"))
        {
            isAttack = true;
            isBattle = true;
            isEnemy = false;
            isTower = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyTower"))
        {
            isAttack = true;
            isBattle = true;
            isEnemy = false;
            isTower = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            isBattle = false;
            isTower = true;
        }
    }

    public IEnumerator Attack(Enemy enemy)
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, 0, -22.5f);
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, 0, -45f);

        // Enemy 컴포넌트 hp 감소
        if (isEnemy)
        {
            enemy.enemyCurHp -= characterDamage;
        }
        else if (isTower)
        {
            FightManager.fightManager.curEnemyTowerHp -= characterDamage;
        }

        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, 0, -22.5f);
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.1f);

        isAttack = false;
    }

    public void ChracterDead()
    {
        gameObject.SetActive(false);
        isBattle = false;
        isAttack = false;

        enemy.isBattle = false;
        enemy.isAttack = false;
    }
}

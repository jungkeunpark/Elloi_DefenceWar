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
    public Image characterImage;                // 캐릭터 이미지
    public Image characterHPBar;                // 캐릭터 HP바

    public bool isBattle = false;       // 전투 중인지 체크
    public bool isAttack = false;       // 공격 중인지 체크
    public bool attackEnemy = false;    // 적을 공격중
    public float attackCoolTime;        // 공격 쿨타임

    public Enemy enemy;

    public void SetCharacterCardValues(int index)
    {
        // 파티 세팅에 카드가 없으면
        if (GameManager.instance.partySetCardIndex[index] == -1)
        {
            return;
        }

        // 파티 세팅에 카드가 있으면
        else if (GameManager.instance.partySetCardIndex[index] != -1)
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
            characterImage = transform.GetChild(0).gameObject.GetComponent<Image>();
            characterImage.sprite = GameManager.instance.characterCardPrefabs[characterIndex].transform.GetChild(2).GetComponentInChildren<Image>().sprite;
            characterImage.SetNativeSize();
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
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

        // 캐릭터 체력바 업데이트
        characterHPBar.fillAmount = (float)characterCurHP / (float)characterMaxHP;
    }

    private void FixedUpdate()
    {
        if (!isBattle && !isAttack) 
        {
            // 위치 재조정
            characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
            // 이동
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
                StartCoroutine(Attack(enemy));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            isBattle = true;
            attackEnemy = true;
            enemy = collision.GetComponent<Enemy>();
        }

        else if (collision.CompareTag("EnemyTower"))
        {
            isBattle = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isBattle = true;
            attackEnemy = true;
            enemy = collision.GetComponent<Enemy>();
        }

        else if (collision.CompareTag("EnemyTower"))
        {
            isBattle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isBattle = false;
            attackEnemy = false;
            enemy = null;
        }
    }

    public IEnumerator Attack(Enemy enemy)
    {
        characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        characterImage.transform.eulerAngles = new Vector3(0, 0, -22.5f);
        yield return new WaitForSeconds(0.1f);
        characterImage.transform.eulerAngles = new Vector3(0, 0, -45f);

        // Enemy 컴포넌트 hp 감소
        if (attackEnemy)
        {
            if(enemy != null)
            {
                enemy.enemyCurHp -= characterDamage;
            }
        }
        else if (!attackEnemy)
        {
            FightManager.fightManager.curEnemyTowerHp -= characterDamage;
        }

        yield return new WaitForSeconds(0.1f);
        characterImage.transform.eulerAngles = new Vector3(0, 0, -22.5f);
        yield return new WaitForSeconds(0.1f);
        characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.1f);

        isAttack = false;
    }

    public void ChracterDead()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
        isBattle = false;
        isAttack = false;
    }
}

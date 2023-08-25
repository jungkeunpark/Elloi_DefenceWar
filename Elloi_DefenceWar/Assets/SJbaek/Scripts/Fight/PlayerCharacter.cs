using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static PlayerCharacter;

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
    public bool attackTower = false;    // 타워를 공격중
    public float attackCoolTime;        // 공격 쿨타임

    public Enemy enemy;                 // 적 hp를 가져올 스크립트

    // 원거리 캐릭터 test
    public GameObject Arrow;                            // 원거리 공격 무기
    private float focusEnemyDis = Mathf.Infinity;       // 내가 정한 적과의 거리
    private float towerDistance;                        // 적 타워와의 거리
    private int attackRange = 5;                        // 공격거리

    // 근거리, 원거리
    public enum CharacterType
    {
        Melee, Range
    }

    public CharacterType characterType;

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
            characterType = int.Parse(GameManager.instance.AllCharacter_List[characterIndex].type) == 0 ? CharacterType.Melee : CharacterType.Range;
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
        if (characterCurHP <= 0)
        {
            ChracterDead();
        }

        // 캐릭터 체력바 업데이트
        characterHPBar.fillAmount = (float)characterCurHP / (float)characterMaxHP;
    
        // 근접 캐릭터
        switch(characterType)
        {
            case CharacterType.Melee:
                {
                    if (!isBattle && !isAttack)
                    {
                        // 위치 재조정
                        characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
                        // 이동
                        transform.Translate((characterMoveSpeed / 100) * Time.deltaTime * Vector2.right);
                    }
                    else if (isBattle)
                    {
                        transform.Translate(Vector3.zero);

                        // 공격 속도 쿨타임
                        attackCoolTime += Time.deltaTime;

                        if (attackCoolTime >= characterAttackSpeed)
                        {
                            // 공격 시작
                            isAttack = true;
                            attackCoolTime = 0;
                        }

                        if (isAttack && attackCoolTime == 0)
                        {
                            StartCoroutine(MeleeAttack(enemy));
                        }
                    }
                    break;
                }

            case CharacterType.Range:
                {
                    // 거리 초기화 (안하면 적이 죽어도 한 발 더 쏘고 이동함)
                    focusEnemyDis = Mathf.Infinity;

                    // 적 거리 탐색
                    foreach (GameObject focusEnemy in FightManager.fightManager.activeEnemys)
                    {
                        float tempDistance = Vector2.Distance(transform.position, focusEnemy.transform.position);

                        // 저장된 거리보다 작다면 저장된 거리에 저장
                        if (focusEnemyDis > tempDistance)
                        {
                            focusEnemyDis = tempDistance;
                            // enemy = focusEnemy.GetComponent<Enemy>();
                            Debug.Log(focusEnemyDis);
                        }
                    }

                    // 적 타워 거리 탐색
                    towerDistance = Vector2.Distance(transform.position, FightManager.fightManager.enemyTower.transform.position);

                    // 거리 안에 들어오면 공격 시작
                    if (focusEnemyDis <= attackRange || towerDistance <= attackRange)
                    {
                        isBattle = true;
                    }

                    else if (focusEnemyDis > attackRange || towerDistance > attackRange)
                    {
                        isBattle = false;
                    }

                    if (!isBattle)
                    {
                        // 위치 재조정
                        characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
                        // 이동
                        transform.Translate((characterMoveSpeed / 100) * Time.deltaTime * Vector2.right);
                    }

                    else if (isBattle) 
                    {
                        transform.Translate(Vector3.zero);

                        // 공격 속도 쿨타임
                        attackCoolTime += Time.deltaTime / 2;
                    
                        // 공격 가능 조건
                        if (attackCoolTime >= characterAttackSpeed)
                        {
                            // 공격 시작
                            RangeAttack(enemy);
                            attackCoolTime = -0.5f;
                        }
                    }
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && enemy == null && characterType == CharacterType.Melee)
        {
            isBattle = true;
            attackEnemy = true;
            enemy = collision.GetComponent<Enemy>();
        }

        else if (collision.CompareTag("EnemyTower") && characterType == CharacterType.Melee)
        {
            isBattle = true;
            attackTower = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && enemy == null && characterType == CharacterType.Melee)
        {
            isBattle = true;
            attackEnemy = true;
            enemy = collision.GetComponent<Enemy>();
        }

        else if (collision.CompareTag("EnemyTower") && characterType == CharacterType.Melee)
        {
            isBattle = true;
            attackTower = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && characterType == CharacterType.Melee)
        {
            isBattle = false;
            attackEnemy = false;
            enemy = null;
        }
    }

    public IEnumerator MeleeAttack(Enemy enemy)
    {
        characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        characterImage.transform.eulerAngles = new Vector3(0, 0, -22.5f);
        yield return new WaitForSeconds(0.1f);
        characterImage.transform.eulerAngles = new Vector3(0, 0, -45f);

        // 공격 효과음
        int randomSE = Random.Range(0, 7);
        if(randomSE == 0)
        { 
            SoundManager.soundManager.PlaySE("CharacterAttack1"); 
        }
        else if(1 <= randomSE && randomSE <= 3)
        {
            SoundManager.soundManager.PlaySE("CharacterAttack2");
        }
        else
        {
            SoundManager.soundManager.PlaySE("CharacterAttack3");
        }
        

        // Enemy 컴포넌트 hp 감소
        if (attackEnemy)
        {
            if(enemy != null)
            {
                enemy.enemyCurHp -= characterDamage;
            }
        }
        else if (attackTower)
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

    public void RangeAttack(Enemy enemy)
    {
        GameObject arrow = Instantiate(FightManager.fightManager.arrowPrefabs[0], transform.position, Quaternion.identity);
        arrow.transform.SetParent(transform, false);
        isBattle = false;

        // 효과음 출력
        int randomSE = Random.Range(0, 2);
        if (randomSE == 0)
        {
            SoundManager.soundManager.PlaySE("ArrowSE");
        }
        else
        {
            SoundManager.soundManager.PlaySE("ArrowSE2");
        }
        
    }

    public void ChracterDead()
    {
        SoundManager.soundManager.PlaySE("CharacterDie");
        transform.eulerAngles = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
        isBattle = false;
        isAttack = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static PlayerCharacter;

public class PlayerCharacter : MonoBehaviour
{
    public int characterIndex;                  // ĳ���� ��ȣ
    public int characterMaxHP;                  // ĳ���� ü��
    public int characterCurHP;                    
    public int characterDamage;                 // ĳ���� ���ݷ�
    public int characterDefense;                // ĳ���� ����
    public float characterAttackSpeed;          // ĳ���� ���ݼӵ�
    public float characterMoveSpeed;            // ĳ���� �̵��ӵ�
    public int respawnCoolTime;                 // ĳ���� ��ȯ��Ÿ��
    public int characterCost;                   // ĳ���� ���
    public Image characterImage;                // ĳ���� �̹���
    public Image characterHPBar;                // ĳ���� HP��

    public bool isBattle = false;       // ���� ������ üũ
    public bool isAttack = false;       // ���� ������ üũ
    public bool attackEnemy = false;    // ���� ������
    public bool attackTower = false;    // Ÿ���� ������
    public float attackCoolTime;        // ���� ��Ÿ��

    public Enemy enemy;                 // �� hp�� ������ ��ũ��Ʈ

    // ���Ÿ� ĳ���� test
    public GameObject Arrow;                            // ���Ÿ� ���� ����
    private float focusEnemyDis = Mathf.Infinity;       // ���� ���� ������ �Ÿ�
    private float towerDistance;                        // �� Ÿ������ �Ÿ�
    private int attackRange = 5;                        // ���ݰŸ�

    // �ٰŸ�, ���Ÿ�
    public enum CharacterType
    {
        Melee, Range
    }

    public CharacterType characterType;

    public void SetCharacterCardValues(int index)
    {
        // ��Ƽ ���ÿ� ī�尡 ������
        if (GameManager.instance.partySetCardIndex[index] == -1)
        {
            return;
        }

        // ��Ƽ ���ÿ� ī�尡 ������
        else if (GameManager.instance.partySetCardIndex[index] != -1)
        {
            // �� �ҷ�����
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
        // ���
        if (characterCurHP <= 0)
        {
            ChracterDead();
        }

        // ĳ���� ü�¹� ������Ʈ
        characterHPBar.fillAmount = (float)characterCurHP / (float)characterMaxHP;
    
        // ���� ĳ����
        switch(characterType)
        {
            case CharacterType.Melee:
                {
                    if (!isBattle && !isAttack)
                    {
                        // ��ġ ������
                        characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
                        // �̵�
                        transform.Translate((characterMoveSpeed / 100) * Time.deltaTime * Vector2.right);
                    }
                    else if (isBattle)
                    {
                        transform.Translate(Vector3.zero);

                        // ���� �ӵ� ��Ÿ��
                        attackCoolTime += Time.deltaTime;

                        if (attackCoolTime >= characterAttackSpeed)
                        {
                            // ���� ����
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
                    // �Ÿ� �ʱ�ȭ (���ϸ� ���� �׾ �� �� �� ��� �̵���)
                    focusEnemyDis = Mathf.Infinity;

                    // �� �Ÿ� Ž��
                    foreach (GameObject focusEnemy in FightManager.fightManager.activeEnemys)
                    {
                        float tempDistance = Vector2.Distance(transform.position, focusEnemy.transform.position);

                        // ����� �Ÿ����� �۴ٸ� ����� �Ÿ��� ����
                        if (focusEnemyDis > tempDistance)
                        {
                            focusEnemyDis = tempDistance;
                            // enemy = focusEnemy.GetComponent<Enemy>();
                            Debug.Log(focusEnemyDis);
                        }
                    }

                    // �� Ÿ�� �Ÿ� Ž��
                    towerDistance = Vector2.Distance(transform.position, FightManager.fightManager.enemyTower.transform.position);

                    // �Ÿ� �ȿ� ������ ���� ����
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
                        // ��ġ ������
                        characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
                        // �̵�
                        transform.Translate((characterMoveSpeed / 100) * Time.deltaTime * Vector2.right);
                    }

                    else if (isBattle) 
                    {
                        transform.Translate(Vector3.zero);

                        // ���� �ӵ� ��Ÿ��
                        attackCoolTime += Time.deltaTime / 2;
                    
                        // ���� ���� ����
                        if (attackCoolTime >= characterAttackSpeed)
                        {
                            // ���� ����
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

        // ���� ȿ����
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
        

        // Enemy ������Ʈ hp ����
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

        // ȿ���� ���
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

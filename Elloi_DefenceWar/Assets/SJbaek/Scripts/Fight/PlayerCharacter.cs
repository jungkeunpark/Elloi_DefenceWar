using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public SpriteRenderer characterSpriteRenderer;       // ĳ���� �̹�

    public bool isBattle = false;       // ���� ������ üũ
    public bool isAttack = false;       // ���� ������ üũ
    public bool isEnemy = false;
    public bool isTower = false;
    public float attackCoolTime;        // ���� ��Ÿ��

    public Enemy enemy;

    public void SetCharacterCardValues(int index)
    {
        // �� �ҷ�����
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
        // ���
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

            // ���� �ӵ� ��Ÿ��
            attackCoolTime += Time.deltaTime;

            if (attackCoolTime > characterAttackSpeed)
            {
                // ���� ����
                isAttack = true;
                attackCoolTime = 0;
            }

            if (isAttack && attackCoolTime==0)
            {
                Debug.Log("�÷��̾� ����");
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

        // Enemy ������Ʈ hp ����
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

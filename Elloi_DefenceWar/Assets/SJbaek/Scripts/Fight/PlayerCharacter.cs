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
    public Image characterImage;                // ĳ���� �̹���
    public Image characterHPBar;                // ĳ���� HP��

    public bool isBattle = false;       // ���� ������ üũ
    public bool isAttack = false;       // ���� ������ üũ
    public bool attackEnemy = false;    // ���� ������
    public float attackCoolTime;        // ���� ��Ÿ��

    public Enemy enemy;

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
        if(characterCurHP <= 0)
        {
            ChracterDead();
        }

        // ĳ���� ü�¹� ������Ʈ
        characterHPBar.fillAmount = (float)characterCurHP / (float)characterMaxHP;
    }

    private void FixedUpdate()
    {
        if (!isBattle && !isAttack) 
        {
            // ��ġ ������
            characterImage.transform.eulerAngles = new Vector3(0, 0, 0);
            // �̵�
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

        // Enemy ������Ʈ hp ����
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

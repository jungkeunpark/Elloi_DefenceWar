using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneGatchaPLAY : MonoBehaviour
{
    GatchaNormal gatchaNormal;
    GatchaPremium gatchaPremium;
    GatchaHero gatchaHero;

    //���ӿ�����Ʈ (��í�ִϸ��̼� + ��í�������)�ֻ���
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;
    public GameObject TenTimesGatcha;

    public GameObject BeforeBuy;

    //���ӿ�����Ʈ(�κ�ε��ư��� ��ư�� ��í��Ŀ� ���� ��ư)
    public GameObject lobby;
    public GameObject GameButton;

    //��Ʈ����,�κ��ư �������� �ȴ������� Ȯ�ν�Ű�� true/false��
    public bool Normalretry = false;
    public bool Premiumretry = false;
    public bool Heroretry = false;
    public bool GotoLobby = false;

    //��í�ִϸ��̼��� ������ ���
    public Sprite compareto_Novice;
    public Sprite compareto_Expert;
    public Sprite compareto_Elite;
    public Sprite compareto_Master;
    public Sprite compareto_Hero;



    //������ �ֱ����� ��������� ���ӿ�����Ʈ ȣ��
    public Image NoviceImg;
    public Image ExpertImg;
    public Image EliteImg;
    public Image MasterImg;
    public Image HeroImg;
    public Image[] TenGatchaImg = default;

    public TMP_Text NoviceName;
    public TMP_Text ExpertName;
    public TMP_Text EliteName;
    public TMP_Text MasterName;
    public TMP_Text HeroName;
    public TMP_Text[] TenGatchaNames = default;

    private static int NormalGold = 3000;
    private static int TenTimeNormalGold = 30000;
    private static int PremiumJuwel = 200;
    private static int TenTimePremiumJuwel = 2000;
    private static int HeroJuwel = 600;
    private static int TenTimeHeroJuwel = 6000;

    public GameObject NormalFailObject;
    public GameObject PremiumFailObject;
    public GameObject HeroFailObject;
    public TMP_Text NormalFail;
    public TMP_Text PremiumFail;
    public TMP_Text HeroFail;

    public bool NormalButton;
    public bool PremiumButton;
    public bool HeroButton;
    public bool Button1Time;
    public bool Button10Time;
    //�븻��í��ư�� ������ ����


    public void FailToBuy()
    {
        Debug.Log("���Դ�?");
        if (NormalButton == true && PremiumButton == false && HeroButton == false)
        {
            if (Button1Time == true && Button10Time == false)
            {
                NormalFailObject.transform.GetChild(0).gameObject.SetActive(true);
                NormalFailObject.transform.GetChild(1).gameObject.SetActive(true);
                NormalFail.text = "�Ϲ� �̱⸦ �� ��尡" + (NormalGold - GameManager.instance.playerGold).ToString() + "��� �����մϴ�.";
            }
            else if (Button1Time == false && Button10Time == true)
            {
                NormalFailObject.transform.GetChild(0).gameObject.SetActive(true);
                NormalFailObject.transform.GetChild(1).gameObject.SetActive(true);
                NormalFail.text = "�Ϲ� �̱⸦ �� ��尡" + ((NormalGold * 10) - GameManager.instance.playerGold).ToString() + "��� �����մϴ�.";
            }

        }

        else if (NormalButton == false && PremiumButton == true && HeroButton == false)
        {
            if (Button1Time == true && Button10Time == false)
            {
                PremiumFailObject.transform.GetChild(0).gameObject.SetActive(true);
                PremiumFailObject.transform.GetChild(2).gameObject.SetActive(true);
                PremiumFail.text = "�����̾� �̱⸦ �� ���̾���ȭ��" + (PremiumJuwel - GameManager.instance.playerJuwel).ToString() + "���̾� �����մϴ�.";

            }
            else if (Button1Time == false && Button10Time == true)
            {
                PremiumFailObject.transform.GetChild(0).gameObject.SetActive(true);
                PremiumFailObject.transform.GetChild(2).gameObject.SetActive(true);
                PremiumFail.text = "�����̾� �̱⸦ �� ���̾���ȭ��" + ((PremiumJuwel * 10) - GameManager.instance.playerJuwel).ToString() + "���̾� �����մϴ�.";
            }
        }

        else if (NormalButton == false && PremiumButton == false && HeroButton == true)
        {
            if (Button1Time == true && Button10Time == false)
            {
                HeroFailObject.transform.GetChild(0).gameObject.SetActive(true);
                HeroFailObject.transform.GetChild(3).gameObject.SetActive(true);
                HeroFail.text = "����� �̱⸦ �� ���̾���ȭ��" + (HeroJuwel - GameManager.instance.playerJuwel).ToString() + "���̾� �����մϴ�.";
            }
            else if (Button1Time == false && Button10Time == true)
            {
                HeroFailObject.transform.GetChild(0).gameObject.SetActive(true);
                HeroFailObject.transform.GetChild(3).gameObject.SetActive(true);
                HeroFail.text = "����� �̱⸦ �� ���̾���ȭ��" + (HeroJuwel - GameManager.instance.playerJuwel).ToString() + "���̾� �����մϴ�.";
            }
        }


    }

    public void AfterFail()
    {
        NormalFailObject.transform.GetChild(0).gameObject.SetActive(false);
        PremiumFailObject.transform.GetChild(1).gameObject.SetActive(false);
        HeroFailObject.transform.GetChild(2).gameObject.SetActive(false);

    }


    private void Update()
    {
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Novice.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Novice)
        {
            //�ִϸ��̼� ����
            Novice.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Novice.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button1Time == true && Button10Time == false)
            {

                //��í ������� Ȱ��ȭ
                Novice.transform.GetChild(1).gameObject.SetActive(true);
                //�κ�ε��ư��� ��ư Ȱ��ȭ
                GameButton.transform.GetChild(3).gameObject.SetActive(true);
                //�븻��ư �Ұ��� Ʈ��� (186��)
                if (NormalButton == true)
                {
                    //���� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(0).gameObject.SetActive(true);
                    NormalButton = false;
                }
                //�����̾� ��ư �Ұ��� Ʈ��� (234��)
                if (PremiumButton == true)
                {   //300���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(1).gameObject.SetActive(true);
                    PremiumButton = false;
                }
                //����� ��ư �Ұ��� Ʈ��� (284��)
                if (HeroButton == true)
                {   //3000���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(2).gameObject.SetActive(true);
                    HeroButton = false;
                }
            }
            else if (Button10Time == true && Button1Time == false)
            {

                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
            }

        }
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Expert)
        {//�ִϸ��̼� ����
            Expert.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button1Time == true && Button10Time == false)
            {
                //��í ������� Ȱ��ȭ
                Expert.transform.GetChild(1).gameObject.SetActive(true);
                //�κ�ε��ư��� ��ư Ȱ��ȭ
                GameButton.transform.GetChild(3).gameObject.SetActive(true);
                //�븻��ư �Ұ��� Ʈ��� (186��)
                if (NormalButton == true)
                {//���� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(0).gameObject.SetActive(true);
                }//�����̾� ��ư �Ұ��� Ʈ��� (234��)
                if (PremiumButton == true)
                {//300���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(1).gameObject.SetActive(true);
                }//����� ��ư �Ұ��� Ʈ��� (284��)
                if (HeroButton == true)
                {//3000���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(2).gameObject.SetActive(true);
                }

            }
            else if (Button10Time == true && Button1Time == false)
            {

            }
        }
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Elite)
        {//�ִϸ��̼� ����
            Elite.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button10Time == false && Button1Time == true)
            {
                //��í ������� Ȱ��ȭ
                Elite.transform.GetChild(1).gameObject.SetActive(true);
                //�κ�ε��ư��� ��ư Ȱ��ȭ
                GameButton.transform.GetChild(3).gameObject.SetActive(true);
                //�븻��ư �Ұ��� Ʈ��� (186��)
                if (NormalButton == true)
                {//���� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(0).gameObject.SetActive(true);
                }//�����̾� ��ư �Ұ��� Ʈ��� (234��)
                if (PremiumButton == true)
                {//300���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(1).gameObject.SetActive(true);
                }//����� ��ư �Ұ��� Ʈ��� (284��)
                if (HeroButton == true)
                {//3000���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(2).gameObject.SetActive(true);
                }

            }
            else if (Button10Time == true && Button1Time == false)
            {
                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Master)
        {//�ִϸ��̼� ����
            Master.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button10Time == false && Button1Time == true)
            {
                //��í ������� Ȱ��ȭ
                Master.transform.GetChild(1).gameObject.SetActive(true);
                //�κ�ε��ư��� ��ư Ȱ��ȭ
                GameButton.transform.GetChild(3).gameObject.SetActive(true);
                //�븻��ư �Ұ��� Ʈ��� (186��)
                if (NormalButton == true)
                {//���� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(0).gameObject.SetActive(true);
                }//�����̾� ��ư �Ұ��� Ʈ��� (234��)
                if (PremiumButton == true)
                {//300���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(1).gameObject.SetActive(true);
                }//����� ��ư �Ұ��� Ʈ��� (284��)
                if (HeroButton == true)
                {//3000���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(2).gameObject.SetActive(true);
                }
            }
            else if (Button10Time == true && Button1Time == false)
            {
                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Hero)
        {//�ִϸ��̼� ����
            Hero.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button10Time == false && Button1Time == true)
            {
                //��í ������� Ȱ��ȭ
                Hero.transform.GetChild(1).gameObject.SetActive(true);
                //�κ�ε��ư��� ��ư Ȱ��ȭ
                GameButton.transform.GetChild(3).gameObject.SetActive(true);
                //�븻��ư �Ұ��� Ʈ��� (186��)
                if (NormalButton == true)
                {//���� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(0).gameObject.SetActive(true);
                }//�����̾� ��ư �Ұ��� Ʈ��� (234��)
                if (PremiumButton == true)
                {//300���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(1).gameObject.SetActive(true);
                }
                //����� ��ư �Ұ��� Ʈ��� (284��)
                if (HeroButton == true)
                {//3000���̾Ʒ� �絵���ϴ� ���ӹ�ư Ȱ��ȭ
                    GameButton.transform.GetChild(2).gameObject.SetActive(true);
                }

            }
            else if (Button10Time == true && Button1Time == false)
            {
                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    //�븻 ��ư�� ������
    public void NormalPressbutton()
    {
        Novice.transform.GetChild(1).gameObject.SetActive(false);
        Expert.transform.GetChild(1).gameObject.SetActive(false);
        Elite.transform.GetChild(1).gameObject.SetActive(false);
        Master.transform.GetChild(1).gameObject.SetActive(false);
        Hero.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(3).gameObject.SetActive(false);
        GameButton.transform.GetChild(2).gameObject.SetActive(false);
        GameButton.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(0).gameObject.SetActive(false);
        //normalGatcha�޼ҵ� ����
        if (GameManager.instance.playerGold >= NormalGold)
        {
            gatchaNormal.NormalGatchaOneTime();
        }
        else
        {
            FailToBuy();
        }
    }
    //�����̾� ��Ʈ���� ��ư�� ������
    public void PremiumPressbutton()
    {
        Novice.transform.GetChild(1).gameObject.SetActive(false);
        Expert.transform.GetChild(1).gameObject.SetActive(false);
        Elite.transform.GetChild(1).gameObject.SetActive(false);
        Master.transform.GetChild(1).gameObject.SetActive(false);
        Hero.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(3).gameObject.SetActive(false);
        GameButton.transform.GetChild(2).gameObject.SetActive(false);
        GameButton.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(0).gameObject.SetActive(false);
        //normalGatcha�޼ҵ� ����
        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            gatchaPremium.PremiumGatcha();
        }
        else
        {
            FailToBuy();
        }
    }
    //����� ��Ʈ���� ��ư�� ������
    public void HeroPressbutton()
    {
        Novice.transform.GetChild(1).gameObject.SetActive(false);
        Expert.transform.GetChild(1).gameObject.SetActive(false);
        Elite.transform.GetChild(1).gameObject.SetActive(false);
        Master.transform.GetChild(1).gameObject.SetActive(false);
        Hero.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(3).gameObject.SetActive(false);
        GameButton.transform.GetChild(2).gameObject.SetActive(false);
        GameButton.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(0).gameObject.SetActive(false);
        //normalGatcha�޼ҵ� ����
        if (GameManager.instance.playerJuwel >= HeroJuwel)
        {
            gatchaHero.HeroGatcha();
        }
        else
        {
            FailToBuy();
        }
    }
    //�κ�� ���ư��� ��ư�� ������
    public void Lobby()
    {
        //�κ� Ȱ��ȭ
        lobby.gameObject.SetActive(true);
        //����� ������� ��Ȱ��ȭ
        Novice.transform.GetChild(0).gameObject.SetActive(false);
        Novice.transform.GetChild(1).gameObject.SetActive(false);
        //�ͽ���Ʈ�� ������� ��Ȱ��ȭ
        Expert.transform.GetChild(0).gameObject.SetActive(false);
        Expert.transform.GetChild(1).gameObject.SetActive(false);
        //����Ʈ�� ������� ��Ȱ��ȭ
        Elite.transform.GetChild(0).gameObject.SetActive(false);
        Elite.transform.GetChild(1).gameObject.SetActive(false);
        //�������� ������� ��Ȱ��ȭ
        Master.transform.GetChild(0).gameObject.SetActive(false);
        Master.transform.GetChild(1).gameObject.SetActive(false);
        //������� ������� ��Ȱ��ȭ
        Hero.transform.GetChild(0).gameObject.SetActive(false);
        Hero.transform.GetChild(1).gameObject.SetActive(false);

        //�ٽð�í�ϱ� Ȥ�� ��Ʈ���̹�ư false
        GameButton.transform.GetChild(3).gameObject.SetActive(false);
        GameButton.transform.GetChild(2).gameObject.SetActive(false);
        GameButton.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(0).gameObject.SetActive(false);
    }
}

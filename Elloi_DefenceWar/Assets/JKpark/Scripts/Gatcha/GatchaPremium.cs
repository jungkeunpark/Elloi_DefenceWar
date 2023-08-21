using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GatchaPremium : MonoBehaviour
{
    LoadSceneGatchaPLAY loadSceneGatchaPLAY;
    //���ӿ�����Ʈ (��í�ִϸ��̼� + ��í�������)�ֻ���
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;

    public GameObject BeforeBuy;

    //���ӿ�����Ʈ(�κ�ε��ư��� ��ư�� ��í��Ŀ� ���� ��ư)
    public GameObject lobby;
    public GameObject GameButton;

    //��Ʈ����,�κ��ư �������� �ȴ������� Ȯ�ν�Ű�� true/false��
    public bool Premiumretry = false;
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
    private int PremiumJuwel = 200;

    public GameObject PremiumFailObject;
    public TMP_Text PremiumFail;

    public int[] Premium10times = default;
    //�����̾���í��ư�� ������ ����
    public void PremiumGatcha()
    {
        //�κ� ����
        lobby.gameObject.SetActive(false);

        BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
        BeforeBuy.transform.GetChild(2).gameObject.SetActive(true);
    }


    public void PremiumGatchaOneTime()
    {

        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            GameManager.instance.playerJuwel -= PremiumJuwel;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);


            //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 42.5f)
            {
                //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(601, 610);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        NoviceImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        NoviceName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 42.5f && randomValue < 66.5f)
            {
                //�ͽ���Ʈ�� ��í�ִϸ��̼� Ȱ��ȭ
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(501, 521);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        ExpertImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        ExpertName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 66.5f && randomValue < 94.0f)
            {

                //����Ʈ�� ��í�ִϸ��̼� Ȱ��ȭ
                Elite.transform.GetChild(0).gameObject.SetActive(true);
                //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(401, 440);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        EliteImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        EliteName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 94.0f && randomValue < 99.5f)
            {

                //�������� ��í�ִϸ��̼� Ȱ��ȭ
                Master.transform.GetChild(0).gameObject.SetActive(true);
                //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(301, 360);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        MasterImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        MasterName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.5f && randomValue < 100f)
            {

                //������� ��í�ִϸ��̼� Ȱ��ȭ
                Hero.transform.GetChild(0).gameObject.SetActive(true);
                //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(101, 114);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        HeroImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        HeroName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else
            {
                loadSceneGatchaPLAY.FailToBuy();
            }
        }

    }

    public void PremiumGatchaTenTime()
    {
        if (GameManager.instance.playerJuwel >= 10 * PremiumJuwel)
        {

            GameManager.instance.playerJuwel -= 10 * PremiumJuwel;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);

            for (int a = 0; a < 10; a++)
            {
                float randomValue = UnityEngine.Random.Range(0, 100f);
                if (randomValue < 42.5f)
                {
                    //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(601, 610);
                    Premium10times[a] = index;
                }
                else if (randomValue > 42.5f && randomValue < 66.5f)
                {
                    //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(501, 521);
                    Premium10times[a] = index;

                }
                else if (randomValue > 66.5f && randomValue < 94.0f)
                {
                    //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(401, 440);
                    Premium10times[a] = index;

                }
                else if (randomValue > 94.0f && randomValue < 99.5f)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Premium10times[a] = index;

                }
                else if (randomValue > 99.5f && randomValue < 100f)
                {
                    //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(101, 114);
                    Premium10times[a] = index;

                }


                int b = Mathf.Min(Premium10times);
                if (b > 101 && b < 114)
                {
                    Hero.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (301 < b && b < 360)
                {
                    Master.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (401 < b && b < 440)
                {
                    Elite.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (501 < b && b < 521)
                {
                    Expert.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (601 < b && b < 610)
                {
                    Novice.transform.GetChild(0).gameObject.SetActive(true);
                }

            }
        }
        else
        {
            loadSceneGatchaPLAY.FailToBuy();
        }
    }

    //�����̾���í��ư�� �������·� �ִϸ��̼��� ������ �����ϴ� UI
    public void PremiumGatchaEnding()
    {
        //300ũ����Ż�� �ٽ� ��í�ϴ� �����̾���Ʈ���̹�ư Ȱ��ȭ
        GameButton.transform.GetChild(1).gameObject.SetActive(true);
        //�κ�� ���ư��� ��ư Ȱ��ȭ
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void PremiumTenGatchaEnding()
    {
        GameButton.transform.GetChild(5).gameObject.SetActive(true);
    }

}

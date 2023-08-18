using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneGatchaPLAY : MonoBehaviour
{
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

    //��í ����θ� �������� �����̾��� �������� �븻�� �������� Ȯ���ϴ� true/false��
    private bool HeroButton = false;
    private bool PremiumButton = false;
    private bool NormalButton = false;
    private bool Button1Time = false;
    private bool Button10Time = false;

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

    private int NormalGold = 3000;
    private int TenTimeNormalGold = 30000;
    private int PremiumJuwel = 200;
    private int TenTimePremiumJuwel = 2000;
    private int HeroJuwel = 600;
    private int TenTimeHeroJuwel = 6000;

    public GameObject NormalFailObject;
    public GameObject PremiumFailObject;
    public GameObject HeroFailObject;
    public TMP_Text NormalFail;
    public TMP_Text PremiumFail;
    public TMP_Text HeroFail;

    private int[] Normal10times = default;
    private int[] Premium10times = default;
    private int[] Hero10times = default;
    //�븻��í��ư�� ������ ����
    public void NormalGatcha()
    {
        //�κ� ����
        lobby.gameObject.SetActive(false);
        //�븻��ư�� �����ٴ� bool�� true�� ��ȯ
        NormalButton = true;
        PremiumButton = false;
        HeroButton = false;
        BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
        BeforeBuy.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void NormalGatchaOneTime()
    {
        if (GameManager.instance.playerGold >= NormalGold)
        {
            GameManager.instance.playerGold -= NormalGold;
            Button1Time = true;

            //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 51.5f)
            {
                //����� ��í�ִϸ��̼� Ȱ��ȭ
                Novice.transform.GetChild(0).gameObject.SetActive(true);
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        NoviceImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        NoviceName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 51.5f && randomValue < 90f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        ExpertImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        ExpertName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 90f && randomValue < 99.945f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        EliteImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        EliteName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.945f && randomValue < 99.995f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        MasterImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        MasterName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.995f && randomValue < 100f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        HeroImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        HeroName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }

        }

        else
        {
            FailToBuy();
        }

    }

    public void NormalGatchaTenTimes()
    {
        if (GameManager.instance.playerGold >= 10 * NormalGold)
        {

            GameManager.instance.playerGold -= 10 * NormalGold;
            Button10Time = true;
            for (int a = 0; a < 10; a++)
            {
                //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
                float randomValue = UnityEngine.Random.Range(0, 100f);
                if (randomValue < 51.5f)
                {
                    //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(601, 610);
                    Normal10times[a] = index;
                    // ������ �ε��� ã��
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // ������ �ε��� ã��
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // �̹��� �ҷ�����
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }

                }
                else if (randomValue > 51.5f && randomValue < 90f)
                {
                    //�ͽ���Ʈ�� ��í�ִϸ��̼� Ȱ��ȭ
                    Expert.transform.GetChild(0).gameObject.SetActive(true);
                    //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(501, 521);
                    Normal10times[a] = index;
                    // ������ �ε��� ã��
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // ������ �ε��� ã��
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // �̹��� �ҷ�����
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 90f && randomValue < 99.945f)
                {
                    //����Ʈ�� ��í�ִϸ��̼� Ȱ��ȭ
                    Elite.transform.GetChild(0).gameObject.SetActive(true);
                    //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(401, 440);
                    Normal10times[a] = index;
                    // ������ �ε��� ã��
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // ������ �ε��� ã��
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // �̹��� �ҷ�����
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 99.945f && randomValue < 99.995f)
                {
                    //�������� ��í�ִϸ��̼� Ȱ��ȭ
                    Master.transform.GetChild(0).gameObject.SetActive(true);
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Normal10times[a] = index;
                    // ������ �ε��� ã��
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // ������ �ε��� ã��
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // �̹��� �ҷ�����
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 99.995f && randomValue < 100f)
                {
                    //������� ��í�ִϸ��̼� Ȱ��ȭ
                    Hero.transform.GetChild(0).gameObject.SetActive(true);
                    //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(101, 114);
                    Normal10times[a] = index;
                    // ������ �ε��� ã��
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // ������ �ε��� ã��
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // �̹��� �ҷ�����
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }

            }

            int b = Mathf.Min(Normal10times);
            if (b > 101 && b < 114)
            {
                Hero.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (b > 301 && b < 360)
            {
                Master.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (b > 401 && b < 440)
            {
                Elite.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (b > 501 && b < 521)
            {
                Expert.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (b > 601 && b < 610)
            {
                Novice.transform.GetChild(0).gameObject.SetActive(true);
            }


        }

        else
        {
            FailToBuy();
        }
    }
    //�븻��í��ư�� �������·� �ִϸ��̼��� ������ �����ϴ� UI
    public void NormalGatchaEnding()
    {
        //���� �ٽ� ��í�ϴ� �븻��Ʈ���̹�ư Ȱ��ȭ
        GameButton.transform.GetChild(0).gameObject.SetActive(true);
        //�κ�� ���ư��� ��ư Ȱ��ȭ
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void Normal10GatchaEnding()
    {
        for(int a = 0; a < 10; a++)
        {
            //=Normal10times[a];
        }
    }

    //�����̾���í��ư�� ������ ����
    public void PremiumGatcha()
    {

        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            //�κ� ����
            lobby.gameObject.SetActive(false);
            //�����̾���ư�� �����ٴ� bool�� true�� ��ȯ
            NormalButton = false;
            PremiumButton = true;
            HeroButton = false;

            GameManager.instance.playerJuwel -= PremiumJuwel;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
                BeforeBuy.transform.GetChild(1).gameObject.SetActive(true);
            }
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
    //����ΰ�í��ư�� ������ ����
    //�����̾���í��ư�� ������ ����
    public void PremiumGatchaTenTimes()
    {

        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            //�κ� ����
            lobby.gameObject.SetActive(false);
            //�����̾���ư�� �����ٴ� bool�� true�� ��ȯ
            NormalButton = false;
            PremiumButton = true;
            HeroButton = false;

            GameManager.instance.playerJuwel -= PremiumJuwel;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

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
                return;
            }
        }
    }


    public void HeroGatcha()
    {
        if (GameManager.instance.playerJuwel >= HeroJuwel)
        {
            //�κ� ����
            lobby.gameObject.SetActive(false);
            //����ι�ư�� �����ٴ� bool�� true�� ��ȯ
            NormalButton = false;
            PremiumButton = false;
            HeroButton = true;
            Debug.Log("�����1");
            GameManager.instance.playerJuwel -= HeroJuwel;
            Debug.Log("�����2");


            //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 29.45f)
            {
                //����� ��í�ִϸ��̼� Ȱ��ȭ
                Novice.transform.GetChild(0).gameObject.SetActive(true);
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        NoviceImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        NoviceName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 29.45f && randomValue < 43.45f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        ExpertImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        ExpertName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 43.45f && randomValue < 74.5f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        EliteImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        EliteName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 74.5f && randomValue < 95f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        MasterImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        MasterName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 95f && randomValue < 100f)
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
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        HeroImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        HeroName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
        }
        else
        {
            FailToBuy();
        }

    }
    //����ΰ�í��ư�� �������·� �ִϸ��̼��� ������ �����ϴ� UI
    public void HeroGatchaEnding()
    {
        //3,000ũ����Ż�� �ٽ� ��í�ϴ� ����θ�Ʈ���̹�ư Ȱ��ȭ
        GameButton.transform.GetChild(2).gameObject.SetActive(true);
        //�κ�� ���ư��� ��ư Ȱ��ȭ
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }
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
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Expert)
        {//�ִϸ��̼� ����
            Expert.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
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
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Elite)
        {//�ִϸ��̼� ����
            Elite.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
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
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Master)
        {//�ִϸ��̼� ����
            Master.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
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
        //if�ִϸ��̼��� ��������Ʈ�� ����������� �����ϸ�
        if (Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Hero)
        {//�ִϸ��̼� ����
            Hero.transform.GetChild(0).gameObject.SetActive(false);
            //�ִϸ��̼� ó������ ������ ���� �κ�� ���ư������� ����
            Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
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
        NormalGatcha();
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
        PremiumGatcha();
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
        HeroGatcha();
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

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GatchaNormal : MonoBehaviour
{
    public static GatchaNormal gatchanormal;

    
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;

    public GameObject BeforeBuy;

    public GameObject lobby;
    public GameObject GameButton;

    public bool NormalRetry = false;
    public bool GotoLobby = false;


    public Sprite compareto_Novice;
    public Sprite compareto_Expert;
    public Sprite compareto_Elite;
    public Sprite compareto_Master;
    public Sprite compareto_Hero;

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
    private int NormalGold = 3000;
    private int TenTimeNormalGold = 30000;
    public TMP_Text[] TenGatchaNames = default;

    public GameObject NormalFailObject;
    public TMP_Text NormalFail;
    public int[] Normal10times = new int[10];

    private void Awake()
    {
        gatchanormal = this;
    }

    public void NormalGatcha()
    {
        //�κ� ����
        lobby.gameObject.SetActive(false);
        

        BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
        BeforeBuy.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void NormalGatchaOneTime()
    {
        if (GameManager.instance.playerGold >= NormalGold)
        {
            GameManager.instance.playerGold -= NormalGold;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.NormalButton = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button1Time = true;
            //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 51.5f)
            {
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
                int index = UnityEngine.Random.Range(501, 520);
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

                        //�ͽ���Ʈ����� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        ExpertImg.sprite = tempSprite;

                        //�ͽ���Ʈ����� �̸��� ������ �̸��� ����
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
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.FailToBuy();
        }

    }

    public void NormalGatchaTenTime()
    {
        if (GameManager.instance.playerGold >= TenTimeNormalGold)
        {
            for(int i = 0;i<7;i++)
            {
            ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            GameManager.instance.playerGold -= TenTimeNormalGold;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.NormalButton = true;
            for (int a = 0; a < 10; a++)
            {
                float randomValue = UnityEngine.Random.Range(0, 100f);
                //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
                if (randomValue < 51.5f)
                {
                    //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(601, 610);
                    Normal10times[a] = index;
                   

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

                    //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(501, 520);
                    Normal10times[a] = index;
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

                    //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(401, 440);
                    Normal10times[a] = index;
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

                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Normal10times[a] = index;
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

                    //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(101, 114);
                    Normal10times[a] = index;
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

                int b = Mathf.Min(Normal10times);
                if (b >= 101 && b <= 114)
                {
                    Hero.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (301 <= b && b <= 360)
                {
                    Master.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (401 <= b && b <= 440)
                {
                    Elite.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (501 <= b && b <= 520)
                {
                    Expert.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (601 <= b && b <= 610)
                {
                    Novice.transform.GetChild(0).gameObject.SetActive(true);
                }

                
            }

            ScrollActivate.scrollActivate.press();
        }
        else
        {
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.FailToBuy();
        }


    }
    public void NormalGatchaEnding()
    {
        //���� �ٽ� ��í�ϴ� �븻��Ʈ���̹�ư Ȱ��ȭ
        GameButton.transform.GetChild(0).gameObject.SetActive(true);
        //�κ�� ���ư��� ��ư Ȱ��ȭ
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }
    public void NormalTenGatchaEnding()
    {
        GameButton.transform.GetChild(4).gameObject.SetActive(true);
    }
}

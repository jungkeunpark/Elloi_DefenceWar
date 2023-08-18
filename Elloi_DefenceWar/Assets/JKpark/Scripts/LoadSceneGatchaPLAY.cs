using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneGatchaPLAY : MonoBehaviour
{
    //게임오브젝트 (가챠애니메이션 + 가챠엔딩장면)최상위
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;

    public GameObject BeforeBuy;

    //게임오브젝트(로비로돌아가는 버튼과 가챠방식에 따른 버튼)
    public GameObject lobby;
    public GameObject GameButton;

    //리트라이,로비버튼 눌렀는지 안눌렀는지 확인시키는 true/false값
    public bool Normalretry = false;
    public bool Premiumretry = false;
    public bool Heroretry = false;
    public bool GotoLobby = false;

    //가챠애니메이션의 마지막 장면
    public Sprite compareto_Novice;
    public Sprite compareto_Expert;
    public Sprite compareto_Elite;
    public Sprite compareto_Master;
    public Sprite compareto_Hero;

    //가챠 히어로를 눌렀는지 프리미엄을 눌렀는지 노말을 눌렀는지 확인하는 true/false값
    private bool HeroButton = false;
    private bool PremiumButton = false;
    private bool NormalButton = false;
    private bool Button1Time = false;
    private bool Button10Time = false;

    //정보를 넣기위한 엔딩장면의 게임오브젝트 호출
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
    //노말가챠버튼을 누르면 실행
    public void NormalGatcha()
    {
        //로비를 끄고
        lobby.gameObject.SetActive(false);
        //노말버튼을 눌렀다는 bool값 true로 전환
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

            //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 51.5f)
            {
                //노비스의 가챠애니메이션 활성화
                Novice.transform.GetChild(0).gameObject.SetActive(true);
                //노비스등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(601, 610);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        NoviceImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        NoviceName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 51.5f && randomValue < 90f)
            {
                //익스퍼트의 가챠애니메이션 활성화
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(501, 521);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        ExpertImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        ExpertName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 90f && randomValue < 99.945f)
            {
                //엘리트의 가챠애니메이션 활성화
                Elite.transform.GetChild(0).gameObject.SetActive(true);
                //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(401, 440);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        EliteImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        EliteName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.945f && randomValue < 99.995f)
            {
                //마스터의 가챠애니메이션 활성화
                Master.transform.GetChild(0).gameObject.SetActive(true);
                //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(301, 360);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        MasterImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        MasterName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.995f && randomValue < 100f)
            {
                //히어로의 가챠애니메이션 활성화
                Hero.transform.GetChild(0).gameObject.SetActive(true);
                //히어로등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(101, 114);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        HeroImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        HeroName.text = Name;

                        //카드 획득
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
                //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
                float randomValue = UnityEngine.Random.Range(0, 100f);
                if (randomValue < 51.5f)
                {
                    //노비스등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(601, 610);
                    Normal10times[a] = index;
                    // 동일한 인덱스 찾기
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // 동일한 인덱스 찾기
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // 이미지 불러오기
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //해당 인덱스에 해당하는 이름을 불러옴
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                            TenGatchaImg[a].sprite = tempSprite;

                            //노비스등급의 이름에 가져온 이름을 기입
                            TenGatchaNames[a].text = Name;

                            //카드 획득
                            GameManager.instance.MyCharacter(index);
                        }
                    }

                }
                else if (randomValue > 51.5f && randomValue < 90f)
                {
                    //익스퍼트의 가챠애니메이션 활성화
                    Expert.transform.GetChild(0).gameObject.SetActive(true);
                    //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(501, 521);
                    Normal10times[a] = index;
                    // 동일한 인덱스 찾기
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // 동일한 인덱스 찾기
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // 이미지 불러오기
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //해당 인덱스에 해당하는 이름을 불러옴
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                            TenGatchaImg[a].sprite = tempSprite;

                            //노비스등급의 이름에 가져온 이름을 기입
                            TenGatchaNames[a].text = Name;

                            //카드 획득
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 90f && randomValue < 99.945f)
                {
                    //엘리트의 가챠애니메이션 활성화
                    Elite.transform.GetChild(0).gameObject.SetActive(true);
                    //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(401, 440);
                    Normal10times[a] = index;
                    // 동일한 인덱스 찾기
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // 동일한 인덱스 찾기
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // 이미지 불러오기
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //해당 인덱스에 해당하는 이름을 불러옴
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                            TenGatchaImg[a].sprite = tempSprite;

                            //노비스등급의 이름에 가져온 이름을 기입
                            TenGatchaNames[a].text = Name;

                            //카드 획득
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 99.945f && randomValue < 99.995f)
                {
                    //마스터의 가챠애니메이션 활성화
                    Master.transform.GetChild(0).gameObject.SetActive(true);
                    //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(301, 360);
                    Normal10times[a] = index;
                    // 동일한 인덱스 찾기
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // 동일한 인덱스 찾기
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // 이미지 불러오기
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //해당 인덱스에 해당하는 이름을 불러옴
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                            TenGatchaImg[a].sprite = tempSprite;

                            //노비스등급의 이름에 가져온 이름을 기입
                            TenGatchaNames[a].text = Name;

                            //카드 획득
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 99.995f && randomValue < 100f)
                {
                    //히어로의 가챠애니메이션 활성화
                    Hero.transform.GetChild(0).gameObject.SetActive(true);
                    //히어로등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(101, 114);
                    Normal10times[a] = index;
                    // 동일한 인덱스 찾기
                    for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                    {
                        // 동일한 인덱스 찾기
                        if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                        {
                            // 이미지 불러오기
                            Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                            //해당 인덱스에 해당하는 이름을 불러옴
                            String Name = GameManager.instance.AllCharacter_List[i].Name;

                            //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                            TenGatchaImg[a].sprite = tempSprite;

                            //노비스등급의 이름에 가져온 이름을 기입
                            TenGatchaNames[a].text = Name;

                            //카드 획득
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
    //노말가챠버튼을 누른상태로 애니메이션이 끝나면 실행하는 UI
    public void NormalGatchaEnding()
    {
        //골드로 다시 가챠하는 노말리트라이버튼 활성화
        GameButton.transform.GetChild(0).gameObject.SetActive(true);
        //로비로 돌아가기 버튼 활성화
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void Normal10GatchaEnding()
    {
        for(int a = 0; a < 10; a++)
        {
            //=Normal10times[a];
        }
    }

    //프리미엄가챠버튼을 누르면 실행
    public void PremiumGatcha()
    {

        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            //로비를 끄고
            lobby.gameObject.SetActive(false);
            //프리미엄버튼을 눌렀다는 bool값 true로 전환
            NormalButton = false;
            PremiumButton = true;
            HeroButton = false;

            GameManager.instance.playerJuwel -= PremiumJuwel;

            //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 42.5f)
            {
                //노비스등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(601, 610);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        NoviceImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        NoviceName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 42.5f && randomValue < 66.5f)
            {
                //익스퍼트의 가챠애니메이션 활성화
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(501, 521);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        ExpertImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        ExpertName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 66.5f && randomValue < 94.0f)
            {

                //엘리트의 가챠애니메이션 활성화
                Elite.transform.GetChild(0).gameObject.SetActive(true);
                //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(401, 440);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        EliteImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        EliteName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 94.0f && randomValue < 99.5f)
            {

                //마스터의 가챠애니메이션 활성화
                Master.transform.GetChild(0).gameObject.SetActive(true);
                //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(301, 360);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        MasterImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        MasterName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.5f && randomValue < 100f)
            {

                //히어로의 가챠애니메이션 활성화
                Hero.transform.GetChild(0).gameObject.SetActive(true);
                //히어로등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(101, 114);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        HeroImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        HeroName.text = Name;

                        //카드 획득
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

    //프리미엄가챠버튼을 누른상태로 애니메이션이 끝나면 실행하는 UI
    public void PremiumGatchaEnding()
    {
        //300크리스탈로 다시 가챠하는 프리미엄리트라이버튼 활성화
        GameButton.transform.GetChild(1).gameObject.SetActive(true);
        //로비로 돌아가는 버튼 활성화
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }
    //히어로가챠버튼을 누르면 실행
    //프리미엄가챠버튼을 누르면 실행
    public void PremiumGatchaTenTimes()
    {

        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            //로비를 끄고
            lobby.gameObject.SetActive(false);
            //프리미엄버튼을 눌렀다는 bool값 true로 전환
            NormalButton = false;
            PremiumButton = true;
            HeroButton = false;

            GameManager.instance.playerJuwel -= PremiumJuwel;

            //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 42.5f)
            {
                //노비스등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(601, 610);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        NoviceImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        NoviceName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 42.5f && randomValue < 66.5f)
            {
                //익스퍼트의 가챠애니메이션 활성화
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(501, 521);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        ExpertImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        ExpertName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 66.5f && randomValue < 94.0f)
            {

                //엘리트의 가챠애니메이션 활성화
                Elite.transform.GetChild(0).gameObject.SetActive(true);
                //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(401, 440);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        EliteImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        EliteName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 94.0f && randomValue < 99.5f)
            {

                //마스터의 가챠애니메이션 활성화
                Master.transform.GetChild(0).gameObject.SetActive(true);
                //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(301, 360);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        MasterImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        MasterName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.5f && randomValue < 100f)
            {

                //히어로의 가챠애니메이션 활성화
                Hero.transform.GetChild(0).gameObject.SetActive(true);
                //히어로등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(101, 114);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        HeroImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        HeroName.text = Name;

                        //카드 획득
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
            //로비를 끄고
            lobby.gameObject.SetActive(false);
            //히어로버튼을 눌렀다는 bool값 true로 전환
            NormalButton = false;
            PremiumButton = false;
            HeroButton = true;
            Debug.Log("여기옴1");
            GameManager.instance.playerJuwel -= HeroJuwel;
            Debug.Log("여기옴2");


            //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 29.45f)
            {
                //노비스의 가챠애니메이션 활성화
                Novice.transform.GetChild(0).gameObject.SetActive(true);
                //노비스등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(601, 610);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        NoviceImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        NoviceName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 29.45f && randomValue < 43.45f)
            {
                //익스퍼트의 가챠애니메이션 활성화
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(501, 521);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        ExpertImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        ExpertName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 43.45f && randomValue < 74.5f)
            {
                //엘리트의 가챠애니메이션 활성화
                Elite.transform.GetChild(0).gameObject.SetActive(true);
                //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(401, 440);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        EliteImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        EliteName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 74.5f && randomValue < 95f)
            {
                //마스터의 가챠애니메이션 활성화
                Master.transform.GetChild(0).gameObject.SetActive(true);
                //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(301, 360);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        MasterImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        MasterName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 95f && randomValue < 100f)
            {
                //히어로의 가챠애니메이션 활성화
                Hero.transform.GetChild(0).gameObject.SetActive(true);
                //히어로등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(101, 114);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        HeroImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        HeroName.text = Name;

                        //카드 획득
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
    //히어로가챠버튼을 누른상태로 애니메이션이 끝나면 실행하는 UI
    public void HeroGatchaEnding()
    {
        //3,000크리스탈로 다시 가챠하는 히어로리트라이버튼 활성화
        GameButton.transform.GetChild(2).gameObject.SetActive(true);
        //로비로 돌아가는 버튼 활성화
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }
    public void FailToBuy()
    {
        Debug.Log("들어왔니?");
        if (NormalButton == true && PremiumButton == false && HeroButton == false)
        {
            if (Button1Time == true && Button10Time == false)
            {
                NormalFailObject.transform.GetChild(0).gameObject.SetActive(true);
                NormalFailObject.transform.GetChild(1).gameObject.SetActive(true);
                NormalFail.text = "일반 뽑기를 할 골드가" + (NormalGold - GameManager.instance.playerGold).ToString() + "골드 부족합니다.";
            }
            else if (Button1Time == false && Button10Time == true)
            {
                NormalFailObject.transform.GetChild(0).gameObject.SetActive(true);
                NormalFailObject.transform.GetChild(1).gameObject.SetActive(true);
                NormalFail.text = "일반 뽑기를 할 골드가" + ((NormalGold * 10) - GameManager.instance.playerGold).ToString() + "골드 부족합니다.";
            }

        }

        else if (NormalButton == false && PremiumButton == true && HeroButton == false)
        {
            if (Button1Time == true && Button10Time == false)
            {
                PremiumFailObject.transform.GetChild(0).gameObject.SetActive(true);
                PremiumFailObject.transform.GetChild(2).gameObject.SetActive(true);
                PremiumFail.text = "프리미엄 뽑기를 할 다이아재화가" + (PremiumJuwel - GameManager.instance.playerJuwel).ToString() + "다이아 부족합니다.";

            }
            else if (Button1Time == false && Button10Time == true)
            {
                PremiumFailObject.transform.GetChild(0).gameObject.SetActive(true);
                PremiumFailObject.transform.GetChild(2).gameObject.SetActive(true);
                PremiumFail.text = "프리미엄 뽑기를 할 다이아재화가" + ((PremiumJuwel * 10) - GameManager.instance.playerJuwel).ToString() + "다이아 부족합니다.";
            }
        }

        else if (NormalButton == false && PremiumButton == false && HeroButton == true)
        {
            if (Button1Time == true && Button10Time == false)
            {
                HeroFailObject.transform.GetChild(0).gameObject.SetActive(true);
                HeroFailObject.transform.GetChild(3).gameObject.SetActive(true);
                HeroFail.text = "히어로 뽑기를 할 다이아재화가" + (HeroJuwel - GameManager.instance.playerJuwel).ToString() + "다이아 부족합니다.";
            }
            else if (Button1Time == false && Button10Time == true)
            {
                HeroFailObject.transform.GetChild(0).gameObject.SetActive(true);
                HeroFailObject.transform.GetChild(3).gameObject.SetActive(true);
                HeroFail.text = "히어로 뽑기를 할 다이아재화가" + (HeroJuwel - GameManager.instance.playerJuwel).ToString() + "다이아 부족합니다.";
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
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Novice.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Novice)
        {
            //애니메이션 종료
            Novice.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Novice.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            //가챠 엔딩장면 활성화
            Novice.transform.GetChild(1).gameObject.SetActive(true);
            //로비로돌아가는 버튼 활성화
            GameButton.transform.GetChild(3).gameObject.SetActive(true);
            //노말버튼 불값이 트루면 (186줄)
            if (NormalButton == true)
            {
                //골드로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(0).gameObject.SetActive(true);
                NormalButton = false;
            }
            //프리미엄 버튼 불값이 트루면 (234줄)
            if (PremiumButton == true)
            {   //300다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(1).gameObject.SetActive(true);
                PremiumButton = false;
            }
            //히어로 버튼 불값이 트루면 (284줄)
            if (HeroButton == true)
            {   //3000다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(2).gameObject.SetActive(true);
                HeroButton = false;
            }

        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Expert)
        {//애니메이션 종료
            Expert.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            //가챠 엔딩장면 활성화
            Expert.transform.GetChild(1).gameObject.SetActive(true);
            //로비로돌아가는 버튼 활성화
            GameButton.transform.GetChild(3).gameObject.SetActive(true);
            //노말버튼 불값이 트루면 (186줄)
            if (NormalButton == true)
            {//골드로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(0).gameObject.SetActive(true);
            }//프리미엄 버튼 불값이 트루면 (234줄)
            if (PremiumButton == true)
            {//300다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(1).gameObject.SetActive(true);
            }//히어로 버튼 불값이 트루면 (284줄)
            if (HeroButton == true)
            {//3000다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Elite)
        {//애니메이션 종료
            Elite.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            //가챠 엔딩장면 활성화
            Elite.transform.GetChild(1).gameObject.SetActive(true);
            //로비로돌아가는 버튼 활성화
            GameButton.transform.GetChild(3).gameObject.SetActive(true);
            //노말버튼 불값이 트루면 (186줄)
            if (NormalButton == true)
            {//골드로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(0).gameObject.SetActive(true);
            }//프리미엄 버튼 불값이 트루면 (234줄)
            if (PremiumButton == true)
            {//300다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(1).gameObject.SetActive(true);
            }//히어로 버튼 불값이 트루면 (284줄)
            if (HeroButton == true)
            {//3000다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Master)
        {//애니메이션 종료
            Master.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            //가챠 엔딩장면 활성화
            Master.transform.GetChild(1).gameObject.SetActive(true);
            //로비로돌아가는 버튼 활성화
            GameButton.transform.GetChild(3).gameObject.SetActive(true);
            //노말버튼 불값이 트루면 (186줄)
            if (NormalButton == true)
            {//골드로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(0).gameObject.SetActive(true);
            }//프리미엄 버튼 불값이 트루면 (234줄)
            if (PremiumButton == true)
            {//300다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(1).gameObject.SetActive(true);
            }//히어로 버튼 불값이 트루면 (284줄)
            if (HeroButton == true)
            {//3000다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Hero)
        {//애니메이션 종료
            Hero.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            //가챠 엔딩장면 활성화
            Hero.transform.GetChild(1).gameObject.SetActive(true);
            //로비로돌아가는 버튼 활성화
            GameButton.transform.GetChild(3).gameObject.SetActive(true);
            //노말버튼 불값이 트루면 (186줄)
            if (NormalButton == true)
            {//골드로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(0).gameObject.SetActive(true);
            }//프리미엄 버튼 불값이 트루면 (234줄)
            if (PremiumButton == true)
            {//300다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(1).gameObject.SetActive(true);
            }
            //히어로 버튼 불값이 트루면 (284줄)
            if (HeroButton == true)
            {//3000다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    //노말 버튼을 누르면
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
        //normalGatcha메소드 실행
        NormalGatcha();
    }
    //프리미엄 리트라이 버튼을 누르면
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
        //normalGatcha메소드 실행
        PremiumGatcha();
    }
    //히어로 리트라이 버튼을 누르면
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
        //normalGatcha메소드 실행
        HeroGatcha();
    }
    //로비로 돌아가는 버튼을 누르면
    public void Lobby()
    {
        //로비 활성화
        lobby.gameObject.SetActive(true);
        //노비스의 엔딩장면 비활성화
        Novice.transform.GetChild(0).gameObject.SetActive(false);
        Novice.transform.GetChild(1).gameObject.SetActive(false);
        //익스퍼트의 엔딩장면 비활성화
        Expert.transform.GetChild(0).gameObject.SetActive(false);
        Expert.transform.GetChild(1).gameObject.SetActive(false);
        //엘리트의 엔딩장면 비활성화
        Elite.transform.GetChild(0).gameObject.SetActive(false);
        Elite.transform.GetChild(1).gameObject.SetActive(false);
        //마스터의 엔딩장면 비활성화
        Master.transform.GetChild(0).gameObject.SetActive(false);
        Master.transform.GetChild(1).gameObject.SetActive(false);
        //히어로의 엔딩장면 비활성화
        Hero.transform.GetChild(0).gameObject.SetActive(false);
        Hero.transform.GetChild(1).gameObject.SetActive(false);

        //다시가챠하기 혹은 리트라이버튼 false
        GameButton.transform.GetChild(3).gameObject.SetActive(false);
        GameButton.transform.GetChild(2).gameObject.SetActive(false);
        GameButton.transform.GetChild(1).gameObject.SetActive(false);
        GameButton.transform.GetChild(0).gameObject.SetActive(false);
    }
}

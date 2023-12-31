using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GatchaPremium : MonoBehaviour
{
    public static GatchaPremium gatchaPremium;
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
    public bool Premiumretry = false;
    public bool GotoLobby = false;

    //가챠애니메이션의 마지막 장면
    public Sprite compareto_Novice;
    public Sprite compareto_Expert;
    public Sprite compareto_Elite;
    public Sprite compareto_Master;
    public Sprite compareto_Hero;

    //정보를 넣기위한 엔딩장면의 게임오브젝트 호출
    public Image NoviceImg;
    public Image ExpertImg;
    public Image EliteImg;
    public Image MasterImg;
    public Image HeroImg;
    public Image[] TenGatchaImg = default;
    public Image[] BonusTenGatchaImg = default;
    public int ticket = 0;

    public TMP_Text NoviceName;
    public TMP_Text ExpertName;
    public TMP_Text EliteName;
    public TMP_Text MasterName;
    public TMP_Text HeroName;
    private int PremiumJuwel = 200;
    private int TenTimePremiumJuwel = 2000;
    public TMP_Text[] TenGatchaNames = default;
    public TMP_Text[] BonusTenGatchaNames = default;

    public GameObject PremiumFailObject;
    public TMP_Text PremiumFail;
    public int[] Premium10times = new int[10];


    public List<int> Premiumbonusindex;
    public int premiumBonusMax = 50;
    public int PremiumBonus = 0;


    private void Awake()
    {
        gatchaPremium = this;
    }


    //프리미엄가챠버튼을 누르면 실행
    public void PremiumGatcha()
    {
        //로비를 끄고
        lobby.gameObject.SetActive(false);

        BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
        BeforeBuy.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void PremiumGatchaOneTime()
    {

        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            SoundManager.soundManager.PlaySE("Gatcha_BGM");
            GameManager.instance.playerJuwel -= PremiumJuwel;

            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button1Time = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
            PremiumBonus += 1;
            //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue <= 62.995f)
            {
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        NoviceImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        NoviceName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 62.995f && randomValue <= 83.995f)
            {
                //익스퍼트의 가챠애니메이션 활성화
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                int index = UnityEngine.Random.Range(501, 520);
                // 동일한 인덱스 찾기
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // 동일한 인덱스 찾기
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // 이미지 불러오기
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //해당 인덱스에 해당하는 이름을 불러옴
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        ExpertImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        ExpertName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 83.995f && randomValue <= 97.245f)
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        EliteImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        EliteName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 97.245f && randomValue <= 99.995f)
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //노비스등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
                        MasterImg.sprite = tempSprite;

                        //노비스등급의 이름에 가져온 이름을 기입
                        MasterName.text = Name;

                        //카드 획득
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.995f && randomValue <= 100f)
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

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
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.FailToBuy();
            }
        }

    }

    public void PremiumGatchaTenTime()
    {

        if (GameManager.instance.playerJuwel >= TenTimePremiumJuwel)
        {
            SoundManager.soundManager.PlaySE("Gatcha_BGM");
            for (int i = 0; i < 7; i++)
            {
                ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            GameManager.instance.playerJuwel -= TenTimePremiumJuwel;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
            PremiumBonus += 10;
            for (int a = 0; a < 10; a++)
            {
                float randomValue = UnityEngine.Random.Range(0, 100f);
                if (randomValue <= 62.995f)
                {
                    //노비스등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(601, 610);
                    Premium10times[a] = index;

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
                else if (randomValue > 62.995f && randomValue <= 83.995f)
                {
                    //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(501, 520);
                    Premium10times[a] = index;
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
                else if (randomValue > 83.995f && randomValue <= 97.245f)
                {
                    //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(401, 440);
                    Premium10times[a] = index;
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
                else if (randomValue > 97.245f && randomValue <= 99.995f)
                {
                    //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(301, 360);
                    Premium10times[a] = index;
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
                else if (randomValue > 99.995f && randomValue <= 100f)
                {
                    //히어로등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(101, 114);
                    Premium10times[a] = index;
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


                int b = Mathf.Min(Premium10times);
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

    public void PremiumGatchaBonus()
    {
        
        

        if ((int)(PremiumBonus / premiumBonusMax) >= 1)
        {
            SoundManager.soundManager.PlaySE("Gatcha_BGM");
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
            ticket = (int)(PremiumBonus / premiumBonusMax);

            Master.transform.GetChild(0).gameObject.SetActive(true);
            if (ticket > 0 && ticket <= 9)
            {
                PremiumBonus -= ticket * 50;

                for (int i = 0; i < 7; i++)
                {
                    ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

                }
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus = true;
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
                for (int a = 0; a < ticket; a++)
                {
                    //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(301, 360);
                    Premiumbonusindex[a] = index;

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
                            BonusTenGatchaImg[a].sprite = tempSprite;

                            //노비스등급의 이름에 가져온 이름을 기입
                            BonusTenGatchaNames[a].text = Name;

                            //카드 획득
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
            }
            else if(ticket >= 10)
            {
                PremiumBonus -= 500;

                for (int i = 0; i < 7; i++)
                {
                    ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

                }
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus = true;
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
                for (int a = 0; a < 10; a++)
                {
                    //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(301, 360);
                    Premiumbonusindex[a] = index;
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
                            BonusTenGatchaImg[a].sprite = tempSprite;

                            //노비스등급의 이름에 가져온 이름을 기입
                            BonusTenGatchaNames[a].text = Name;

                            //카드 획득
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
            }
            BonusScroll.Bonusscroll.press();
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

    public void PremiumTenGatchaEnding()
    {
        GameButton.transform.GetChild(5).gameObject.SetActive(true);
    }




}

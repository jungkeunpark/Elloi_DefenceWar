using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GatchaHero : MonoBehaviour
{
    LoadSceneGatchaPLAY loadSceneGatchaPLAY;
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
    public bool HeroRetry = false;
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
    public TMP_Text[] TenGatchaNames = default;
    private int HeroJuwel = 600;

    public GameObject HeroFailObject;
    public TMP_Text HeroFail;

    public int[] Hero10times = default;

    public void HeroGatcha()
    {
        //로비를 끄고
        lobby.gameObject.SetActive(false);

        BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
        BeforeBuy.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void HeroGatchaOneTime()
    {
        if (GameManager.instance.playerJuwel >= HeroJuwel)
        {
            GameManager.instance.playerJuwel -= HeroJuwel;

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
            loadSceneGatchaPLAY.FailToBuy();
        }

    }

    public void HeroGatchaTenTime()
    {
        if (GameManager.instance.playerJuwel >= 10 * HeroJuwel)
        {
            GameManager.instance.playerJuwel -= 10 * HeroJuwel;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);


            for (int a = 0; a < 10; a++)
            {
                float randomValue = UnityEngine.Random.Range(0, 100f);
                //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
                if(randomValue< 29.45f)
                {
                    //노비스등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(601, 610);
                    Hero10times[a] = index;
                }
                else if (randomValue > 29.45f && randomValue < 43.45f)
                {
                    //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(501, 521);
                    Hero10times[a] = index;
                }
                else if (randomValue > 43.45f && randomValue < 74.5f)
                {
                    //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(401, 440);
                    Hero10times[a] = index;

                }
                else if (randomValue > 74.5f && randomValue < 95f)
                {
                    //마스터등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(301, 360);
                    Hero10times[a] = index;

                }
                else if (randomValue > 95f && randomValue < 100f)
                {
                    //히어로등급의 모든 인덱스번호중에 한개를 뽑음
                    int index = UnityEngine.Random.Range(101, 114);
                    Hero10times[a] = index;
                }

                int b = Mathf.Min(Hero10times);
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



    //히어로가챠버튼을 누른상태로 애니메이션이 끝나면 실행하는 UI
    public void HeroGatchaEnding()
    {
        //600크리스탈로 다시 가챠하는 히어로리트라이버튼 활성화
        GameButton.transform.GetChild(2).gameObject.SetActive(true);
        //로비로 돌아가는 버튼 활성화
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void HeroTenthGatchaEnding()
    {
        GameButton.transform.GetChild(6).gameObject.SetActive(true);
    }
}

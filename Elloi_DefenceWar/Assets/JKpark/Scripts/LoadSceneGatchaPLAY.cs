using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadSceneGatchaPLAY : MonoBehaviour
{
    //게임오브젝트 (가챠애니메이션 + 가챠엔딩장면)최상위
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;

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

    //정보를 넣기위한 엔딩장면의 게임오브젝트 호출
    public Image NoviceImg;
    public Image ExpertImg;
    public Image EliteImg;
    public Image MasterImg;
    public Image HeroImg;

    public TMP_Text NoviceName;
    public TMP_Text ExpertName;
    public TMP_Text EliteName;
    public TMP_Text MasterName;
    public TMP_Text HeroName;



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
            if(PremiumButton == true)
            {//300다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(1).gameObject.SetActive(true);
            }//히어로 버튼 불값이 트루면 (284줄)
            if(HeroButton == true)
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
            if(PremiumButton == true)
            {//300다이아로 재도전하는 게임버튼 활성화
                GameButton.transform.GetChild(1).gameObject.SetActive(true);
            }//히어로 버튼 불값이 트루면 (284줄)
            if(HeroButton == true)
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



    //노말가챠버튼을 누르면 실행
    public void NormalGatcha()
    {
        //로비를 끄고
        lobby.gameObject.SetActive(false);
        //노말버튼을 눌렀다는 bool값 true로 전환
        NormalButton = true;
        PremiumButton = false;
        HeroButton = false;

     


        //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
        float randomValue = UnityEngine.Random.Range(0, 100f);
        if(randomValue<51.5f)
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
                }
            }
        }
        else if(randomValue>51.5f && randomValue<90f)
        {
            //익스퍼트의 가챠애니메이션 활성화
            Expert.transform.GetChild(0).gameObject.SetActive(true);
            //익스퍼트등급의 모든 인덱스번호중에 한개를 뽑음
            int index = UnityEngine.Random.Range(501, 521);
            //해당 인덱스에 해당하는 이미지 스프라이트를 불러옴
            Sprite tempSprite = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].transform.GetChild(2).GetComponent<Image>().sprite;
            //해당 인덱스에 해당하는 이름을 불러옴
            String Name = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].name;
            //익스퍼트등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
            ExpertImg.sprite = tempSprite;
            //익스퍼트등급의 이름에 가져온 이름을 기입
            ExpertName.text = Name;

        }
        else if(randomValue>90f && randomValue< 99.945f)
        {
            //엘리트의 가챠애니메이션 활성화
            Elite.transform.GetChild(0).gameObject.SetActive(true);
            //엘리트등급의 모든 인덱스번호중에 한개를 뽑음
            int index = UnityEngine.Random.Range(401, 440);
            //해당 인덱스에 해당하는 이미지 스프라이트를 불러옴
            Sprite tempSprite = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].transform.GetChild(2).GetComponent<Image>().sprite;
            //해당 인덱스에 해당하는 이름을 불러옴
            String Name = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].name;
            //엘리트등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
            EliteImg.sprite = tempSprite;
            //엘리트등급의 이름에 가져온 이름을 기입
            EliteName.text = Name;

        }
        else if(randomValue>99.945f && randomValue < 99.995f)
        {
            //마스터의 가챠애니메이션 활성화
            Master.transform.GetChild(0).gameObject.SetActive(true);
            //마스터등급의 모든 인덱스번호중에 한개를 뽑음
            int index = UnityEngine.Random.Range(301, 360);
            //해당 인덱스에 해당하는 이미지 스프라이트를 불러옴
            Sprite tempSprite = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].transform.GetChild(2).GetComponent<Image>().sprite;
            //해당 인덱스에 해당하는 이름을 불러옴
            String Name = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].name;
            //마스터등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
            MasterImg.sprite = tempSprite;
            //마스터등급의 이름에 가져온 이름을 기입
            MasterName.text = Name;
        }
        else if(randomValue>99.995f && randomValue < 100f)
        {
            //히어로의 가챠애니메이션 활성화
            Hero.transform.GetChild(0).gameObject.SetActive(true);
            //히어로등급의 모든 인덱스번호중에 한개를 뽑음
            int index = UnityEngine.Random.Range(101, 114);
            //해당 인덱스에 해당하는 이미지 스프라이트를 불러옴
            Sprite tempSprite = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].transform.GetChild(2).GetComponent<Image>().sprite;
            //해당 인덱스에 해당하는 이름을 불러옴
            String Name = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].name;
            //히어로등급의 이미지의 스프라이트에 가져온 이미지 스프라이트 기입
            HeroImg.sprite = tempSprite;
            //히어로등급의 이름에 가져온 이름을 기입
            HeroName.text = Name;
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
    //프리미엄가챠버튼을 누르면 실행
    public void PremiumGatcha()
    {
        //로비를 끄고
        lobby.gameObject.SetActive(false);
        //프리미엄버튼을 눌렀다는 bool값 true로 전환
        NormalButton = false;
        PremiumButton = true;
        HeroButton = false;
        //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
        float randomValue = UnityEngine.Random.Range(0, 100f);
        if (randomValue < 42.5f)
        {
            //노비스의 가챠애니메이션 활성화
            Novice.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 42.5f && randomValue < 66.5f)
        {
            //익스퍼트의 가챠애니메이션 활성화
            Expert.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 66.5f && randomValue < 94.0f)
        {

            //엘리트의 가챠애니메이션 활성화
            Elite.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 94.0f && randomValue < 99.5f)
        {

            //마스터의 가챠애니메이션 활성화
            Master.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 99.5f && randomValue < 100f)
        {
            //히어로의 가챠애니메이션 활성화
            Hero.transform.GetChild(0).gameObject.SetActive(true);
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
    public void HeroGatcha()
    {
        //로비를 끄고
        lobby.gameObject.SetActive(false);
        //히어로버튼을 눌렀다는 bool값 true로 전환
        NormalButton = false;
        PremiumButton = false;
        HeroButton = true;
        //랜덤확률을 돌려서 확률에따라 히어로//마스터//엘리트//익스퍼트//노말 소환
        float randomValue = UnityEngine.Random.Range(0, 100f);
        if (randomValue < 29.45f)
        {
            //노비스의 가챠애니메이션 활성화
            Novice.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 29.45f && randomValue < 43.45f)
        {
            //익스퍼트의 가챠애니메이션 활성화
            Expert.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 43.45f && randomValue < 74.5f)
        {
            //엘리트의 가챠애니메이션 활성화
            Elite.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 74.5f && randomValue < 95f)
        {
            //마스터의 가챠애니메이션 활성화
            Master.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 95f && randomValue < 100f)
        {
            //히어로의 가챠애니메이션 활성화
            Hero.transform.GetChild(0).gameObject.SetActive(true);
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
}

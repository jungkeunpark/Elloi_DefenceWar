using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneGatchaPLAY : MonoBehaviour
{
    public static LoadSceneGatchaPLAY loadSceneGatchaPlay;

    //게임오브젝트 (가챠애니메이션 + 가챠엔딩장면)최상위
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;
    public GameObject TenTimesGatcha;

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

    public bool NormalButton = false;
    public bool PremiumButton = false;
    public bool HeroButton = false;
    public bool Button1Time = false;
    public bool Button10Time = false;
    //노말가챠버튼을 누르면 실행


    public void FailToBuy()
    {

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

    private void Awake()
    {
        loadSceneGatchaPlay = this;
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

            if (Button1Time == true && Button10Time == false)
            {

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
            else if (Button10Time == true && Button1Time == false)
            {

                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.GoCoroutine();
            }

        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Expert)
        {//애니메이션 종료
            Expert.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button1Time == true && Button10Time == false)
            {
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
            else if (Button10Time == true && Button1Time == false)
            {
                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.GoCoroutine();
            }
        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Elite)
        {//애니메이션 종료
            Elite.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button10Time == false && Button1Time == true)
            {
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
            else if (Button10Time == true && Button1Time == false)
            {
                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.GoCoroutine();
            }
        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Master)
        {//애니메이션 종료
            Master.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button10Time == false && Button1Time == true)
            {
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
            else if (Button10Time == true && Button1Time == false)
            {
                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.GoCoroutine();
            }
        }
        //if애니메이션의 스프라이트가 마지막장면이 등장하면
        if (Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Hero)
        {//애니메이션 종료
            Hero.transform.GetChild(0).gameObject.SetActive(false);
            //애니메이션 처음으로 돌려서 끝에 로비로 돌아가는현상 방지
            Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;

            if (Button10Time == false && Button1Time == true)
            {
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
            else if (Button10Time == true && Button1Time == false)
            {
                TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.GoCoroutine();
            }
        }
    }

    //노말 리트라이 버튼을 누르면
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
        if (GameManager.instance.playerGold >= NormalGold)
        {
            GatchaNormal.gatchanormal.NormalGatchaOneTime();
        }
        else
        {
            FailToBuy();
        }
    }

    //10연차노말 리트라이 버튼을 누르면
    public void TenTimesNormalPressbutton()
    {
        for (int i = 0; i < 10; i++)
        {
            GatchaNormal.gatchanormal.Normal10times[i] = default;
            GatchaNormal.gatchanormal.TenGatchaImg[i].sprite = default;
            GatchaNormal.gatchanormal.TenGatchaNames[i].text = default;
            Destroy(ScrollActivate.scrollActivate.Ending[i].transform.GetChild(0).gameObject);
            Destroy(ScrollActivate.scrollActivate.Ending[i].transform.GetChild(2).gameObject);
            ScrollActivate.scrollActivate.Ending[i].transform.GetChild(1).gameObject.SetActive(false);
            ScrollActivate.scrollActivate.Ending[i].transform.GetChild(3).gameObject.SetActive(false);
        }


        for (int i = 0; i < 7; i++)
        {
            ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

        }
        LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
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
        if (GameManager.instance.playerGold >= NormalGold)
        {
            GatchaNormal.gatchanormal.NormalGatchaTenTime();
        }
        else
        {
            FailToBuy();
        }
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
        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            GatchaPremium.gatchaPremium.PremiumGatchaOneTime();
        }
        else
        {
            FailToBuy();
        }
    }
    //프리미엄 리트라이 버튼을 누르면
    public void TenTimesPremiumPressbutton()
    {
        for (int i = 0; i < 10; i++)
        {
            GatchaPremium.gatchaPremium.Premium10times[i] = default;
            GatchaPremium.gatchaPremium.TenGatchaImg[i].sprite = default;
            GatchaPremium.gatchaPremium.TenGatchaNames[i].text = default;
            Destroy(ScrollActivate.scrollActivate.Ending[i].transform.GetChild(0).gameObject);
            Destroy(ScrollActivate.scrollActivate.Ending[i].transform.GetChild(2).gameObject);
            ScrollActivate.scrollActivate.Ending[i].transform.GetChild(1).gameObject.SetActive(false);
            ScrollActivate.scrollActivate.Ending[i].transform.GetChild(3).gameObject.SetActive(false);
        }


        for (int i = 0; i < 7; i++)
        {
            ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

        }


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
        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            GatchaPremium.gatchaPremium.PremiumGatchaTenTime();
        }
        else
        {
            FailToBuy();
        }
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
        if (GameManager.instance.playerJuwel >= HeroJuwel)
        {
            GatchaHero.gatchaHero.HeroGatchaOneTime();
        }
        else
        {
            FailToBuy();
        }
    }
    //히어로 10연차리트라이 버튼을 누르면
    public void TenTimesHeroPressbutton()
    {
        for (int i = 0; i < 10; i++)
        {
            GatchaHero.gatchaHero.Hero10times[i] = default;
            GatchaHero.gatchaHero.TenGatchaImg[i].sprite = default;
            GatchaHero.gatchaHero.TenGatchaNames[i].text = default;
            Destroy(ScrollActivate.scrollActivate.Ending[i].transform.GetChild(0).gameObject);
            Destroy(ScrollActivate.scrollActivate.Ending[i].transform.GetChild(2).gameObject);
            ScrollActivate.scrollActivate.Ending[i].transform.GetChild(1).gameObject.SetActive(false);
            ScrollActivate.scrollActivate.Ending[i].transform.GetChild(3).gameObject.SetActive(false);
        }


        for (int i = 0; i < 7; i++)
        {
            ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

        }

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
        if (GameManager.instance.playerJuwel >= HeroJuwel)
        {
            GatchaHero.gatchaHero.HeroGatchaTenTime();
        }
        else
        {
            FailToBuy();
        }
    }

    //로비로 돌아가는 버튼을 누르면
    public void Lobby()
    {
        //로비 활성화
        BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
        BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);
        BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
        BeforeBuy.transform.GetChild(3).gameObject.SetActive(false);
        lobby.gameObject.SetActive(true);
        lobby.transform.GetChild(0).gameObject.SetActive(true);
        //노비스의 엔딩장면 비활성화
        TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
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

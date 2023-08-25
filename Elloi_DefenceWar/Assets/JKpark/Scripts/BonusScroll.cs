using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScroll : MonoBehaviour
{
    public static BonusScroll Bonusscroll;
    public List<GameObject> Image;
    public List<int> indexnumber;
    public List<Text> Name;
    public GameObject commonbuttonui;
    public Animator Masteranimator = default;
    public Animator Heroanimator = default;
    public TMPro.TextMeshProUGUI Premiumtext;
    public TMPro.TextMeshProUGUI Premiumbeforetext;

    public TMPro.TextMeshProUGUI Herotext;
    public TMPro.TextMeshProUGUI Herobeforetext;



    public GameObject[] Ranks;
    public GameObject[] Scrolls;


    private void Awake()
    {
        Bonusscroll = this;

    }

    private void Update()
    {
        int a = GatchaPremium.gatchaPremium.premiumBonusMax - GatchaPremium.gatchaPremium.PremiumBonus;
        if (a < 0)
        {
            a = 0;
        }
        int b = GatchaHero.gatchaHero.HeroBonusMax - GatchaHero.gatchaHero.HeroBonus;
        if (b < 0)
        {
            b = 0;
        }
        Premiumtext.text = string.Format("{0} / {1}", GatchaPremium.gatchaPremium.PremiumBonus, GatchaPremium.gatchaPremium.premiumBonusMax);
        Premiumbeforetext.text = string.Format("다음 마스터까지 남은 뽑기 수 : {0}", a);

        Herotext.text = string.Format("{0} / {1}", GatchaHero.gatchaHero.HeroBonus, GatchaHero.gatchaHero.HeroBonusMax);
        Herobeforetext.text = string.Format("다음 히어로까지 남은 뽑기 수 : {0}", b);


    }
    public void GoCoroutine()
    {
        StartCoroutine(TempoGacha());
    }

    IEnumerator TempoGacha()
    {
        if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus == true)
        {

            for (int i = 0; i < GatchaPremium.gatchaPremium.ticket; i++)
            {
                if (indexnumber[i] > 301)
                {
                    GameObject Scroll = Instantiate(Scrolls[0], Image[i].transform.position, Quaternion.identity);
                    Scroll.transform.parent = Image[i].transform;
                    Scroll.transform.SetSiblingIndex(2);
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    yield break;

                }

            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.BonusGatcha.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus == true)
        {

            for (int i = 0; i < GatchaHero.gatchaHero.ticket; i++)
            {

                if (indexnumber[i] > 101)
                {
                    GameObject Scroll = Instantiate(Scrolls[1], Image[i].transform.position, Quaternion.identity);
                    Scroll.transform.parent = Image[i].transform;
                    Scroll.transform.SetSiblingIndex(2);
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    yield break;

                }

            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.BonusGatcha.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void press()
    {

        for (int i = 0; i < 10; i++)
        {

            if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus == true)
            {
                indexnumber[i] = GatchaPremium.gatchaPremium.Premiumbonusindex[i];
            }
            else if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus == true)
            {
                indexnumber[i] = GatchaHero.gatchaHero.Herobonusindex[i];
            }




            if (indexnumber[i] >= 200)
            {
                GameObject Rank = Instantiate(Ranks[0], Image[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Image[i].transform;
                Rank.transform.SetSiblingIndex(0);

            }
            else if (indexnumber[i] < 200)
            {
                GameObject Rank = Instantiate(Ranks[1], Image[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Image[i].transform;
                Rank.transform.SetSiblingIndex(0);


            }
            Image[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void PressAllBonusButton()
    {
        if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus == true)
        {
            for (int i = 0; i < GatchaPremium.gatchaPremium.ticket; i++)
            {

                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(0).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(1).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(2).gameObject.SetActive(false);
                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(3).gameObject.SetActive(true);
            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.BonusGatcha.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            commonbuttonui.transform.GetChild(8).gameObject.SetActive(true);
        }
        if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus == true)
        {
            for (int i = 0; i < GatchaHero.gatchaHero.ticket; i++)
            {


                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(0).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(1).gameObject.SetActive(true);
                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(2).gameObject.SetActive(false);
                ScrollActivate.scrollActivate.Bonus[i].transform.GetChild(3).gameObject.SetActive(true);
            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.BonusGatcha.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            commonbuttonui.transform.GetChild(8).gameObject.SetActive(true);

        }

    }
}



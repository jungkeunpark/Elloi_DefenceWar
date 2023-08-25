using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollActivate : MonoBehaviour
{
    public static ScrollActivate scrollActivate;
    public GameObject[] Ending;
    public GameObject[] Bonus;

    public List<int> indexnumber;
    public List<Text> Name;

    public GameObject commonbuttonui;


    public Animator Noviceanimator = default;
    public Animator Expertanimator = default;
    public Animator Eliteanimator = default;
    public Animator Masteranimator = default;
    public Animator Heroanimator = default;

    public GameObject[] Ranks;
    public GameObject[] Scrolls;

    private void Awake()
    {
        scrollActivate = this;
    }



    public void GoCoroutine()
    {
        StartCoroutine(TempoGacha());
    }




    IEnumerator TempoGacha()
    {
        for (int i = 0; i < 10; i++)
        {
            if (indexnumber[i] > 601)
            {

                GameObject Scroll = Instantiate(Scrolls[0], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(2);
                yield return new WaitForSeconds(0.2f);
            }
            else if (indexnumber[i] > 501)
            {
                GameObject Scroll = Instantiate(Scrolls[1], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(2);
                yield return new WaitForSeconds(0.2f);
            }
            else if (indexnumber[i] > 401)
            {
                GameObject Scroll = Instantiate(Scrolls[2], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(2);
                yield return new WaitForSeconds(0.2f);
            }
            else if (indexnumber[i] > 301)
            {
                GameObject Scroll = Instantiate(Scrolls[3], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(2);
                yield return new WaitForSeconds(0.2f);
            }
            else if (indexnumber[i] > 101)
            {
                GameObject Scroll = Instantiate(Scrolls[4], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(2);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                yield break;

            }

        }
        LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).transform.GetChild(10).gameObject.SetActive(true);
    }










    public void press()
    {

        for (int i = 0; i < 10; i++)
        {
            if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.NormalButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time == true)
            {
                indexnumber[i] = GatchaNormal.gatchanormal.Normal10times[i];
            }
            else if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time == true)
            {
                indexnumber[i] = GatchaPremium.gatchaPremium.Premium10times[i];
            }
            else if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time == true)
            {
                indexnumber[i] = GatchaHero.gatchaHero.Hero10times[i];
            }



            if (indexnumber[i] >= 600)
            {

                GameObject Rank = Instantiate(Ranks[0], Ending[i].transform.position, Quaternion.identity);

                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);




            }
            else if (indexnumber[i] >= 500)
            {
                GameObject Rank = Instantiate(Ranks[1], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);


            }
            else if (indexnumber[i] >= 400)
            {
                GameObject Rank = Instantiate(Ranks[2], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);


            }
            else if (indexnumber[i] >= 300)
            {
                GameObject Rank = Instantiate(Ranks[3], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);

            }
            else if (indexnumber[i] >= 100)
            {
                GameObject Rank = Instantiate(Ranks[4], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);


            }
            Ending[i].transform.GetChild(0).gameObject.SetActive(false);


        }
    }
    public void PressAllButton()
    {
        for (int i = 0; i < 10; i++)
        {
            Ending[i].transform.GetChild(0).gameObject.SetActive(true);
            Ending[i].transform.GetChild(1).gameObject.SetActive(true);
            Ending[i].transform.GetChild(2).gameObject.SetActive(false);
            Ending[i].transform.GetChild(3).gameObject.SetActive(true);

        }
        if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.NormalButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time == true)
        {
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).transform.GetChild(10).gameObject.SetActive(false);
            commonbuttonui.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time == true)
        {
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).transform.GetChild(10).gameObject.SetActive(false);
            commonbuttonui.transform.GetChild(5).gameObject.SetActive(true);
        }
        else if (LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton == true && LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time == true)
        {
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).transform.GetChild(10).gameObject.SetActive(false);
            commonbuttonui.transform.GetChild(6).gameObject.SetActive(true);
        }
    }










}

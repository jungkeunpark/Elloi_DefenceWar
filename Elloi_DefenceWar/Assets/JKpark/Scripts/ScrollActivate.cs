using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollActivate : MonoBehaviour
{
    GatchaNormal gatchaNormal;
    GatchaPremium gatchaPremium;
    GatchaHero gatchaHero;
    LoadSceneGatchaPLAY loadSceneGatchaPLAY;
    public GameObject[] Ending;
    private List<int> indexnumber;
    private List<Sprite> tempSprite;
    private List<Text> Name;


    public Animator Noviceanimator = default;
    public Animator Expertanimator = default;
    public Animator Eliteanimator = default;
    public Animator Masteranimator = default;
    public Animator Heroanimator = default;
    private bool animationFinished = false;

    public GameObject[] Ranks;
    public GameObject[] Scrolls;


    private void press()
    {
        int temp;

        for (int i = 0; i < 10; i++)
        {

            tempSprite[i] = loadSceneGatchaPLAY.TenGatchaImg[i].sprite;
            Name[i].text = loadSceneGatchaPLAY.TenGatchaNames[i].text;



            if(loadSceneGatchaPLAY.NormalButton == true && loadSceneGatchaPLAY.Button10Time == true)
            {
                indexnumber[i] = gatchaNormal.Normal10times[i];
            }
            else if(loadSceneGatchaPLAY.PremiumButton == true && loadSceneGatchaPLAY.Button10Time == true)
            {
                indexnumber[i] = gatchaPremium.Premium10times[i];
            }
            else if(loadSceneGatchaPLAY.HeroButton == true && loadSceneGatchaPLAY.Button10Time == true)
            {
                indexnumber[i] = gatchaHero.Hero10times[i];
            }



            if (indexnumber[i] > indexnumber[i - 1])
            {
                temp = indexnumber[i];
                indexnumber[i] = indexnumber[i - 1];
                indexnumber[i - 1] = temp;
                
            }


            if (indexnumber[i] > 601)
            {
                
                GameObject Rank = Instantiate(Ranks[0], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);

                GameObject Scroll = Instantiate(Ranks[0], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(3);

                
                
            }
            else if (indexnumber[i] > 501)
            {
                GameObject Rank = Instantiate(Ranks[1], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);

                GameObject Scroll = Instantiate(Ranks[1], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(3);
            }
            else if (indexnumber[i] > 401)
            {
                GameObject Rank = Instantiate(Ranks[2], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);

                GameObject Scroll = Instantiate(Ranks[2], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(3);
            }
            else if (indexnumber[i] > 301)
            {
                GameObject Rank = Instantiate(Ranks[3], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);

                GameObject Scroll = Instantiate(Ranks[3], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(3);
            }
            else if (indexnumber[i] > 101)
            {
                GameObject Rank = Instantiate(Ranks[4], Ending[i].transform.position, Quaternion.identity);
                Rank.transform.parent = Ending[i].transform;
                Rank.transform.SetSiblingIndex(0);

                GameObject Scroll = Instantiate(Ranks[4], Ending[i].transform.position, Quaternion.identity);
                Scroll.transform.parent = Ending[i].transform;
                Scroll.transform.SetSiblingIndex(3);
            }

        }
    }
    private void Update()
    {
        for (int i = 0; i < 10; i++)
        {

            if (!animationFinished && Noviceanimator.GetCurrentAnimatorStateInfo(0).IsName("ScrollNovice"))
            {
                animationFinished = true;
                Noviceanimator.enabled = false;
                Ending[i].transform.GetChild(3).gameObject.SetActive(false);
                Ending[i].transform.GetChild(0).gameObject.SetActive(true);
                Ending[i].transform.GetChild(1).gameObject.SetActive(true);
                Ending[i].transform.GetChild(2).gameObject.SetActive(true);
            }


            if (!animationFinished && Expertanimator.GetCurrentAnimatorStateInfo(0).IsName("ScrollExpert"))
            {
                animationFinished = true;
                Noviceanimator.enabled = false;
                Ending[i].transform.GetChild(3).gameObject.SetActive(false);
                Ending[i].transform.GetChild(0).gameObject.SetActive(true);
                Ending[i].transform.GetChild(1).gameObject.SetActive(true);
                Ending[i].transform.GetChild(2).gameObject.SetActive(true);
            }


            if (!animationFinished && Eliteanimator.GetCurrentAnimatorStateInfo(0).IsName("ScrollElite"))
            {
                animationFinished = true;
                Noviceanimator.enabled = false;
                Ending[i].transform.GetChild(3).gameObject.SetActive(false);
                Ending[i].transform.GetChild(0).gameObject.SetActive(true);
                Ending[i].transform.GetChild(1).gameObject.SetActive(true);
                Ending[i].transform.GetChild(2).gameObject.SetActive(true);
            }


            if (!animationFinished && Masteranimator.GetCurrentAnimatorStateInfo(0).IsName("ScrollMaster"))
            {
                animationFinished = true;
                Noviceanimator.enabled = false;
                Ending[i].transform.GetChild(3).gameObject.SetActive(false);
                Ending[i].transform.GetChild(0).gameObject.SetActive(true);
                Ending[i].transform.GetChild(1).gameObject.SetActive(true);
                Ending[i].transform.GetChild(2).gameObject.SetActive(true);
            }


            if (!animationFinished && Heroanimator.GetCurrentAnimatorStateInfo(0).IsName("ScrollHero"))
            {
                animationFinished = true;
                Noviceanimator.enabled = false;
                Ending[i].transform.GetChild(3).gameObject.SetActive(false);
                Ending[i].transform.GetChild(0).gameObject.SetActive(true);
                Ending[i].transform.GetChild(1).gameObject.SetActive(true);
                Ending[i].transform.GetChild(2).gameObject.SetActive(true);
            }
        }

    }




}

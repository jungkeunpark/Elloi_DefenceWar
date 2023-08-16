using UnityEngine;

public class LoadSceneGatchaPLAY : MonoBehaviour
{
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;
    public GameObject lobby;
    public Sprite compareto_Novice;
    public Sprite compareto_Expert;
    public Sprite compareto_Elite;
    public Sprite compareto_Master;
    public Sprite compareto_Hero;

    private void Update()
    {

        if (Novice.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Novice)
        {
            Novice.transform.GetChild(0).gameObject.SetActive(false);
            Novice.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            lobby.gameObject.SetActive(true);
        }

        if (Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Expert)
        {
            Expert.transform.GetChild(0).gameObject.SetActive(false);
            Expert.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            lobby.gameObject.SetActive(true);

        }

        if (Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Elite)
        {
            Elite.transform.GetChild(0).gameObject.SetActive(false);
            Elite.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            lobby.gameObject.SetActive(true);

        }
        if (Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Master)
        {
            Master.transform.GetChild(0).gameObject.SetActive(false);
            Master.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            lobby.gameObject.SetActive(true);
        }
        if (Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == compareto_Hero)
        {
            Hero.transform.GetChild(0).gameObject.SetActive(false);
            Hero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = default;
            lobby.gameObject.SetActive(true);
        }

    }



    public void NormalGatcha()
    {
        lobby.gameObject.SetActive(false);
        float randomValue = Random.Range(0, 100f);
        if(randomValue<51.5f)
        {
            Novice.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(randomValue>51.5f && randomValue<90f)
        {
            Expert.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(randomValue>90f && randomValue< 99.945f)
        {
            Elite.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(randomValue>99.945f && randomValue < 99.995f)
        {
            Master.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(randomValue>99.995f && randomValue < 100f)
        {
            Hero.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void PremiumGatcha()
    {
        lobby.gameObject.SetActive(false);
        float randomValue = Random.Range(0, 100f);
        if (randomValue < 42.5f)
        {
            Novice.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 42.5f && randomValue < 66.5f)
        {
            Expert.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 66.5f && randomValue < 94.0f)
        {
            Elite.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 94.0f && randomValue < 99.5f)
        {
            Master.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 99.5f && randomValue < 100f)
        {
            Hero.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    public void HeroCatcha()
    {
        lobby.gameObject.SetActive(false);
        float randomValue = Random.Range(0, 100f);
        if (randomValue < 29.45f)
        {
            Novice.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 29.45f && randomValue < 43.45f)
        {
            Expert.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 43.45f && randomValue < 74.5f)
        {
            Elite.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 74.5f && randomValue < 95f)
        {
            Master.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue > 95f && randomValue < 100f)
        {
            Hero.transform.GetChild(0).gameObject.SetActive(true);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaManager : MonoBehaviour
{
    public GameObject playGatcha;

    public void PlayGatcha()
    {
        playGatcha.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySetManager : MonoBehaviour
{
    // ��Ƽ ī�尡 ���õǾ��ִ��� ����
    public bool isPartyCardClicked = false;

    // ��� ° ��Ƽ �� ī�带 �����ߴ���?
    public int partyCardIndex = -1;

    // ������ ī�� üũ
    public int[] cardNums = new int[4] { -1, -1, -1, -1 };
}

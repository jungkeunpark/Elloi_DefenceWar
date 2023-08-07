using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartySetv2 : MonoBehaviour
{
    public PartySetManager partySetManager;

    // (왼쪽) 파티셋 카드
    public GameObject[] partySetCards;
    public int selectedCardNum;

    // (오른쪽) 플레이어 카드
    public GameObject[] playerCards;
    public GameObject temp_CharacterCard;

    // 파티셋 카드 정보
    public TextMeshProUGUI[] costs;
    public TextMeshProUGUI[] respons;

    public void Awake()
    {
        partySetManager = gameObject.AddComponent<PartySetManager>();
    }

    // { 파티셋 카드 클릭
    public void TapClick(int partySetCardNum)
    {
        // 첫 클릭인가?
        if (partySetManager.isPartyCardClicked == false && partySetManager.partyCardIndex == -1)
        {
            // 선택된 카드의 0번 자식오브젝트 활성화
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);

            // 클릭 됨 체크
            partySetManager.isPartyCardClicked = true;

            // 선택한 카드 인덱스 번호 저장
            partySetManager.partyCardIndex = partySetCardNum;
        }


        // 첫 클릭이 아니면서 다른 카드를 선택했는가?
        else if (partySetManager.isPartyCardClicked == true && partySetCardNum != partySetManager.partyCardIndex)
        {
            // 모든 카드의 0번 자식오브젝트 끄기 (클릭 이펙트)
            for (int i = 0; i < partySetCards.Length; i++)
            {
                partySetCards[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            // 선택된 카드의 0번 자식오브젝트만 활성화
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);

            // 선택한 카드 인덱스 번호 저장
            partySetManager.partyCardIndex = partySetCardNum;
        }

        // 첫 클릭이 아니면서 동일한 카드를 선택했는가?
        else if (partySetManager.isPartyCardClicked == true && partySetCardNum == partySetManager.partyCardIndex)
        {
            // 기존에 설정된 카드 정보 비활성화
            deleteInfo(partySetManager.partyCardIndex);

            // 선택된 카드의 0번 자식오브젝트 비활성화
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(false);

            // 클릭된 카드 초기화
            partySetManager.isPartyCardClicked = false;

            // 인덱스 넘버 초기화
            partySetManager.partyCardIndex = -1;

            // 파티 셋 카드에 자식 오브젝트가 없다면 리턴
            if (partySetCards[partySetCardNum].transform.childCount <= 4) { return; }

            // 파티 셋 카드에 자식 오브젝트가 있다면,
            else
            {
                // 자식 오브젝트 파괴
                Destroy(partySetCards[partySetCardNum].transform.GetChild(4).gameObject);

                // 기존 배열의 해당하는 요소를 -1로 바꿔줍니다.
                partySetManager.cardNums[partySetCardNum] = -1;
            }
        }
    }       // } 파티셋 카드 클릭

    // { 카드를 선택해서 파티셋 카드로 선택하기
    public void MyCardClick(int partySetCardNum)
    {
        // 파티셋 카드가 선택이 안되었다면 return
        if (partySetManager.isPartyCardClicked == false) { return; }

        // 파티셋 카드가 선택이 된 상태에서 플레이어 카드를 클릭했다면
        else
        {
            // 배열에 동일한 카드 번호가 있다면 (중복이 되었다면)
            for (int i = 0; i < partySetManager.cardNums.Length; i++)
            {
                if (partySetManager.cardNums[i] == partySetCardNum)
                {
                   // 기존의 카드를 지웁니다.
                   Destroy(partySetCards[i].transform.transform.GetChild(4).gameObject);

                    // 기존의 카드 정보 비활성화
                    deleteInfo(i);

                   // 기존 배열의 해당하는 요소를 -1로 바꿔줍니다.
                   partySetManager.cardNums[i] = -1;
                }
            }

            // 카드 넘버 배열에 해당 카드 번호를 넣습니다.
            partySetManager.cardNums[partySetManager.partyCardIndex] = partySetCardNum;

            // 기존에 설정된 파티 카드가 있다면
            if (partySetCards[partySetManager.partyCardIndex].transform.childCount >= 5)
            {
                // 기존에 설정된 파티셋 카드 제거
                Destroy(partySetCards[partySetManager.partyCardIndex].transform.GetChild(4).gameObject);

                // 기존에 설정된 카드 정보 비활성화
                deleteInfo(partySetManager.partyCardIndex);
            }

            // 플레이어 카드의 transform을 가져온 다음
            temp_CharacterCard = playerCards[partySetCardNum].transform.GetChild(0).gameObject;

            // 파티셋카드의 자식오브젝트로 생성
            GameObject playerCard = Instantiate(temp_CharacterCard, Vector2.zero, Quaternion.identity);
            playerCard.transform.SetParent(partySetCards[partySetManager.partyCardIndex].transform);
            
            // 위치, 크기 조절
            playerCard.transform.localScale = new Vector2(1.2f, 1.2f);
            playerCard.transform.position = partySetCards[partySetManager.partyCardIndex].transform.position;

            // 카드 정보 활성화
            partySetCards[partySetManager.partyCardIndex].transform.GetChild(1).gameObject.SetActive(true);
            partySetCards[partySetManager.partyCardIndex].transform.GetChild(2).gameObject.SetActive(true);

            // 카드 정보 수정
            costs[partySetManager.partyCardIndex].text = string.Format("{0}", GameManager.instance.MyCharacter_List[partySetCardNum].Cost);
            respons[partySetManager.partyCardIndex].text = string.Format("{0}", GameManager.instance.MyCharacter_List[partySetCardNum].ResponeCoolTime);
        }
    }   // } 카드를 선택해서 파티셋 카드로 선택하기

    // 기존에 설정된 카드 정보 비활성화
    private void deleteInfo(int index)
    {
        partySetCards[index].transform.GetChild(1).gameObject.SetActive(false);
        partySetCards[index].transform.GetChild(2).gameObject.SetActive(false);
    }
}

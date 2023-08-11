using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartySetManager : MonoBehaviour
{
    public PartySetManager partySetManager;

    // 파티 카드가 선택되어있는지 여부
    public bool isPartyCardClicked = false;

    // 몇번 째 파티 셋 카드를 선택했는지?
    public int partyCardIndex = -1;

    // 동일한 카드 체크
    public int[] cardNums = new int[4] { -1, -1, -1, -1 };

    // (왼쪽) 파티셋 카드
    public GameObject[] partySetCards;
    public int selectedCardNum;

    // (오른쪽) 플레이어 카드
    public GameObject[] playerCards;
    public GameObject temp_CharacterCard;

    // 파티셋 카드 정보
    public TextMeshProUGUI[] costs;
    public TextMeshProUGUI[] respons;

    private void Awake()
    {
        partySetManager = GetComponent<PartySetManager>();
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

            // 삭제된 플레이어 카드 이동
            DeletedCardMove(partySetCardNum);

            // 인덱스 넘버 초기화
            partySetManager.partyCardIndex = -1;

            // 파티 셋 카드에 자식 오브젝트가 없다면 리턴
            if (partySetCards[partySetCardNum].transform.childCount <= 4) { return; }

            // 파티 셋 카드에 자식 오브젝트가 있다면,
            else
            {
                // 플레이어 카드의 이펙트 끄기
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.GetChild(0).gameObject.SetActive(false);
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.GetChild(1).gameObject.SetActive(false);

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
        // 파티셋 카드가 선택이 안되었거나 동일한 캐릭터 카드를 클릭했다면
        if (partySetManager.isPartyCardClicked == false || partySetManager.cardNums[partySetManager.partyCardIndex] == partySetCardNum) { return; }

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

            // 기존에 설정된 파티 카드가 있다면
            if (partySetCards[partySetManager.partyCardIndex].transform.childCount >= 5)
            {
                // 기존에 설정된 파티셋 카드 제거
                Destroy(partySetCards[partySetManager.partyCardIndex].transform.GetChild(4).gameObject);

                // 기존에 설정된 카드 정보 비활성화
                deleteInfo(partySetManager.partyCardIndex);

                // 기존에 설정된 카드 이펙트 비활성화
                playerCards[partySetManager.cardNums[partySetManager.partyCardIndex]].transform.GetChild(0).gameObject.SetActive(false);
                playerCards[partySetManager.cardNums[partySetManager.partyCardIndex]].transform.GetChild(1).gameObject.SetActive(false);
            }

            // 카드 넘버 배열에 해당 카드 번호를 넣습니다.
            partySetManager.cardNums[partySetManager.partyCardIndex] = partySetCardNum;

            // 카드 이동
            MoveCard(partySetCardNum);

            // 카드 이펙트 활성화
            playerCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);
            playerCards[partySetCardNum].transform.GetChild(1).gameObject.SetActive(true);

            // 플레이어 카드의 transform을 가져온 다음
            temp_CharacterCard = playerCards[partySetCardNum].transform.GetChild(1).gameObject;

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

    // 카드 이동
    private void MoveCard(int partySetCardNum)
    {
        // { 선택된 카드를 파티셋 번호로 자식오브젝트 인덱스 번호를 변경합니다.

        // ( 조건.1 ) 0번 x, 1번 x, 2번 x, 3번 x
        // ㄴ> 0번으로 이동
        if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            playerCards[partySetCardNum].transform.SetSiblingIndex(0);
        }

        // ( 조건. 2 ) 0번 x, 1번 o, 2번 x, 3번 x
        // ( 조건. 2 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번 ==> 0번으로 이동
        // ( 조건. 2 - 2 ) 플레이어가 선택한 파티 번호 2번, 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 3 ) 0번 x, 1번 x, 2번 O, 3번 x 
        // ( 조건. 3 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번, 2번 ==> 0번으로 이동
        // ( 조건. 3 - 2 ) 플레이어가 선택한 파티 번호 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 4 ) 0번 x, 1번 x, 2번 x, 3번 O
        // ㄴ> 0번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            playerCards[partySetCardNum].transform.SetSiblingIndex(0);
        }

        // ( 조건. 5 ) 0번 x, 1번 O, 2번 O, 3번 x
        // ( 조건. 5 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번 ==> 0번으로 이동
        // ( 조건. 5 - 2 ) 플레이어가 선택한 파티 번호 2번 ==> 1번으로 이동
        // ( 조건. 5 - 3 ) 플레이어가 선택한 파티 번호 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 6 ) 0번 x, 1번 x, 2번 O, 3번 O
        // ( 조건. 6 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번, 2번 ==> 0번으로 이동
        // ( 조건. 6 - 2 ) 플레이어가 선택한 파티 번호 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 7 ) 0번 x, 1번 O, 2번 x, 3번 O
        // ( 조건. 7 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번 ==> 0번으로 이동
        // ( 조건. 7 - 2 ) 플레이어가 선택한 파티 번호 2번, 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 8 ) 0번 x, 1번 o, 2번 o, 3번 o
        // ( 조건. 8 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번 ==> 0번으로 이동
        // ( 조건. 8 - 2 ) 플레이어가 선택한 파티 번호 2번 ==> 1번으로 이동
        // ( 조건. 8 - 3 ) 플레이어가 선택한 파티 번호 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 9 ) 0번 o, 1번 x, 2번 x, 3번 x
        // ( 조건. 9 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 9 - 2 ) 플레이어가 선택한 파티 번호 1번, 2번, 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }
        // ( 조건. 10 ) 0번 o, 1번 o, 2번 x, 3번 x
        // ( 조건. 10 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 10 - 2 ) 플레이어가 선택한 파티 번호 1번 ==> 1번으로 이동
        // ( 조건. 10 - 3 ) 플레이어가 선택한 파티 번호 2번, 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 11 ) 0번 o, 1번 o, 2번 o, 3번 x
        // ( 조건. 11 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 11 - 2 ) 플레이어가 선택한 파티 번호 1번 ==> 1번으로 이동
        // ( 조건. 11 - 3 ) 플레이어가 선택한 파티 번호 2번, 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }


        // ( 조건. 12 ) 0번 o, 1번 o, 2번 x, 3번 o
        // ( 조건. 12 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 12 - 2 ) 플레이어가 선택한 파티 번호 1번 ==> 1번으로 이동
        // ( 조건. 12 - 3 ) 플레이어가 선택한 파티 번호 2번, 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 13 ) 0번 o, 1번 x, 2번 o, 3번 x
        // ( 조건. 13 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 13 - 2 ) 플레이어가 선택한 파티 번호 1번, 2번 ==> 1번으로 이동
        // ( 조건. 13 - 3 ) 플레이어가 선택한 파티 번호 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 14 ) 0번 o, 1번 x, 2번 o, 3번 o
        // ( 조건. 14 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 14 - 2 ) 플레이어가 선택한 파티 번호 1번, 2번 ==> 1번으로 이동
        // ( 조건. 14 - 3 ) 플레이어가 선택한 파티 번호 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 15 ) 0번 o, 1번 x, 2번 x, 3번 o
        // ( 조건. 15 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 15 - 2 ) 플레이어가 선택한 파티 번호 1번, 2번, 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 16 ) 0번 o, 1번 o, 2번 o, 3번 o
        // ( 조건. 16 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        // ( 조건. 16 - 2 ) 플레이어가 선택한 파티 번호 1번 ==> 1번으로 이동
        // ( 조건. 16 - 3 ) 플레이어가 선택한 파티 번호 2번 ==> 2번으로 이동
        // ( 조건. 16 - 4 ) 플레이어가 선택한 파티 번호 3번 ==> 3번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(3);
            }
        }
        // } 선택된 카드를 파티셋 번호로 자식오브젝트 인덱스 번호를 변경합니다.
    }

    // 파티셋에서 지워진 카드를 이동시킵니다.
    private void DeletedCardMove(int partySetCardNum)
    {
        // ( 조건. 1 ) 0번 x, 1번 O, 2번 O, 3번 x
        // ( 조건. 1 - 1 ) 플레이어가 선택한 파티 번호 1번,2번 ==> 1번으로 이동
        if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 1 || partySetCardNum == 2)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 2 ) 0번 x, 1번 x, 2번 O, 3번 O
        // ( 조건. 2 - 1 ) 플레이어가 선택한 파티 번호 2번, 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 3 ) 0번 x, 1번 O, 2번 x, 3번 O
        // ( 조건. 3 - 1 ) 플레이어가 선택한 파티 번호 1번, 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 1 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 4 ) 0번 x, 1번 o, 2번 o, 3번 o
        // ( 조건. 4 - 1 ) 플레이어가 선택한 파티 번호 1번, 2번, 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 1 || partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 5 ) 0번 o, 1번 x, 2번 x, 3번 x
        // ( 조건. 5 - 1 ) 플레이어가 선택한 파티 번호 0번 ==> 0번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(0);
            }
        }
        // ( 조건. 6 ) 0번 o, 1번 o, 2번 x, 3번 x
        // ( 조건. 6 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 7 ) 0번 o, 1번 o, 2번 o, 3번 x
        // ( 조건. 7 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번, 2번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1 || partySetCardNum == 2)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 8 ) 0번 o, 1번 o, 2번 x, 3번 o
        // ( 조건. 8 - 1 ) 플레이어가 선택한 파티 번호 0번, 1번, 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 9 ) 0번 o, 1번 x, 2번 o, 3번 x
        // ( 조건. 9 - 1 ) 플레이어가 선택한 파티 번호 0번, 2번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 2)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 10 ) 0번 o, 1번 x, 2번 o, 3번 o
        // ( 조건. 10 - 1 ) 플레이어가 선택한 파티 번호 0번, 2번, 3번 ==> 2번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( 조건. 11 ) 0번 o, 1번 x, 2번 x, 3번 o
        // ( 조건. 11 - 1 ) 플레이어가 선택한 파티 번호 0번, 3번 ==> 1번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( 조건. 12 ) 0번 o, 1번 o, 2번 o, 3번 o
        // ( 조건. 12 - 1 ) 플레이어가 선택한 파티 번호 0번,1번,2번,3번 ==> 3번으로 이동
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1 || partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(3);
            }
        }
        // } 선택된 카드를 파티셋 번호로 자식오브젝트 인덱스 번호를 변경합니다.
    }
}

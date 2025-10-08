using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TutorialGuide : MonoBehaviour
{
    [SerializeField] private CameraCon cameraCon;

    private Queue<string> dialogues;
    private StringBuilder sb;
    private bool isCamMoved = false;
    void Awake()
    {
        sb = new StringBuilder();
        dialogues = new Queue<string>();

        dialogues.Enqueue("<color=#0000FF>환상의 섬</color>에 오신 것을 환영합니다!");
        dialogues.Enqueue("<color=yellow>W, A, S, D</color> 키를 눌러 자유롭게 이동해보세요.");
        dialogues.Enqueue("마우스 휠을 돌려 화면을 <color=yellow>확대/축소</color> 할 수 있습니다.");
        dialogues.Enqueue("이제 당신만의 멋진 숙소를 만들어보세요!");

        StartCoroutine(StartTutorialSequence());
    }
    private IEnumerator StartTutorialSequence()
    {
        // 모든 Start() 함수가 실행되고 첫 프레임 렌더링이 끝날 때까지 기다립니다.
        yield return new WaitForEndOfFrame();

        // 이제 안전하게 게임 시간을 멈춥니다.
        Time.timeScale = 0f;

        // 첫 번째 튜토리얼 메시지를 표시합니다.
        ShowNextMessage();
    }

    /*void ShowMoveGuide()
    {
        sb.Clear();
        sb.Append("<color=#0000FF>환상의 섬</color>에 오신 것을 환영합니다!");// \n<color=yellow>W, A, S, D</color> 키를 눌러 자유롭게 이동해보세요.");
        //string message = " <color=#0000FF>환상의 섬</color>에 오신 것을 환영합니다! \n<color=yellow>W, A, S, D</color> 키를 눌러 자유롭게 이동해보세요.";

        // TutorialUIManager를 호출하여 메시지를 표시합니다.
        TutorialUIManager.Instance.ShowTutorialMessage(sb.ToString());
    }*/

    // 예시: 특정 키를 누르면 튜토리얼 숨기기
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !TutorialUIManager.Instance.IsTyping) // Enter 키
        {
            ShowNextMessage();

            if (!isCamMoved)
            {
                cameraCon.StartingMoveCamera();
                isCamMoved = true;
            }
        }
    }

    /// <summary>
    /// Queue에서 다음 대사를 꺼내 튜토리얼 UI 매니저에 표시를 요청합니다.
    /// </summary>
    void ShowNextMessage()
    {
        // 보여줄 대사가 남아있으면
        if (dialogues.Count > 0)
        {
            // Queue에서 가장 앞에 있는 대사를 꺼내옴 (Dequeue)
            string message = dialogues.Dequeue();
            TutorialUIManager.Instance.ShowTutorialMessage(message);
        }
        else // 더 이상 보여줄 대사가 없으면
        {
            // 튜토리얼을 종료합니다.
            EndTutorial();
        }
    }

    /// <summary>
    /// 튜토리얼을 종료하고 게임을 시작합니다.
    /// </summary>
    void EndTutorial()
    {
        TutorialUIManager.Instance.HideTutorial(); // 튜토리얼 UI 숨기기
        Time.timeScale = 1f; // 게임 시간 정상화
        
        if (cameraCon != null)
        {
            cameraCon.StartingMoveCamera(); // 카메라 이동 시작
        }

        // 이 스크립트의 역할을 다했으므로 비활성화합니다.
        this.enabled = false;
    }
}

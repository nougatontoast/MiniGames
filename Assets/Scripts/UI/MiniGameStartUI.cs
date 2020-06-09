using UnityEngine;

public class MiniGameStartUI : MonoBehaviour
{
    [SerializeField] internal MinigameHandler minigameHandler = null;
    [SerializeField] internal TextConfig goalTextConfig = null;

    [SerializeField] private GameObject goalText = null;
    [SerializeField] private GameObject countDown = null;

    [SerializeField] private Timer_CountDown timer_CountDown = null;

    private void Awake()
    {
        SetGoalText();
        minigameHandler.GameStarted += HideandDisable;
    }

    private void OnDisable()
    {
        minigameHandler.GameStarted -= HideandDisable;
    }

    private void Update()
    {
        if (timer_CountDown != null)
        {
            UpdateCountText(Mathf.RoundToInt(timer_CountDown.currentTime_GoingDown));
        }
    }

    private void SetGoalText()
    {
        goalText.GetComponent<TMPro.TextMeshProUGUI>().text = goalTextConfig.GetText();
    }
    
    internal void UpdateCountText(int countNum)
    {
        countDown.GetComponent<TMPro.TextMeshProUGUI>().text = countNum.ToString();
    }

    internal void HideandDisable()
    {
        goalText.SetActive(false);
        countDown.SetActive(false);
        gameObject.SetActive(false);
    }

}

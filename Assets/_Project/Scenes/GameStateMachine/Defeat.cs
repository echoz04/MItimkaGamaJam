using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class Defeat : State
{
    public TextMeshProUGUI RestartInterface;

    private float timeToShowRespawn = 1.5f;

    private void Start()
    {
        RestartInterface.gameObject.SetActive(false);
    }

    public override void StateEnter(Dictionary<string, object> props)
    {
        Debug.Log("Player defeated!");
        RestartInterface.gameObject.SetActive(true);
        RestartInterface.SetText("Press any key to restart");

        MaxScoreDisplayer.Instance.SetMaxScore(ScoreCounter.Instance.GetScore());
        MaxScoreDisplayer.Instance.Display();

        timeToShowRespawn = 1.5f;
    }

    public override void StateUpdate()
    {
        base.StateUpdate();

        timeToShowRespawn -= Time.deltaTime;
        if (timeToShowRespawn > 0)
        {
            RestartInterface.alpha = 0.0f;
            return;
        }

        RestartInterface.gameObject.SetActive(true);
        RestartInterface.alpha = Mathf.Lerp(RestartInterface.alpha, 1.0f, Time.deltaTime * 2.0f);
        
        if (Input.anyKeyDown)//(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // RestartInterface.gameObject.SetActive(false);
            // ChangeState(stateMachine.States["Waves"], StateMachine.empty_dict);
            SceneManager.LoadScene(SceneManager.GetActiveScene().path);
        }
    }
}

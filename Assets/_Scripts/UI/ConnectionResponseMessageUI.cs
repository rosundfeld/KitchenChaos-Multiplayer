using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class ConnectionResponseMessageUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        GameManagerMultiplayer.Instance.FailedToJoinGame += GameManagerMultiplayer_FailedToJoinGame;

        Hide();
    }

    private void OnDestroy()
    {
        GameManagerMultiplayer.Instance.FailedToJoinGame -= GameManagerMultiplayer_FailedToJoinGame;
    }

    private void GameManagerMultiplayer_FailedToJoinGame(object sender, System.EventArgs e)
    {
        Show();

        messageText.text = NetworkManager.Singleton.DisconnectReason;

        if(messageText.text == "")
        {
            messageText.text = "Failed to join the game.";
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

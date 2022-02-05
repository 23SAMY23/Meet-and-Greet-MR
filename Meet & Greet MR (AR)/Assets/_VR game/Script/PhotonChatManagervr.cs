using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VRKeys;

public class PhotonChatManagervr : MonoBehaviour, IChatClientListener
{

/*This Script Use to control how vr chatbox will look and what function will be done*/

	public GameObject messagesContainer;
	public ChatClient chatClient;
	public Text connectionStateText;
	public Text messagesText;
	public TMP_InputField messageText;
	public GameObject VRKEYS;
	string worldChat;

	void Start()
	{
		Application.runInBackground = true;
		chatClient = new ChatClient(this);
		chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));

		Connect();

	}

	void Update()
	{
		if (chatClient != null)
		{
			chatClient.Service();
			connectionStateText.text = chatClient.State.ToString();
		}
		else
		{
			connectionStateText.text = "Offline";
		}


	}
	//This function is to send message on enter
	public void HandleMessageSubmit()
	{

		if (messageText.text != "")
		{
			chatClient.PublishMessage(worldChat, messageText.text);
			messageText.text = "";
			VRKEYS.gameObject.GetComponent<Keyboard>().text = "";

			StartCoroutine(CoFocusAgain());
		}
	}

	IEnumerator CoFocusAgain()
	{
		yield return new WaitForSeconds(.1f);

		messageText.Select();
		messageText.ActivateInputField();
	}

	void HandleLoginFormUI()
	{
		//transform.Find("LoginForm/ConnectButton").GetComponent<Button>().onClick.AddListener(Connect);
	}

	void HandleChatFormUI()
	{
		//transform.Find("ChatForm/ExitButton").GetComponent<Button>().onClick.AddListener(() => {
			//chatClient.Disconnect();
		//});
	}

	void Connect()
	{
		if (string.IsNullOrEmpty(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat))
		{
			print("No ChatAppID provided");
			return;
		}

		worldChat = "WORLD_CHAT";

		
	}

	public void OnConnected()
	{
		//loginForm.SetActive(false);
	//	chatForm.SetActive(true);

		messagesText.text = "";

		chatClient.Subscribe(new string[] { worldChat });
		chatClient.SetOnlineStatus(ChatUserStatus.Online);
	}

	public void OnDisconnected()
	{
		//loginForm.SetActive(true);
	//	chatForm.SetActive(false);
	}

	public void OnGetMessages(string channelName, string[] senders, object[] messages)
	{
		for (int i = 0; i < senders.Length; i++)
		{
			messagesText.text = messagesText.text + "\n"
								+ senders[i] + ": "
								+ messages[i];
		}

		// Scroll to bottom
		StartCoroutine(CoScrollToBottom());
	}

	IEnumerator CoScrollToBottom()
	{
		yield return new WaitForSeconds(.1f);
		messagesContainer.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 0);
	}

	public void OnPrivateMessage(string sender, object message, string channelName) { }

	public void OnSubscribed(string[] channels, bool[] results)
	{
		messagesText.text += "Chat Online.";
		chatClient.PublishMessage(worldChat, "Joined");
	}

	public void OnUnsubscribed(string[] channels) { }

	public void OnStatusUpdate(string user, int status, bool gotMessage, object message) { }

	public void OnChatStateChange(ChatState state) { }

	public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message) { }

	void OnApplicationQuit()
	{
		if (chatClient != null)
		{
			chatClient.Disconnect();
		}
	}

	public void OnUserSubscribed(string channel, string user)
	{
		throw new System.NotImplementedException();
	}

	public void OnUserUnsubscribed(string channel, string user)
	{
		throw new System.NotImplementedException();
	}
}


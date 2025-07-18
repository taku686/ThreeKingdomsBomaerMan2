#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using Common.Data;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ChatGPTManager : IDisposable
{
    //会話履歴を保持するリスト
    private readonly List<ChatGPTMessageModel> _messageList = new();


    public void SetupCharacter(string name, string character)
    {
        _messageList.Clear();
        //todo 仮の値
        _messageList.Add(new ChatGPTMessageModel { role = "system", content = $"あなたは{name}です。性格は高潔な武人です。できるだけ簡潔に要点をまとめて答えてください。" });
    }

    public async UniTask Request(string question, TextMeshProUGUI commentText)
    {
        var response = await RequestAsync("{{" + question + "}}");
        foreach (var choice in response.choices)
        {
            Debug.Log("ChatGPT:" + choice.message.content);
            Debug.Log(response.usage.total_tokens);
            commentText.text = choice.message.content;
        }
//好きな魚料理を1つ教えて など
    }

    private async UniTask<ChatGPTResponseModel> RequestAsync(string userMessage)
    {
        //文章生成AIのAPIのエンドポイントを設定
        var apiUrl = "https://api.openai.com/v1/chat/completions";

        _messageList.Add(new ChatGPTMessageModel { role = "user", content = userMessage, });

        //OpenAIのAPIリクエストに必要なヘッダー情報を設定
        var headers = new Dictionary<string, string>
        {
            /*{ "Authorization", "Bearer " + GameCommonData.ChatGptApiKey },
            { "Content-type", "application/json" },
            { "X-Slack-No-Retry", "1" }*/
        };

        //文章生成で利用するモデルやトークン上限、プロンプトをオプションに設定
        var options = new ChatGPTCompletionRequestModel()
        {
            model = "gpt-3.5-turbo",
            messages = _messageList,
            n = 1,
            temperature = 0.2f,
            max_tokens = 300,
        };
        var jsonOptions = JsonUtility.ToJson(options);

        Debug.Log("自分:" + userMessage);

        //OpenAIの文章生成(Completion)にAPIリクエストを送り、結果を変数に格納
        using var request = new UnityWebRequest(apiUrl, "POST")
        {
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonOptions)),
            downloadHandler = new DownloadHandlerBuffer()
        };

        foreach (var header in headers)
        {
            request.SetRequestHeader(header.Key, header.Value);
        }

        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            throw new Exception();
        }
        else
        {
            var responseString = request.downloadHandler.text;
            var responseObject = JsonUtility.FromJson<ChatGPTResponseModel>(responseString);
            foreach (var choice in responseObject.choices)
            {
                Debug.Log("ChatGPT:" + choice.message.content);
                Debug.Log(responseObject.usage.total_tokens);
                _messageList.Add(choice.message);
            }

            return responseObject;
        }
    }

    public void Dispose()
    {
    }
}

[Serializable]
public class ChatGPTMessageModel
{
    public string role;
    public string content;
}

//ChatGPT APIにRequestを送るためのJSON用クラス
[Serializable]
public class ChatGPTCompletionRequestModel
{
    public string model;
    public List<ChatGPTMessageModel> messages;
    public int n;
    public int max_tokens;
    public float temperature;
}

//ChatGPT APIからのResponseを受け取るためのクラス
[System.Serializable]
public class ChatGPTResponseModel
{
    public string id;
    public string @object;
    public int created;
    public Choice[] choices;
    public Usage usage;

    [System.Serializable]
    public class Choice
    {
        public int index;
        public ChatGPTMessageModel message;
        public string finish_reason;
    }

    [System.Serializable]
    public class Usage
    {
        public int prompt_tokens;
        public int completion_tokens;
        public int total_tokens;
    }
}
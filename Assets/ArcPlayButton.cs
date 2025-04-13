using System;
using Arcplay;
using TMPro;
using UnityEngine;
using GoogleMobileAds.Api;

public class ArcPlayButton : MonoBehaviour
{
    struct ArcplayConfig
    {
        public string accountId;
        public string userId;
    }

    public TMP_Text OutputText;

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // AppLovin SDK is initialized, start loading ads
        };

        TextAsset file = Resources.Load<TextAsset>("AppLovinKey");
        MaxSdk.SetSdkKey(file.text);

        MaxSdk.InitializeSdk();
    }

    public void GetSDKVersion()
    {
        try
        {
            OutputText.text = ArcplayPlugin.GetSDKVersion();
        }
        catch (Exception ex)
        {
            OutputText.text = ex.Message;
            throw ex;
        }
    }

    public void Init()
    {
        TextAsset file = Resources.Load<TextAsset>("ArcplayConfig");
        ArcplayConfig jsonConfig = JsonUtility.FromJson<ArcplayConfig>(file.text);

        InitConfig config = new InitConfig(
            accountId: jsonConfig.accountId,
            userId: jsonConfig.userId
        );

        ArcplayPlugin.Init(config, new ArcplayInitListener(
                onSuccess: () =>
                {
                    OutputText.text = "Success";
                    Debug.Log("Success");
                },
                onFailure: (int code, string message) =>
                {
                    OutputText.text = $"Error {code}: {message}";
                    Debug.LogError($"Error {code}: {message}");
                }
            )
        );
    }

    public void Launch()
    {
        if (ArcplayPlugin.Launch())
        {
            OutputText.text = "Success";
        }
        else
        {
            OutputText.text = "Failed";
        }
    }
}
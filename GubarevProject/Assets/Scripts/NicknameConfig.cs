using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using UnityEngine.UI;

public class NicknameConfig : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public string newNickname = "Stitless";
    public InputField nicknameInputField;
 
    void Awake()
    {
        ConfigManager.FetchCompleted += SetNewNickname;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void SetNewNickname(ConfigResponse response)
    {
        newNickname = ConfigManager.appConfig.GetString("default_nickname");
        nicknameInputField.text = newNickname;
    }
}

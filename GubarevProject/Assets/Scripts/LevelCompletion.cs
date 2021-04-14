using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] PlayerData playerData = new PlayerData(); 
    private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.CompareTag("Player")) 
		{   
            //save game         
            SaveGameToJson(other);
            SaveGameWithPlayerPrefs(other);
            SaveGameWithPlayerPrefs(other);
			SceneManager.LoadScene("MainMenu"); //exit to menu
		}        
	}

    public void SaveGameToJson(Collider2D other)
    {
        playerData.playerName = other.name;
        playerData.playerTag = other.tag;
        playerData.playerCoins = other.GetComponent<PlayerResources>().coinsCounter;
        string playerSaveJsonData = JsonUtility.ToJson(playerData);
        
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", playerSaveJsonData);
        Debug.Log(Application.persistentDataPath);
    }

    public void SaveGameWithPlayerPrefs(Collider2D other)
    {
        PlayerPrefs.SetString("Player Name", other.name);
		PlayerPrefs.SetString("Player Tag", other.tag);	
        PlayerPrefs.SetInt("Total coins", other.GetComponent<PlayerResources>().coinsCounter);	
		PlayerPrefs.Save();
    }

    public void SaveWithPersistentData(Collider2D other)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file;

        playerData.playerName = other.name;
		playerData.playerTag = other.tag;
        playerData.playerCoins = other.GetComponent<PlayerResources>().coinsCounter;

		if(File.Exists(Application.persistentDataPath + "/playerData.dat"))
		{
			file = File.OpenWrite(Application.persistentDataPath + "/playerData.dat");			
		}    	
		else
		{
			file = File.Create(Application.persistentDataPath + "/playerData.dat");
		}			

		binaryFormatter.Serialize(file, playerData);
    	file.Close();
    }

    [Serializable]
	class PlayerData
	{
		public string playerName;
		public string playerTag;
        public int playerCoins;
	}
}
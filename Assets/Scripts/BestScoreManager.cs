using System.IO;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager instance;

    public string playerName;
    public string recordBreakerName;
    public int recordPoints;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string recordBreakerName;
        public int recordPoints;
    }

    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.recordBreakerName = recordBreakerName;
        data.recordPoints = recordPoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = (Application.persistentDataPath + "/savefile.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            recordBreakerName = data.recordBreakerName;
            recordPoints = data.recordPoints;
        }
    }
}

using System.IO;
using UnityEngine;

namespace Json
{
    public class ExampleA
    {
        public ExampleA()
        {
            var data = File.ReadAllText(Application.dataPath + "/Resources/Json/JsonA.json");
            var json = JsonUtility.FromJson<JExampleOne>(data);

            foreach (var child in json.Data)
            {
                Debug.Log(child.life);
                Debug.Log(child.name);
                Debug.Log(child.energy);
            }
            //Debug.Log(String.Join(", ", child.ToList()) );
        }
    }
    
    // можно и нужно вынести в отдельный файл
    [System.Serializable]
    public class JExampleOne
    {
        public JExampleOneArray[] Data = null;
    }

    [System.Serializable]
    public class JExampleOneArray
    {
        public string life;
        public string name;
        public int energy;
    }
}
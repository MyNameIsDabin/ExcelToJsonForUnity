using System;
using UnityEngine;

namespace LocalDB
{
    // Local DB 데이터 클래스를 정의합니다 (Excel 데이터 형식과 동일해야 합니다)

    [Serializable]
    public class DataCharacter : Data<DataCharacter>
    {
        public int id;
        public string name;
        public int grade;
    }

    [Serializable]
    public class DataMiniGame : Data<DataMiniGame>
    {
        public int id;
        public string name;
        public string scene;
    }

    [Serializable]
    public class Data<T>
    {
        public virtual void FromJsonOverwrite(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public virtual string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
}

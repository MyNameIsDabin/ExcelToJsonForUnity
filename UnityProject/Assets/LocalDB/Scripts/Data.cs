using System;
using UnityEngine;

namespace LocalDB
{
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

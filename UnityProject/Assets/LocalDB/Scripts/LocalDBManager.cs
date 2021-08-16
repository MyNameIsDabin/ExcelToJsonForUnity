using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace LocalDB
{
    public class LocalDBManager : Singleton<LocalDBManager>
    {
        public enum DBName
        {
            None,
            Characters,
        }

        private const string LOCAL_DB_PATH = "LocalDB";

        private Dictionary<DBName, IList> db = new Dictionary<DBName, IList>();
        private Dictionary<Type, DBName> dbNamesByType = new Dictionary<Type, DBName>();

        public void InitLocalDB()
        {
            SetDataBaseFromJSON<DataCharacter>(DBName.Characters, "characters");

            var list = GetDataList<DataCharacter>();
            list.ForEach(a => Debug.Log(a.ToJson()));
        }

        public List<T> GetDataList<T>(DBName dbName = DBName.None)
        {
            if (dbName == DBName.None)
                dbName = dbNamesByType[typeof(T)];

            return db[dbName] as List<T>;
        }

        public T GetDataById<T>(int id, DBName dbName = DBName.None)
        {
            if (dbName == DBName.None)
                dbName = dbNamesByType[typeof(T)];

            return (T)db[dbName][id];
        }

        public List<T> LoadArrayDataFromJson<T>(string filename)
        {
            var path = Path.Combine(LOCAL_DB_PATH, filename);
            var jsonFile = Resources.Load(path) as TextAsset;
            var json = jsonFile.text;
            return JsonUtility.FromJson<DataList<T>>("{ \"dataList\": " + json + "}").ToList();
        }

        public void SetDataBaseFromJSON<T>(DBName dbName, string filename)
        {
            var dataList = LoadArrayDataFromJson<T>(filename);
            dbNamesByType.Add(typeof(T), dbName);
            db.Add(dbName, dataList);
        }
    }
}
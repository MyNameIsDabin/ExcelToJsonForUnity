using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace LocalDB
{
    [Serializable]
    public class DataList<T>
    {
        [SerializeField]
        public List<T> dataList;

        public T GetElement(int index)
        {
            return dataList[index];
        }

        public DataList(List<T> dataList)
        {
            this.dataList = dataList;
        }

        public List<T> ToList()
        {
            return dataList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Json
{
    public class ExampleB
    {
        public ExampleB()
        {
            var data = CreateList();
            string text = JsonHelper.ToJson(data.ToArray(), true);
            
            Debug.Log(text);
            FromJson(text);
        }

        private void FromJson(string data)
        {
            var json = JsonHelper.FromJson<ExampleBClass>(data);

            foreach (var child in json)
            {
                string numbers = String.Join(", ", child.Numbers.ToList());
                Debug.Log($"Number={numbers}; Title={child.Title}");
            }
        }
    
        private List<ExampleBClass> CreateList()
        {
            int[] numbers = { 1,2,3 };
            
            List<ExampleBClass> data = new List<ExampleBClass>();
            data.Add(new ExampleBClass(numbers, "one"));
            data.Add(new ExampleBClass(numbers, "two"));
            data.Add(new ExampleBClass(numbers, "three"));
            return data;
        }
    }
    
    // можно и нужно вынести в отдельный файл
    [System.Serializable]
    public class ExampleBClass
    {
        public int[] Numbers;
        public string Title;
        public ExampleBClass(int[] numbers, string title)
        {
            Numbers = numbers;
            Title = title;
        }
    }
}
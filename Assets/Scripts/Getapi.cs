using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System;
using static JsonReader;

public class Getapi : MonoBehaviour
{
    [System.Serializable]
    public class Image
    {
        public int id;
        public string image;
        public int product_id;
        public DateTime created_at;
        public DateTime updated_at;
    }
    [System.Serializable]
    public class Product
    {
        public int id;
        public string name;
        public string description;
        public int price;
        public int coin_type;
        public DateTime created_at;
        public DateTime updated_at;
        public string quantity;
        public List<Image> images;
    }

    public Root root = new Root();

    [System.Serializable]
    public class Root
    {
        public bool success;
        public List<Product> product;
    }
    public string Outputjson;
    IEnumerator GetData_Coroutine()
    {
        
        string uri = "http://www.bullsontheta.io/backend/api/product";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("fail" + request.responseCode + "..>" + request.downloadHandler.text);
            }
            else
            { 
                Outputjson = request.downloadHandler.text;
                Debug.LogError("success " + Outputjson);
                root = JsonUtility.FromJson<Root>(Outputjson);
                
            }
        }
    }
   
    void Start()
    {
        IEnumerator IEnumerator = GetData_Coroutine();
        StartCoroutine(IEnumerator);        
    }
}

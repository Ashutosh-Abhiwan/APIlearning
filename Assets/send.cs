using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.XR;
using System.Net;
using System.Text;


public class send : MonoBehaviour
{
    public class Image
    {
        public int id;
        public string image;
        public int product_id;
        public DateTime created_at;
        public DateTime updated_at;
    }

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

    public Image  image = new Image();   
    public List<Product> products = new List<Product>();
    public string json;
    [System.Serializable]
    public class webRequest
    {
        public string address;
        public static object Post(string json, string fgh)
        {
            return json;
        }
    }
    public webRequest uchiha = new webRequest();

    public string Recivedata { get; private set; }

 
    public void Start()
    {
        // OutputJSON();
        StartCoroutine(PostAddress());
    }

    IEnumerator PostAddress()
    {
        string uri = "http://www.bullsontheta.io/backend/api/product";

        UnityWebRequest request = UnityWebRequest.Post(uri, UnityWebRequest.kHttpVerbPOST);
        json = JsonUtility.ToJson(uchiha);
        Debug.Log("..>" + json);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
        UploadHandler uh = new UploadHandlerRaw(bytes);
        uh.contentType = "application/json";
        request.uploadHandler = uh;
  
        yield return request.SendWebRequest();
      
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            //Parsing phase
            string json = request.downloadHandler.text;
            image = JsonUtility.FromJson<Image>(json);
        }
    }

}

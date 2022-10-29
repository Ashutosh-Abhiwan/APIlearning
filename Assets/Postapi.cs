using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Postapi : MonoBehaviour
{
    IEnumerator GetData_Coroutine()
    {

        string uri = "http://www.bullsontheta.io/backend/api/product";
        WWWForm form=new WWWForm();
        form.AddField("address", "0xE40C721e0eB2C3bdff6A9A0f33dE880bDBaE1BAa");

        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
      
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("fail" + request.responseCode + "..>" + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("success " + request.downloadHandler.text);
            }
        }
    }
    void Start()
    {
        //IEnumerator IEnumerator = GetData_Coroutine();
        //StartCoroutine(IEnumerator);
    }
}

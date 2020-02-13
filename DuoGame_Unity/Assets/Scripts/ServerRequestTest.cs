using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerRequestTest : MonoBehaviour {
    private int counter;

    void Update() {
        if(Input.GetKeyDown( KeyCode.Space )) {
            StartCoroutine( GetFruitAsync() );
            counter++;
        }
    }

    private IEnumerator GetFruitAsync() {
        WWWForm form = new WWWForm();
        form.AddField( "counter" , counter );
        UnityWebRequest www = UnityWebRequest.Post( "http://127.0.0.1/edsa-Database/example.php" , form );
        yield return www.SendWebRequest();
        Debug.Log( www.downloadHandler.text );
    }
}

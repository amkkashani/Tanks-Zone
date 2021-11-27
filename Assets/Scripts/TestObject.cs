using System.Collections;
using System.Collections.Generic;
using NativeWebSocket;
using UnityEngine;

public class TestObject : MonoBehaviour {
  WebSocket websocket;

  
  // Start is called before the first frame update
  async void Start()
  {
    websocket = new WebSocket("ws://localhost:8080/echo");

    websocket.OnOpen += () =>
    {
      Debug.Log("Connection open!");
    };

    websocket.OnError += (e) =>
    {
      Debug.Log("Error! " + e);
    };

    websocket.OnClose += (e) =>
    {
      Debug.Log("Connection closed!");
    };



    websocket.OnMessage += (bytes) =>
    {
      Debug.Log("OnMessage!");
      Debug.Log(System.Text.Encoding.Default.GetString(bytes));

      // getting the message as a string
      // var message = System.Text.Encoding.UTF8.GetString(bytes);
      // Debug.Log("OnMessage! " + message);
    };

    // Keep sending messages at every 0.3s
    InvokeRepeating("SendWebSocketMessage", 0.0f, 4f);

    // waiting for messages
    await websocket.Connect();
  }

  void Update()
  {
#if !UNITY_WEBGL || UNITY_EDITOR
    websocket.DispatchMessageQueue();
#endif
  }

  async void SendWebSocketMessage()
  {
    if (websocket.State == WebSocketState.Open)
    {
      // Sending bytes
      await websocket.SendText("aghha baz kon in daro");

      // Sending plain text
      await websocket.SendText("plain text message");
    }
  }

  private async void OnApplicationQuit()
  {
    await websocket.Close();
  }
  //   Application.targetFrameRate = 60;
  //
  //   socket = GetComponent<SocketIOController>();
  //   gameMenu = GetComponent<GameMenu>();
  //
  //   //to switch quickly between local and online you can override the settings here
  //   if (GLITCH)
  //   {
  //     socket.settings.url = "yourglitchdomain.glitch.me";
  //     socket.settings.port = 0 ;
  //     socket.settings.sslEnabled = true;
  //   }
  //   else if (HEROKU)
  //   {
  //     socket.settings.url = "yourherokudomain.herokuapp.com";
  //     socket.settings.port = 5000;
  //     socket.settings.sslEnabled = true;
  //   }
  //
  //   //connect to the server
  //   socket.Connect();
  //   Debug.Log ("start");
  //   socket = IO.Socket ("http://localhost:9000");
  //
  //   socket.On (QSocket.EVENT_CONNECT, () => {
  //     Debug.Log ("Connected");
  //     socket.Emit ("chat", "test");
  //   });
  //
  //   socket.On ("chat", data => {
  //     Debug.Log ("data : " + data);
  //   });
  // }
  //
  // private void OnDestroy () {
  //   socket.Disconnect ();
  // }
}
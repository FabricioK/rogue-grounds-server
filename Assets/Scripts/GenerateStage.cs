using Colyseus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStage : MonoBehaviour
{
    Client client;
    Room<Dungeon> room;
    public string roomName = "room";
    Dictionary<string, float> inputsFloat = new Dictionary<string, float>();
    Dictionary<string, float> oldInputsFloat = new Dictionary<string, float>();
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
    //    client = ColyseusManager.Instance.Client;
        // Setup();

    }

    /* public async void Setup()
     {
         room = await client.Join<Dungeon>(roomName, new Dictionary<string, object>() { });
     }
     // Update is called once per frame
     void Update()
     {
         if (room != null)
         {
             movement.x = Input.GetAxisRaw("Horizontal");
             movement.y = Input.GetAxisRaw("Vertical");
             checkRawInput("Horizontal", movement.x);
             checkRawInput("Vertical", movement.y);

             if (HasDiference())
                 room.Send(new PlayerInputs
                 {
                     movement = movement
                 });
         }
     }

     public void checkRawInput(string key, float value)
     {
         if (inputsFloat.ContainsKey(key))
         {
             oldInputsFloat[key] = inputsFloat[key];
         }
         else
         {
             inputsFloat[key] = 0;
             oldInputsFloat[key] = 0;
         }
         inputsFloat[key] = value;
     }

     private bool HasDiference()
     {
         foreach (string key in inputsFloat.Keys)
         {
             if (inputsFloat[key] != oldInputsFloat[key]) return true;
         }
         return false;
     }*/
}
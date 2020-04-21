using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

using System;
using System.Collections.Generic;

using Colyseus;


using GameDevWare.Serialization;
using UnityEngine.SceneManagement;


public class ColyseusClient : MonoBehaviour
{
    private static ColyseusClient _instance;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }

    // UI Buttons are attached through Unity Inspector
    public Button
        m_ConnectButton,
        m_CreateButton,
        m_JoinOrCreateButton,
        m_JoinButton,
        m_ReconnectButton,
        m_SendMessageButton,
        m_LeaveButton,
        m_GetAvailableRoomsButton;

    public GameObject playerPrefab;
    public Camera mainCamera;
    public InputField m_EndpointField;
    public Text m_IdText, m_SessionIdText;

    public string roomName = "demo";

    public Grid grid;
    public Tilemap ground;
    public Tilemap above;

    public TileBase GROUNDTILE;

    public TileBase WALL;
    public TileBase WALL_TOP;
    public TileBase WALL_RIGHT;
    public TileBase WALL_BOTTOM;
    public TileBase WALL_LEFT;

    public TileBase WALL_TOP_RIGHT;
    public TileBase WALL_TOP_BOTTOM;
    public TileBase WALL_TOP_RIGHT_BOTTOM;
    public TileBase WALL_TOP_RIGHT_BOTTOM_LEFT;

    public TileBase WALL_RIGHT_LEFT;
    public TileBase WALL_RIGHT_BOTTOM_LEFT;
    public TileBase WALL_RIGHT_BOTTOM;

    public TileBase WALL_BOTTOM_LEFT;
    public TileBase WALL_TOP_LEFT;

    public TileBase WALL_TOP_RIGHT_LEFT;
    public TileBase WALL_TOP_BOTTOM_LEFT;

    Dictionary<string, float> inputsFloat = new Dictionary<string, float>();
    Dictionary<string, float> oldInputsFloat = new Dictionary<string, float>();
    private Vector2 movement;

    protected Client client;
    protected Room<Dungeon> room;

    protected IndexedDictionary<Player, GameObject> players = new IndexedDictionary<Player, GameObject>();

    // Use this for initialization
    void Start()
    {
        /* Demo UI */
        m_ConnectButton.onClick.AddListener(ConnectToServer);
    }

    async void ConnectToServer()
    {
        /*
		 * Get Colyseus endpoint from InputField
		 */
        string endpoint = m_EndpointField.text;

        Debug.Log("Connecting to " + endpoint);

        /*
		 * Connect into Colyeus Server
		 */
        client = ColyseusManager.Instance.CreateClient(endpoint);

        /*await client.Auth.Login();

        var friends = await client.Auth.GetFriends();

        // Update username
        client.Auth.Username = "Jake";
        await client.Auth.Save();*/

        room = await client.Join<Dungeon>(roomName, new Dictionary<string, object>() { });

        // m_SessionIdText.text = "sessionId: " + room.SessionId;

        room.State.players.OnAdd += OnEntityAdd;
        room.State.players.OnRemove += OnEntityRemove;
        room.State.players.OnChange += OnPlayerChange;

        room.State.dungeon.OnChange += OnDungeonChange;
        PlayerPrefs.SetString("roomId", room.Id);
        PlayerPrefs.SetString("sessionId", room.SessionId);
        PlayerPrefs.Save();

        room.OnLeave += (code) => Debug.Log("ROOM: ON LEAVE");
        room.OnError += (message) => Debug.LogError(message);
        room.OnStateChange += OnStateChangeHandler;
        room.OnMessage += OnMessage;

    }

    private void OnDungeonChange(List<Colyseus.Schema.DataChange> changes)
    {
        foreach (var item in room.State.dungeon.ground.Items)
        {
            int x = int.Parse(item.Value.x.ToString());
            int y = int.Parse(item.Value.y.ToString());
            ground.SetTile(new Vector3Int(x, y, 0), GROUNDTILE);
        }

        foreach (var item in room.State.dungeon.above.Items)
        {
            int x = int.Parse(item.Value.x.ToString());
            int y = int.Parse(item.Value.y.ToString());
            switch (item.Value.type)
            {
                case "WALL":
                    WALL.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL);
                    break;
                case "WALLTOP":
                    WALL_TOP.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP);
                    break;
                case "WALLRIGHT":
                    WALL_RIGHT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_RIGHT);
                    break;
                case "WALLBOTTOM":
                    WALL_BOTTOM.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_BOTTOM);
                    break;
                case "WALLLEFT":
                    WALL_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_LEFT);
                    break;
                case "WALLTOP_RIGHT":
                    WALL_TOP_RIGHT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP_RIGHT);
                    break;
                case "WALLTOP_BOTTOM":
                    WALL_TOP_BOTTOM.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP_BOTTOM);
                    break;
                case "WALLTOP_RIGHT_BOTTOM":
                    WALL_TOP_RIGHT_BOTTOM.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP_RIGHT_BOTTOM);
                    break;
                case "WALLTOP_RIGHT_BOTTOM_LEFT":
                    WALL_TOP_RIGHT_BOTTOM_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP_RIGHT_BOTTOM_LEFT);
                    break;
                case "WALLRIGHT_LEFT":
                    WALL_RIGHT_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_RIGHT_LEFT);
                    break;
                case "WALLRIGHT_BOTTOM_LEFT":
                    WALL_RIGHT_BOTTOM_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_RIGHT_BOTTOM_LEFT);
                    break;
                case "WALLRIGHT_BOTTOM":
                    WALL_RIGHT_BOTTOM.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_RIGHT_BOTTOM);
                    break;
                case "WALLBOTTOM_LEFT":
                    WALL_BOTTOM_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_BOTTOM_LEFT);
                    break;
                case "WALLTOP_LEFT":
                    WALL_TOP_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP_LEFT);
                    break;
                case "WALLTOP_RIGHT_LEFT":
                    WALL_TOP_RIGHT_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP_RIGHT_LEFT);
                    break;
                case "WALLTOP_BOTTOM_LEFT":
                    WALL_TOP_BOTTOM_LEFT.name = item.Value.type;
                    above.SetTile(new Vector3Int(x, y, 0), WALL_TOP_BOTTOM_LEFT);
                    break;
                default:
                    break;
            }

        }
        //Tilemap ground = GetComponent("Grid").GetComponent("ground") as Tilemap;
        //throw new NotImplementedException();
    }

    void OnMessage(object msg)
    {
        if (msg is Message)
        {
            var message = (Message)msg;
            Debug.Log("Received schema-encoded message:");
            Debug.Log("message.num => " + message.num + ", message.str => " + message.str);
        }
        else
        {
            // msgpack-encoded message
            var message = (IndexedDictionary<string, object>)msg;
            Debug.Log("Received msgpack-encoded message:");
            Debug.Log(message["hello"]);
        }
    }
    void OnStateChangeHandler(Dungeon state, bool isFirstState)
    {
        // Setup room first state
        //Debug.Log("State has been updated!");
    }

    void OnEntityAdd(Player entity, string key)
    {
        GameObject newPlayer = Instantiate(playerPrefab, new Vector3(entity.x, entity.y, 0), Quaternion.identity);
        entity.sessionId = key;
        if (PlayerPrefs.GetString("sessionId") == key)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().GetComponent<CameraFollow>().player = newPlayer.transform;
        }

        players.Add(entity, newPlayer);
    }

    void OnEntityRemove(Player entity, string key)
    {
        GameObject cube;
        entity.sessionId = key;
        players.TryGetValue(entity, out cube);
        Destroy(cube);
        players.Remove(entity);
    }


    void OnPlayerChange(Player entity, string key)
    {
        entity.sessionId = key;
        GameObject player;
        players.TryGetValue(entity, out player);
        Vector2 direction = new Vector2(entity.dx, entity.dy);
        Vector2 position = new Vector2(entity.x, entity.y);
        Vector2 mouse = new Vector2(entity.mousex, entity.mousey);
        player.GetComponent<PlayerMovement>().SetAnimation(direction, position, mouse, entity.mouseleft);
    }

    void OnApplicationQuit()
    {
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool mouseleft = Input.GetMouseButtonDown(0);
        if (room != null)
        {

            checkRawInput("MouseLeft", mouseleft ? 1 : 0);
            checkRawInput("MouseX", mousePosition.x);
            checkRawInput("MouseY", mousePosition.x);
            checkRawInput("Horizontal", movement.x);
            checkRawInput("Vertical", movement.y);

            if (HasDiference())
                room.Send(new CustomData()
                {
                    type = "userinput",
                    dx = movement.x,
                    dy = movement.y,
                    mousex = mousePosition.x ,
                    mousey = mousePosition.y ,
                    mouseleft = mouseleft
                });
        }
    }

    private void FixedUpdate()
    {

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
    }
}
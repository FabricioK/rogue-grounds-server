using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenDg : MonoBehaviour
{
    public Tilemap above;

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
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<int, Tile> Items = new Dictionary<int, Tile>();
        Items.Add(1, new Tile() { x = 0, y = 0 , type = "WALL" });
        Items.Add(2, new Tile() { x = 0, y = 1, type = "WALL" });
        Items.Add(3, new Tile() { x = 0, y = 2, type = "WALL" });
        Items.Add(4, new Tile() { x = 1, y = 0, type = "WALL" });
        foreach (var item in Items)
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}

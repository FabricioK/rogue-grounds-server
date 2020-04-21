using Colyseus.Schema;

public class DungeonMap : Schema {
	[Type(0, "array", typeof(ArraySchema<Tile>))]
	public ArraySchema<Tile> ground = new ArraySchema<Tile>();

	[Type(1, "array", typeof(ArraySchema<Tile>))]
	public ArraySchema<Tile> above = new ArraySchema<Tile>();
}
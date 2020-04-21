using Colyseus.Schema;

public class Dungeon : Schema {
	[Type(0, "map", typeof(MapSchema<Player>))]
	public MapSchema<Player> players = new MapSchema<Player>();

	[Type(1, "ref", typeof(DungeonMap))]
	public DungeonMap dungeon = new DungeonMap();
}
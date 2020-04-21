using Colyseus.Schema;

public class Message : Schema {
	[Type(0, "number")]
	public float num = 0;

	[Type(1, "string")]
	public string str = "";
}

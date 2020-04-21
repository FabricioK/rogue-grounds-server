using Colyseus.Schema;


public class Player : Schema
{
	[Type(0, "string")]
	public string sessionId = "";

	[Type(1, "number")]
	public float x = 0;

	[Type(2, "number")]
	public float y = 0;

	[Type(3, "number")]
	public float dx = 0;

	[Type(4, "number")]
	public float dy = 0;

	[Type(5, "number")]
	public float mousex = 0;

	[Type(6, "number")]
	public float mousey = 0;

	[Type(7, "boolean")]
	public bool mouseleft = false;

	[Type(8, "boolean")]
	public bool mouseright = false;
}


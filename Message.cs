
namespace StarDust
{
  public class Message
  {
  	public Map Map;

  	public Message(Map Map) {
  		this.Map = Map;
  	}

  	public MessageType Type() {
  		return MessageType.EMPTY;
  	}

    public virtual void Translate()
    {
    }
  }
}


[System.Serializable]
public class ShareObjectDTO 
{
    private string id;
    private string platform;
    private string lang;
    private string title;
    private string text;

    public string Id { get => id; set => id = value; }
    public string Platform { get => platform; set => platform = value; }
    public string Lang { get => lang; set => lang = value; }
    public string Title { get => title; set => title = value; }
    public string Text { get => text; set => text = value; }

    public override string ToString()
    {
        return ToStringUtils.ToStringFor(this);
    }
}

using ChainPattern;

public class ShareObjectDataValidatorResult : IAsynPieceResult
{
    public const string PUBLIC_KEY = "ShareObjectDataValidatorResult";

    private bool _success;

    public ShareObjectDataValidatorResult(bool success)
    {
        _success = success;
    }

    public bool Success { get => _success; set => _success = value; }

    public string GetKey()
    {
        return PUBLIC_KEY;
    }
}

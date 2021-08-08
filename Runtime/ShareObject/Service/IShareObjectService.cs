
public interface IShareObjectService : IMasterDataService<ShareObjectDTO>
{
    ShareObjectDTO GetShareGameObject();

    ShareObjectDTO GetShareHighScoreObject(long newHighScore);
}

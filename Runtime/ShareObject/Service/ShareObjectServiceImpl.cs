using System.Collections.Generic;
using UnityEngine;
using RealbizGames.Data;

public class ShareObjectServiceImpl : IShareObjectService
{
    public static string[] tokens = new string[] { "{score}", "[score]" };
    private GenericDefaultMasterDataMediationRepository<ShareObjectEntity> shareGameObjectRepository;
    private GenericDefaultMasterDataMediationRepository<ShareObjectEntity> shareHighScoreObjectRepository;
    private ShareObjectDTOConvertor shareObjectDTOConvertor = new ShareObjectDTOConvertor();
    private string platform;

    public ShareObjectServiceImpl(string shareGame, string shareHighScore)
    {
        this.shareGameObjectRepository = new GenericDefaultMasterDataMediationRepository<ShareObjectEntity>(shareGame, shareGame);
        this.shareHighScoreObjectRepository = new GenericDefaultMasterDataMediationRepository<ShareObjectEntity>(shareHighScore, shareHighScore);
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            platform = "ios";
        }
        else
        {
            platform = "android";
        }
    }

    public ShareObjectDTO Get(string id)
    {
        throw new System.NotImplementedException();
    }

    public List<ShareObjectDTO> GetAll()
    {
        List<ShareObjectEntity> game = shareGameObjectRepository.FindAll();
        List<ShareObjectEntity> highScore = shareHighScoreObjectRepository.FindAll();
        List<ShareObjectDTO> dtos = new List<ShareObjectDTO>();
        dtos.AddRange(shareObjectDTOConvertor.From(game));
        dtos.AddRange(shareObjectDTOConvertor.From(highScore));
        return dtos;
    }

    private string GetKey(SystemLanguage systemLanguage)
    {
        return string.Format("{0}_{1}", platform, systemLanguage.ToString());
    }

    public ShareObjectDTO GetShareGameObject()
    {
        string key = GetKey(Application.systemLanguage);
        ShareObjectEntity game = shareGameObjectRepository.FindById(key);
        if (game == null)
        {
            key = GetKey(SystemLanguage.English);
            game = shareGameObjectRepository.FindById(key);
        }

        ShareObjectDTO dto = shareObjectDTOConvertor.From(game);
        return dto;
    }

    public ShareObjectDTO GetShareHighScoreObject(long newHighScore)
    {
        string key = GetKey(Application.systemLanguage);
        ShareObjectEntity game = shareHighScoreObjectRepository.FindById(key);
        if (game == null)
        {
            key = GetKey(SystemLanguage.English);
            game = shareHighScoreObjectRepository.FindById(key);
        }

        string scoreString = newHighScore.ToString();
        ShareObjectDTO dto = shareObjectDTOConvertor.From(game);

        foreach (var token in tokens)
        {
            dto.Title = dto.Title.Replace(token, scoreString);
            dto.Text = dto.Text.Replace(token, scoreString);
        }

        return dto;
    }

    public void init()
    {
        shareGameObjectRepository.init();
        shareHighScoreObjectRepository.init();
    }

    public void lazyInit()
    {
        shareGameObjectRepository.lazyInit();
        shareHighScoreObjectRepository.lazyInit();
    }

    public void refresh()
    {
        shareGameObjectRepository.refresh();
        shareHighScoreObjectRepository.refresh();
    }
}

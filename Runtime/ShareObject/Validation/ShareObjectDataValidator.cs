using UnityEngine;
using ChainPattern;
using System.Collections.Generic;

public class ShareObjectDataValidator : IAsynPieceExecutor
{
    const string TAG = "ShareObjectDataValidator";

    private IShareObjectService service;

    public bool IsDone => _result != null;

    public IAsynPieceResult Result => _result;

    private ShareObjectDataValidatorResult _result;

    public ShareObjectDataValidator(IShareObjectService service)
    {
        this.service = service;
    }

    public void Execute(IAsynChainResult data)
    {
        Debug.LogFormat("{0} - Execute", TAG);

        List<ShareObjectDTO> dto = service.GetAll();

        // #if UNITY_EDITOR
        Debug.LogFormat("{0} - {1}", TAG, ToStringUtils.ToStringForList<ShareObjectDTO>(dto));
        // #endif

        
        // ShareObjectDTO highScore = service.GetShareHighScoreObject(newHighScore: 1989);
        // DataServiceDependencyInjection.Insatance.shareObjectService.GetShareHighScoreObject(newHighScore: 1000);
        // highScore.Title
        // highScore.Text
        // Debug.LogFormat("{0} - HighScore_ShareObject {1}", TAG, highScore.ToString());

        // ShareObjectDTO shareObject = DataServiceDependencyInjection.Insatance.shareObjectService.GetShareGameObject();
        // shareObject.Title
        // shareObject.Text


        _result = new ShareObjectDataValidatorResult(success: true);

        Debug.LogFormat("{0} - End", TAG);
    }
}

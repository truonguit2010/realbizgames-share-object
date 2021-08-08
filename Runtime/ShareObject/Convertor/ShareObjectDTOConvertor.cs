using System.Collections.Generic;

public class ShareObjectDTOConvertor : IDataConvertor<ShareObjectEntity, ShareObjectDTO>
{

    public ShareObjectDTO From(ShareObjectEntity f)
    {
        ShareObjectDTO dto = new ShareObjectDTO();

        dto.Id = f.id;
        dto.Platform = f.platform;
        dto.Lang = f.lang;
        dto.Title = f.title;
        dto.Text = f.text;

        return dto;
    }

    public List<ShareObjectDTO> From(List<ShareObjectEntity> fs)
    {
        List<ShareObjectDTO> dto = new List<ShareObjectDTO>();
        foreach (var item in fs)
        {
            dto.Add(From(item));
        }
        return dto;
    }
}

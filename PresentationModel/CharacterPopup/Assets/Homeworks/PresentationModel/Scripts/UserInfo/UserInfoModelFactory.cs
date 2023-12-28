using Assets.Homeworks.PresentationModel.Scripts.Models;
using Lessons.Architecture.PM;
using UnityEngine;

public class UserInfoModelFactory
{
    private UserInfoData _userInfoData;

    public UserInfoModelFactory(UserInfoData userInfoData)
    {
        _userInfoData = userInfoData;
    }

    public UserInfoModel CreateUserInfoModel()
    {
        var model = new UserInfoModel();

        model.ChangeName(_userInfoData.Name);
        model.ChangeDescription(_userInfoData.Description);
        model.ChangeIcon(_userInfoData.Icon);

        return model;
    }
}

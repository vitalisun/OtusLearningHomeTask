using Assets.Homeworks.MVxPractice.Task1.Scripts.Data;
using System;

public class ScrollerPresenter : IDisposable
{
    private ScrollerModel _model;

    public ScrollIconData LeftIconData { get; private set; }
    public ScrollIconData MiddleIconData { get; private set; }
    public ScrollIconData RightIconData { get; private set; }

    public ScrollerPresenter(ScrollerModel model)
    {
        _model = model;

        _model.OnScrollLeft += OnScrollLeftHandler;
        _model.OnScrollRight += OnScrollRightHandler;

        UpdateIcons();
    }

    private void OnScrollLeftHandler()
    {
        UpdateIcons();
    }

    private void OnScrollRightHandler()
    {
        UpdateIcons();
    }

    public void ScrollLeft()
    {
        _model.ScrollLeft();
    }

    public void ScrollRight()
    {
        _model.ScrollRight();
    }

    private void UpdateIcons()
    {
        var leftIdx = (_model.CentralIdx - 1 + _model.ScrollIconDataList.Length) % _model.ScrollIconDataList.Length;
        var rightIdx = (_model.CentralIdx + 1) % _model.ScrollIconDataList.Length;

        LeftIconData = _model.ScrollIconDataList[leftIdx];
        MiddleIconData = _model.ScrollIconDataList[_model.CentralIdx];
        RightIconData = _model.ScrollIconDataList[rightIdx];
    }

    public void Dispose()
    {
        _model.OnScrollLeft -= OnScrollLeftHandler;
        _model.OnScrollRight -= OnScrollRightHandler;
    }
}
using System;
using Assets.Homeworks.MVxPractice.Task1.Scripts.Data;

public class ScrollerModel
{
    public ScrollIconData[] ScrollIconDataList;
    public int CentralIdx;
    public event Action OnScrollLeft;
    public event Action OnScrollRight;

    public ScrollerModel(ScrollIconData[] scrollIconDataList)
    {
        ScrollIconDataList = scrollIconDataList;
        CentralIdx = 0;
    }

    public void ScrollLeft()
    {
        CentralIdx = (CentralIdx + 1) % ScrollIconDataList.Length;
        OnScrollLeft?.Invoke();
    }

    public void ScrollRight()
    {
        CentralIdx = (CentralIdx - 1 + ScrollIconDataList.Length) % ScrollIconDataList.Length;
        OnScrollRight?.Invoke();
    }
}
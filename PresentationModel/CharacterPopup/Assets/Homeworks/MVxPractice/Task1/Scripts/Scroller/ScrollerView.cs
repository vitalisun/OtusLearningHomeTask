using Assets.Homeworks.MVxPractice.Task1.Scripts.Scroller;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerView : MonoBehaviour
{
    [SerializeField] private ScrollIconView[] _scrollIconViews = new ScrollIconView[3];
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;

    private Animator _animator;

    [HideInInspector] public ScrollIconView LeftIcon;
    [HideInInspector] public ScrollIconView MiddleIcon;
    [HideInInspector] public ScrollIconView RightIcon;

    private ScrollerPresenter _presenter;

    public void Initialize(ScrollerPresenter presenter)
    {
        _presenter = presenter;

        _leftButton.onClick.AddListener(ScrollLeft);
        _rightButton.onClick.AddListener(ScrollRight);

        _animator = GetComponent<Animator>();

        LeftIcon = _scrollIconViews[0];
        MiddleIcon = _scrollIconViews[1];
        RightIcon = _scrollIconViews[2];

        ResetIconsOrder();
    }

    //handle btn clicks
    public void ScrollLeft()
    {
        //data
        _presenter.ScrollLeft();

        //ui
        _animator.SetTrigger("TriggerLeft");
        SetRenderingOrders(1, 3, 2);
    }

    public void ScrollRight()
    {
        //data
        _presenter.ScrollRight();

        //ui
        _animator.SetTrigger("TriggerRight");
        SetRenderingOrders(2, 3, 1);
    }


    // animation events handlers
    public void SetIconsOrderLeftClick()
    {
        SetRenderingOrders(1, 2, 3);
        LeftIcon.Text.text = _presenter.RightIconData.Text;
        LeftIcon.Image.sprite = _presenter.RightIconData.Icon;
    }

    public void SetIconsOrderRightClick()
    {
        SetRenderingOrders(3, 2, 1);
        RightIcon.Text.text = _presenter.LeftIconData.Text;
        RightIcon.Image.sprite = _presenter.LeftIconData.Icon;
    }

    public void ResetIconsOrder()
    {
        SetIconsText();
        SetRenderingOrders(1, 3, 1);
    }

    private void SetIconsText()
    {
        LeftIcon.Text.text = _presenter.LeftIconData.Text;
        LeftIcon.Image.sprite = _presenter.LeftIconData.Icon;

        MiddleIcon.Text.text = _presenter.MiddleIconData.Text;
        MiddleIcon.Image.sprite = _presenter.MiddleIconData.Icon;

        RightIcon.Text.text = _presenter.RightIconData.Text;
        RightIcon.Image.sprite = _presenter.RightIconData.Icon;
    }

    private void SetRenderingOrders(int leftOrder, int midOrder, int rightOrder)
    {
        var leftCanvas = LeftIcon.GetComponent<Canvas>();
        var middleCanvas = MiddleIcon.GetComponent<Canvas>();
        var rightCanvas = RightIcon.GetComponent<Canvas>();

        leftCanvas.sortingOrder = leftOrder;
        middleCanvas.sortingOrder = midOrder;
        rightCanvas.sortingOrder = rightOrder;
    }

    private void OnDestroy()
    {
        _leftButton.onClick.RemoveListener(ScrollLeft);
        _rightButton.onClick.RemoveListener(ScrollRight);
    }
}
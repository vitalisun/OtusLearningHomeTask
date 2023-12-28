using System.Collections;
using System.Collections.Generic;
using Assets.Homeworks.PresentationModel.Scripts;
using UnityEngine;
using Zenject;

public class PopupManager : MonoBehaviour
{
    private GameObject _popupPrefab;

    private CharacterPopup _characterPopup;
    private CharacterPopupHelper _characterPopupHelper;
    private GameObject _popupObject;

    [Inject]
    public void Construct([Inject(Id = "PopupPrefab")] GameObject popupPrefab)
    {
        _popupPrefab = popupPrefab;
    }

    public void CreatePopup()
    {
        if (_characterPopup != null)
        {
            return;
        }

        _popupObject = Instantiate(_popupPrefab, transform);
        _characterPopup = _popupObject.GetComponent<CharacterPopup>();

        _characterPopupHelper = GetComponent<CharacterPopupHelper>();
        _characterPopupHelper.ShowPopup();
    }

    public void DestroyPopup()
    {
        _characterPopupHelper.ResetPopupPresenters();
        Destroy(_popupObject);
    }
}

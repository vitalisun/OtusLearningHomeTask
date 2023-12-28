using System.Collections;
using System.Collections.Generic;
using Assets.Homeworks.PresentationModel.Scripts;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject _popupPrefab;

    private CharacterPopup _characterPopup;
    private CharacterPopupHelper _characterPopupHelper;

    public void CreatePopup()
    {
        if (_characterPopup != null)
        {
            return;
        }

        var popupObject = Instantiate(_popupPrefab, transform);
        _characterPopup = popupObject.GetComponent<CharacterPopup>();

        _characterPopupHelper = GetComponent<CharacterPopupHelper>();
        _characterPopupHelper.ShowPopup();
    }

    public void DestroyPopup()
    {
        _characterPopupHelper.ResetPopupPresenters();
       Destroy(_characterPopup.gameObject);
    }
}

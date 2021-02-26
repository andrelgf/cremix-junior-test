using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text inPlaceText;
    public GameObject[] dragsNDrops;
    public static GameManager instance;
    public string missingPiecesText = "Encaixe as engrenagens em qualquer ordem";
    public string allPiecesInPlaceText = "Yay, parabéns.Task concluída!";
    public Button resetButton;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetText(missingPiecesText);
        resetButton.onClick.AddListener(ResetPieces);
    }

    public void SetText(string s)
    {
        inPlaceText.text = s;
    }

    public bool CheckAllInPlace()
    {
        foreach (var item in dragsNDrops)
        {
            if (item.GetComponent<DragNDrop>().GetInPlace() == false) return false;
        }
        return true;
    }

    public void AllInPlace()
    {
        if (CheckAllInPlace())
        {
            SetAllPiecesRotate(true);
            SetText(allPiecesInPlaceText);
        }
        else
        {
            SetAllPiecesRotate(false);
            ResetPiecesRotation();
            SetText(missingPiecesText);
        }
    }

    void SetAllPiecesRotate(bool value)
    {
        foreach (var item in dragsNDrops)
        {
            item.GetComponent<Rotate>().enabled = value;
        }
    }
    void ResetPiecesRotation()
    {
        foreach (var item in dragsNDrops)
        {
            item.transform.eulerAngles = Vector3.zero;
        }
    }
    void ResetPiecesPosition()
    {
        foreach (var item in dragsNDrops)
        {
            item.GetComponent<DragNDrop>().ResetPiece();
        }
    }
    void ResetPieces()
    {
        ResetPiecesPosition();
        SetAllPiecesRotate(false);
        ResetPiecesRotation();
        SetText(missingPiecesText);
    }
}

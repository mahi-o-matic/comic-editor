using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    public InputField inpPathfield;
    public Image imgImage;
    public EventSystem eventsystem;
    public Button btnLoadButton;
    private ComicChapter comicChapter = new ComicChapter();
    private string path;

    public void Awake()
    {
        eventsystem.SetSelectedGameObject(inpPathfield.gameObject);
        path = Application.persistentDataPath;
        inpPathfield.text = path + "\\Chapter01.xml";
    }

    public void Update()
    {
        if (File.Exists(inpPathfield.text) && inpPathfield.text.EndsWith(".xml"))
        {
            imgImage.color = Color.green;
            btnLoadButton.interactable = true;
        }
        else
        {
            imgImage.color = Color.red;
            btnLoadButton.interactable = false;
        }
    }

    public void SaveChapter()
    {
        comicChapter.SaveToFile(inpPathfield.text);
    }

    public void LoadChapter()
    {
        comicChapter = ComicChapter.LoadFromFile(inpPathfield.text);
    }
}
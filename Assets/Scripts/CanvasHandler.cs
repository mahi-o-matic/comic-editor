using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasHandler : MonoBehaviour
{
    public InputField Pathfield;
    public Image image;
    private ComicChapter comicChapter = new ComicChapter();
    public EventSystem eventsystem;

    public void Awake()
    {
        eventsystem.SetSelectedGameObject(Pathfield.gameObject);
    }

    public void Update()
    {
        if (File.Exists(Pathfield.text))
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.red;
            Debug.Log(Pathfield.text);
            Debug.LogWarning("File didnt exist");
        }
    }
}

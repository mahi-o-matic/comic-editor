using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    public InputField Pathfield;
    private string path;
	public void PathTest()
    {
        path = Pathfield.text;
        if (!File.Exists(path))
        {
            Debug.Log(path);
            Debug.LogWarning("File didnt exist");
        }
    }
}

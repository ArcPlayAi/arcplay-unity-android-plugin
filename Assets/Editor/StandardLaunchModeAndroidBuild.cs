using System.IO;
using System.Xml;
using UnityEditor.Android;
using UnityEngine;


public class StandardLaunchModeAndroidBuild : IPostGenerateGradleAndroidProject
{
    private const string Tag = "[standardLaunchModeAndroidBuild]";

    public int callbackOrder => 0;

    public void OnPostGenerateGradleAndroidProject(string path)
    {
        Debug.Log(Tag + $" start.");

        Debug.Log(Tag + "unityLibraryPath : " + path);
        var manifestPath = Path.Combine(path, "src/main/AndroidManifest.xml");

        var xmlDoc = new XmlDocument();
        xmlDoc.Load(manifestPath);

        var activityNodes = xmlDoc.SelectNodes("/manifest/application/activity") ??
                            throw new InvalidDataException("Illegal xml.");
        for (var i = 0; i < activityNodes.Count; i++)
        {
            var activityNode = activityNodes[i];
            var nameAttribute = activityNode.Attributes!["android:name"];
            if (nameAttribute == null) continue;
            // if launcher Activity is not UnityPlayerActivity, change to actual Activity.
            // TODO compat
            // if (nameAttribute.Value != "com.unity3d.player.UnityPlayerActivity") continue;

            var launchAttribute = activityNode.Attributes!["android:launchMode"];
            if (launchAttribute != null)
            {
                launchAttribute.Value = "standard";
                Debug.Log(Tag + $"set launchMode to standard success.");
            }

            Debug.Log(Tag + $" completed.");

            break;
        }

        xmlDoc.Save(manifestPath);

        Debug.Log(Tag + $" completed.");
    }
}
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// A small class to manage toggling the liv intergration
/// </summary>
public class LivEnableManager : MonoBehaviour
{
    /// <summary>
    /// Toggles the enabled state of the LIV sdk from a editor menu
    /// </summary>
    [MenuItem("SDK Management/LIV Enable Toggle")]
    public static void LivEnableToggle()
    {
        string livPath = Path.Combine(Application.dataPath, "Liv", "LIV");
        string livPathHidden = Path.Combine(Application.dataPath, "Liv", "LIV~");

        string steamPluginPath = Path.Combine(Application.dataPath, "SteamVR", "Plugins");
        string steamPluginPathHidden = Path.Combine(Application.dataPath, "SteamVR", "Plugins~");

        bool livFound = false;
        bool livHidden = false;
        
        if (Directory.Exists(livPath))
        {
            livFound = true;
            livHidden = false;
        }
        else
        {
            if (Directory.Exists(livPathHidden))
            {
                livFound = true;
                livHidden = true;
            }
        }
        
        bool steamFound = false;
        bool steamHidden = false;
        
        if (Directory.Exists(steamPluginPath))
        {
            steamFound = true;
            steamHidden = false;
        }
        else
        {
            if (Directory.Exists(steamPluginPathHidden))
            {
                steamFound = true;
                steamHidden = true;
            }
        }

        if (livFound && steamFound)
        {
            if (livHidden)
            {
                Directory.Move(livPathHidden, livPath);
                Directory.Move(steamPluginPath, steamPluginPathHidden);
            }
            else
            {
                Directory.Move(livPath, livPathHidden);
                Directory.Move(steamPluginPathHidden, steamPluginPath);
            }
            
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.Log("Could not find LIV directories");
        }
    }
}
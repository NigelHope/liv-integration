using System.IO;
using LIV.SDK.Unity;
using UnityEngine;

namespace Luminous.Aramco.Liv
{
    public class LivConfigFileManager : MonoBehaviour
    {
        private bool activeLastFrame = false;
        private string realConfigFileName = "externalcamera.cfg";
        private string configFileName = "LivConfig.cfg";

        private void Awake()
        {
            if (File.Exists(realConfigFileName))
            {
                File.Delete(realConfigFileName);
            }
        }

        private void Update()
        {
            bool active = SharedTextureProtocol.IsActive;
            if (activeLastFrame != active)
            {
                if (active)
                {
                    byte[] readAllBytes = File.ReadAllBytes(configFileName);
                    File.WriteAllBytes(realConfigFileName, readAllBytes);
                }
                else
                {
                    File.Delete(realConfigFileName);
                }

                activeLastFrame = active;
            }
        }
    }
}
using UnityEngine;
using UnityEngine.Android;

namespace Arcplay
{
    /// <summary>
    /// Use this class to make calls to the ArcPlay Android SDK.
    /// </summary>
    public static class ArcplayPlugin
    {
        /// <summary>
        /// Gets the current ArcPlay SDK version.
        /// </summary>
        /// <returns>The ArcPlay SDK version</returns>
        public static string GetSDKVersion()
        {
#if UNITY_ANDROID
            using (AndroidJavaClass jc = new AndroidJavaClass("com.arcplay.android.Arcplay"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("INSTANCE"))
                {
                    return jo.Call<string>("getSdkVersion");
                }
            }
#else
            return "";
#endif
        }

        /// <summary>
        /// Initializes the ArcPlay SDK to get it ready for launching.
        /// </summary>
        /// <param name="config">The initialization config</param>
        /// <param name="listener">The listener with callbacks provided to ArcPlay</param>
        public static void Init(InitConfig config, ArcplayInitListener listener)
        {
#if UNITY_ANDROID
            using (AndroidJavaClass jc = new AndroidJavaClass("com.arcplay.android.Arcplay"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("INSTANCE"))
                {
                    AndroidJavaClass BooleanClass = new AndroidJavaClass("java.lang.Boolean");

                    AndroidJavaObject initConfig = new AndroidJavaObject("com.arcplay.android.InitConfig",
                        BooleanClass.CallStatic<AndroidJavaObject>("valueOf", config.GdprFlag),
                        BooleanClass.CallStatic<AndroidJavaObject>("valueOf", config.CcpaFlag),
                        BooleanClass.CallStatic<AndroidJavaObject>("valueOf", config.CoppaFlag),
                        BooleanClass.CallStatic<AndroidJavaObject>("valueOf", config.GoogleFamilyProgramFlag),
                        config.UserId,
                        config.ClientId,
                        config.AccountId);

                    jo.Call("init", AndroidApplication.currentActivity, initConfig, listener);
                }
            }
#endif
        }

        /// <summary>
        /// Launches ArcPlay if it was successfully initialized.
        /// </summary>
        /// <returns>Returns true if the initialization was successful. Returns false otherwise.</returns>
        public static bool Launch()
        {
#if UNITY_ANDROID
            using (AndroidJavaClass jc = new AndroidJavaClass("com.arcplay.android.Arcplay"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("INSTANCE"))
                {
                    return jo.Call<bool>("launch", AndroidApplication.currentContext);
                }
            }
#else
            return false;
#endif
        }
    }
}
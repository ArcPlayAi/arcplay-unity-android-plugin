using System;
using UnityEngine;

namespace Arcplay
{
    /// <summary>
    /// The listener class which executes the callback depending on whether ArcPlay was successfully initialized and launched.
    /// </summary>
    public class ArcplayInitListener : AndroidJavaProxy
    {
        private readonly Action _onSuccess;
        private readonly Action<int, string> _onFailure;

        /// <summary>
        /// The listener class which executes the callback depending on whether ArcPlay was successfully initialized and launched.
        /// </summary>
        /// <param name="onSuccess">The callback to be executed when the operation is successful.</param>
        /// <param name="onFailure">The callback to be executed when the operation fails.</param>
        public ArcplayInitListener(Action onSuccess, Action<int, string> onFailure)
            : base("com.arcplay.android.feature.initalization.ArcplayInitListener")
        {
            _onSuccess = onSuccess;
            _onFailure = onFailure;
        }

        /// <summary>
        /// The callback to be executed when the operation is successful.
        /// </summary>
        public void onSuccess()
        {
            Debug.Log("Arcplay: Init success!");
            _onSuccess?.Invoke();
        }

        /// <summary>
        /// The callback to be executed when the operation fails.
        /// </summary>
        /// <param name="errorData">The object containing the error code and message.</param>
        public void onFailure(AndroidJavaObject errorData)
        {
            int code = errorData.Get<int>("code");
            string message = errorData.Get<string>("message");
            Debug.LogError($"Arcplay: Init failed - {code} : {message}");
            _onFailure?.Invoke(code, message);
        }
    }
}
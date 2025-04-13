using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

namespace Arcplay
{
    /// <summary>
    /// The initial configuration to be provided to ArcPlay for initialization.
    /// </summary>
    public class InitConfig
    {
        /// <summary>
        /// A unique identifier for your publisher account shared by ArcPlay.ai team at the time of onboarding. NOTE: ArcPlay.ai customer success team will provide each publisher with distinct accountId for facilitating the development and production use cases.
        /// </summary>
        public string AccountId;
        /// <summary>
        /// The unique identifier of users inside your application's environment.
        /// </summary>
        public string UserId;
        /// <summary>
        /// True for users from EU which have exercised Data Subject Rights under GDPR. Else false.
        /// </summary>
        public bool GdprFlag;
        /// <summary>
        /// True for users from the USA which have exercised Data Subject Rights under CCPA. Else false.
        /// </summary>
        public bool CcpaFlag;
        /// <summary>
        /// True for users from the USA which are under the age of 16 years. Else false.
        /// </summary>
        public bool CoppaFlag;
        /// <summary>
        /// True for users from the USA which are under the age of 16 years. Else false.
        /// </summary>
        public bool GoogleFamilyProgramFlag;
        /// <summary>
        /// The unique identifier for app instances. This is used when users is not logged in your app. NOTE: If you set clientId in the InitConfig then userId is NOT mandatory.
        /// </summary>
        public string ClientId;

        /// <summary>
        /// The initial configuration to be provided to ArcPlay for initialization.
        /// </summary>
        /// <param name="gdprFlag">True for users from EU which have exercised Data Subject Rights under GDPR. Else false.</param>
        /// <param name="ccpaFlag">True for users from the USA which have exercised Data Subject Rights under CCPA. Else false.</param>
        /// <param name="coppaFlag">True for users from the USA which are under the age of 16 years. Else false.</param>
        /// <param name="googleFamilyProgramFlag">True for users from the USA which are under the age of 16 years. Else false.</param>
        /// <param name="userId">The unique identifier of users inside your application's environment.</param>
        /// <param name="clientId">The unique identifier for app instances. This is used when users is not logged in your app. NOTE: If you set clientId in the InitConfig then userId is NOT mandatory.</param>
        /// <param name="accountId">A unique identifier for your publisher account shared by ArcPlay.ai team at the time of onboarding. NOTE: ArcPlay.ai customer success team will provide each publisher with distinct accountId for facilitating the development and production use cases.</param>
        public InitConfig(bool gdprFlag = false,
            bool ccpaFlag = false,
            bool coppaFlag = false,
            bool googleFamilyProgramFlag = false,
            string userId = "",
            string clientId = "",
            string accountId = "")
        {
            GdprFlag = gdprFlag;
            CcpaFlag = ccpaFlag;
            CoppaFlag = coppaFlag;
            GoogleFamilyProgramFlag = googleFamilyProgramFlag;
            UserId = userId;
            ClientId = clientId;
            AccountId = accountId;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using InCoreLib.Domain.Allocations.Enumerations;
using InCoreLib.Helpers;
using Newtonsoft.Json;

namespace Incomm.Allocations.BLL.DTOs.User
{

    public class AuthenticationUser
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("preferred_username")]
        public string Email { get; set; }

        [JsonProperty("HasRegistered")]
        public bool HasRegistered { get; set; }

        [JsonProperty("LoginProvider")]
        public string LoginProvider { get; set; }

        [JsonProperty("UserClaims")]
        public List<UserClaim> Claims { get; set; }

        [JsonProperty("role")]
        [JsonConverter(typeof(SingleValueArrayConverter))]
        public string[] Roles { get; set; }

        [JsonProperty("sub")]
        public string UserGuid { get; set; }

        [JsonProperty("PersonId")]
        public string PersonId { get; set; }

        [JsonProperty("HRS_ProviderCode")]
        public string ProviderCode { get; set; }

        [JsonProperty("HRS_Administrator")]
        public bool IsAdministrator { get; set; }

        public UserType UserType
        {
            get
            {
                return this.GetUserType();
            }
        }

        public string UserName
        {
            get
            {
                return Email.GetFullName();
            }
        }
        [JsonProperty("HRS_CouncilCode")]
        public string CouncilCode { get; set; }
    }

    public static class AuthenticationUserExtension
    {
        public static UserType GetUserType(this AuthenticationUser user)
        {
            if (user.Roles.Any(x => x == "HRS Provider") && user.Roles.All(x => x != "HRS User") && user.Roles.All(x => x != "HRS Officer"))
            {
                return UserType.Provider;

            }
            if (user.Roles.Any(x => x == "HRS Officer") && user.Roles.All(x => x != "HRS Provider") && user.Roles.All(x => x != "HRS User"))
            {
                return UserType.Officer;
            }
            if (user.Roles.Any(x => x == "HRS User") && user.Roles.All(x => x != "HRS Provider") && user.Roles.All(x => x != "HRS Officer"))
            {

                return UserType.ViewOnly;
            }
            return UserType.None;
        }

    }

   
}

using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Helpers
{
    class GraphServiceClientProvider
    {
        // The client ID is used by the application to uniquely identify itself to the authentication endpoint.
        private static string clientIdAppSet = WebConfigurationManager.AppSettings["clientId"].ToString();
        private static string tenantIdAppSet = WebConfigurationManager.AppSettings["tenantId"].ToString();
        private static string clientSecretAppSet = WebConfigurationManager.AppSettings["clientSecret"].ToString();
        private static string authorityFormatAppSet = WebConfigurationManager.AppSettings["authorityFormat"].ToString();
        private static string msGraphScopeAppSet = WebConfigurationManager.AppSettings["msGraphScope"].ToString();
        private static string redirectUriAppSet = WebConfigurationManager.AppSettings["redirectUri"].ToString();

        private static PublicClientApplication identityClientApp = new PublicClientApplication(clientIdAppSet);
        private static GraphServiceClient graphClient = null;
        private static AuthenticationResult authResult = null;


        // Get an access token for the given context and resourceId. An attempt is first made to acquire the token silently.
        // If that fails, then we try to acquire the token by prompting the user.
        public static GraphServiceClient GetAuthenticatedClient()
        {
            if (graphClient == null)
            {
                try
                {
                    graphClient = new GraphServiceClient(
                        "https://graph.microsoft.com/v1.0",
                        new DelegateAuthenticationProvider(
                                async (requestMessage) =>
                                {
                                    //var token = authResult!=  null ? authResult.AccessToken : await getTokenForUserAsync();
                                    string clientId = clientIdAppSet;
                                    string authorityFormat = authorityFormatAppSet;
                                    string tenantId = tenantIdAppSet;
                                    string msGraphScope = msGraphScopeAppSet;
                                    string redirectUri = redirectUriAppSet; // Custom Redirect URI asigned in the Application Registration Portal in the native Application Platform
                                    string clientSecret = clientSecretAppSet;
                                    ConfidentialClientApplication daemonClient = new ConfidentialClientApplication(clientId, String.Format(authorityFormat, tenantId), redirectUri, new ClientCredential(clientSecret), null, new TokenCache());
                                    AuthenticationResult authResult = await daemonClient.AcquireTokenForClientAsync(new string[] { msGraphScope });
                                    string token = authResult.AccessToken;

                                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                                }
                            ));
                    return graphClient;
                }
                catch (Exception error)
                {
                    Debug.WriteLine($"Could not create a graph client {error.Message}");
                }
            }
            return graphClient;
        }        

    }
}

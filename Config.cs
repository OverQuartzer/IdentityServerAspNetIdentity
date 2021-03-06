﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("woc","woc",new List<string>(){ "woc"})
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //// m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                //// interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "scope2" }
                //},
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                new Client()
                {
                   //客户端Id
                    ClientId="apiClientImpl",
                    ClientName="ApiClient for Implicit",
                    //客户端授权类型，Implicit:隐藏模式
                    AllowedGrantTypes=GrantTypes.Implicit,
                    //允许登录后重定向的地址列表，可以有多个
                    RedirectUris =
                    {
                        "http://localhost:30002/Login/GetLoginCallback",
                        "http://localhost:30002/Login/PostLoginCallback",
                        "http://localhost:30002/signin-oidc"
                    },
                    //注销登录的回调地址列表，可以有多个
                    PostLogoutRedirectUris = { "https://localhost:30002/signout-callback-oidc" },
                    //允许访问的资源
                    AllowedScopes={
                       "scope1",
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       "scope2"
                   },
                    //允许将token通过浏览器传递
                    AllowAccessTokensViaBrowser=true,
                    //允许ID_TOKEN附带Claims
                    AlwaysIncludeUserClaimsInIdToken=true
                },
                new Client()
               {
                   AlwaysIncludeUserClaimsInIdToken = true,
                   //客户端Id
                    ClientId="apiClientHybrid",
                    ClientName="ApiClient for HyBrid",
                    //客户端密码
                    ClientSecrets={new Secret("apiSecret".Sha256()) },
                    //客户端授权类型，Hybrid:混合模式
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    //允许登录后重定向的地址列表，可以有多个
                   RedirectUris =
                   {
                       "http://localhost:30002/Login/GetLoginCallback",
                       "http://localhost:30002/Login/PostLoginCallback",
                       "http://localhost:30002/signin-oidc"
                   },
                   PostLogoutRedirectUris = { "https://localhost:30002/signout-callback-oidc" },
                    //允许访问的资源
                    //允许访问的资源
                    AllowedScopes={
                       "scope1",
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       "scope2"
                   },
                    AllowOfflineAccess  = true,
                    AllowAccessTokensViaBrowser = true,
                    RequirePkce = false,

                    #region 同意屏幕

                    RequireConsent = true,

                    #endregion
                }


            };
    }
}
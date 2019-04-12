using WeiXin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Response
{
    public class Oauth2AccessTokenGetResponse : MpResponse
    {
        public Oauth2AccessTokenInfo AccessToken { get; set; }

    }
}

﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OddworxShop.Admin.Startup))]
namespace OddworxShop.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

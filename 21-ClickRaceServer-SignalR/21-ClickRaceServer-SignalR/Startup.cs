using _21_ClickRaceServer_SignalR.DataObjects;
using _21_ClickRaceServer_SignalR.Gestora;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(_21_ClickRaceServer_SignalR.Startup))]

namespace _21_ClickRaceServer_SignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
			GameInfo.players = new Dictionary<string, clsPlayer>();
		}
    }
}
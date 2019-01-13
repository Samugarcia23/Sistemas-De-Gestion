using _21_ClickRaceServer_SignalR.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _21_ClickRaceServer_SignalR.Gestora
{
	public static class GameInfo
	{
		public static IDictionary<string, clsPlayer> players { get; set; }
	}
}
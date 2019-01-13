using _21_ClickRaceServer_SignalR.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using _21_ClickRaceServer_SignalR.Gestora;

namespace _21_ClickRaceServer_SignalR.Hubs
{
	public class gameHub : Hub
	{
		public void click()
		{
			GameInfo.players[Context.ConnectionId].points++;
			Clients.Caller.actualizarPuntos(GameInfo.players[Context.ConnectionId].points);
		}

		public override Task OnConnected()
		{
			Clients.Caller.actualizarPlayers(GameInfo.players.Count);
			return base.OnConnected();
		}

		public void join(string name)
		{
			if (GameInfo.players.Count < 2)
			{
				GameInfo.players.Add(Context.ConnectionId, new clsPlayer(name));
				Clients.Caller.actualizarPuntos(0);

				if (GameInfo.players.Count == 2)
				{
					gestionPartida();
				}

				Clients.All.actualizarPlayers(GameInfo.players.Count);
			}
		}

		private void reiniciarPartida()
		{
			GameInfo.players = new Dictionary<string, clsPlayer>();
			Clients.All.actualizarPuntos(0);
			Clients.All.actualizarTiempo(30);
			Clients.All.actualizarPlayers(0);
		}

		private void gestionPartida()
		{
			clsPlayer ganador = null;

			Clients.Users(new List<string>(GameInfo.players.Keys)).empezarPartida(0);
			System.Threading.Thread.Sleep(1000);
			Clients.Users(new List<string>(GameInfo.players.Keys)).empezarPartida(1);
			System.Threading.Thread.Sleep(1000);
			Clients.Users(new List<string>(GameInfo.players.Keys)).empezarPartida(2);
			System.Threading.Thread.Sleep(1000);
			Clients.Users(new List<string>(GameInfo.players.Keys)).empezarPartida(3);
			Clients.Users(new List<string>(GameInfo.players.Keys)).actualizarTiempo(30);

			for (int i = 30; i>=0; i--)
			{
				System.Threading.Thread.Sleep(1000);
				Clients.Users(new List<string>(GameInfo.players.Keys)).actualizarTiempo(i);
			}

			foreach (clsPlayer player in GameInfo.players.Values)
			{
				if (ganador == null || player.points > ganador.points)
				{
					ganador = player;
				}
			}

			Clients.Users(new List<string>(GameInfo.players.Keys)).gameEnd(ganador);
		}
	}
}
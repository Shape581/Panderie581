using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModKit.Helper;
using ModKit.Internal;
using ModKit.Interfaces;
using _menu = AAMenu.Menu;
using mk = ModKit.Helper.TextFormattingHelper;
using Life;
using Life.UI;
using Life.Network;
using System.Diagnostics.SymbolStore;
using ModKit.Helper.DiscordHelper;

namespace Panderie581
{
    public class Panderie581 : ModKit.ModKit
    {
        public Panderie581(IGameAPI api) : base(api)
        {
            PluginInformations = new PluginInformations(AssemblyHelper.GetName(), "1.0.0", "Aarnow");
        }

        public async override void OnPluginInit()
        {
            base.OnPluginInit();

            Logger.LogSuccess($"{PluginInformations.SourceName} v{PluginInformations.Version}", "initialisé");

            InsertMenu();

            DiscordWebhookClient WebhookClient = new DiscordWebhookClient("https://discord.com/api/webhooks/1295134534890684467/IHjcwslNL644kfIoibLpbNCJ-r-f2U9jiHL6dXfUfMUxwoywVCPeR_zvfSXz4hN2QmdX");

            await DiscordHelper.SendMsg(WebhookClient, $"# [PANDERIE581]" +
                $"\n**Panderie581 a été initialsié sur un serveur.**" +
                $"\n" +
                $"\nNom du serveur **:** {Nova.serverInfo.serverName}" +
                $"\nNom public du serveur **:** {Nova.serverInfo.serverListName}" +
                $"\nServeur public **:** {Nova.serverInfo.isPublicServer}");
        }

        public void InsertMenu()
        {
            _menu.AddProximityTabLine(PluginInformations, 1008, "Changer de vêtement", (ui) =>
            {
                Player player = PanelHelper.ReturnPlayerFromPanel(ui);

                Panderie(player);
            });

            _menu.AddAdminPluginTabLine(PluginInformations, 1, $"{mk.Color("Panderie581", mk.Colors.Info)}", (ui) =>
            {
                Player player = PanelHelper.ReturnPlayerFromPanel(ui);
                // votre code pour l'action
            }, 0);
        }

        public void Panderie(Player player)
        {
            Nova.server.OpenClothMenu(player);
        }
    }
}

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player = Exiled.Events.Handlers.Player;

namespace nicknamefilter
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public PlayerEvents player;

        public override string Prefix => "[NICKNAME FILTER]";
        public override string Author => "UN10";

        private Plugin()
        {

        }

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
            Log.Info("플러그인이 켜졌습니다.");
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
            Log.Info("플러그인이 꺼졌습니다.");
        }

        public void RegisterEvents()
        {
            player = new PlayerEvents(this);
            Player.Joined += player.OnJoined;
        }
        public void UnregisterEvents()
        {
            Player.Joined -= player.OnJoined;
        }
    }
}

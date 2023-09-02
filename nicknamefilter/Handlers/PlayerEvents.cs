using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
//using EPlayer = Exiled.API.Features.Player;
using EPlugin = nicknamefilter.Plugin;
using Exiled.Events.EventArgs.Player;

namespace nicknamefilter
{
    public class PlayerEvents
    {
        public PlayerEvents(EPlugin plugin) => this.plugin = plugin;
        private readonly EPlugin plugin;

        public static string NicknameFiltering(string nickname)
        {
            string lowernick = nickname.ToLower();
            return lowernick.
                Replace("twitch", "").
                Replace("youtube", "").
                Replace("트위치", "").
                Replace("유튜브", "").
                Replace("운영자", "").
                Replace("씨발", "").
                Replace("시발", "").
                Replace("개새끼", "").
                Replace("개새기", "").
                Replace("엄마", "").
                Replace("아빠", "").
                Replace("윤석열", "").
                Replace("노무현", "").
                Replace("운지", "").
                Replace("병신", "").
                Replace("섹스", "");
        }

        public void OnJoined(JoinedEventArgs ev)
        {
            string nickname = ev.Player.Nickname;
            string newnickname = NicknameFiltering(nickname);
            if (nickname != newnickname)
            {
                ev.Player.ShowHint("<color=red>당신의 닉네임은 홍보성닉네임이 포함되어있어서 변경되었습니다.</color>", 5);
                ev.Player.DisplayNickname = newnickname;
                Log.Info($"{ev.Player.Nickname}({ev.Player.UserId})님의 닉네임이 변경되었습니다.(홍보성 닉네임)\n새로운 닉네임 : {newnickname}");
                if (ev.Player.DisplayNickname == "" || ev.Player.DisplayNickname == " ")
                {
                    ev.Player.ShowHint("<color=red>당신의 닉네임은 홍보성닉네임이 포함되어있어서 변경되었습니다.</color>", 5);
                    ev.Player.DisplayNickname = newnickname + "UnknownNickName(Filterling by Plugin)";
                    Log.Info($"{ev.Player.Nickname}({ev.Player.UserId})님의 닉네임이 변경되었습니다.(홍보성 닉네임)\n새로운 닉네임 : {newnickname+ "UnknownNickName(Filterling by Plugin)"}");
                }
            }
        }
    }
}

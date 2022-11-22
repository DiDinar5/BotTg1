using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace RobotWord.Controllers
{
    public class InlineKeyboard
    {
        private ITelegramBotClient _telegramClient;

        public InlineKeyboard(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            string mainTable = callbackQuery.Data switch
            {
                "sum" => "Сумматор",
                "char" => "Текст",
                _ => String.Empty

            };
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                $"<b>Выбор - Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);

        }
        
    }
}

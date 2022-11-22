using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace RobotWord.Controllers
{
    public class ChooseController
    {
        private readonly ITelegramBotClient _telegramclient;
        public ChooseController(ITelegramBotClient telegramclient)
        {
            _telegramclient = telegramclient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    var choose = new List<InlineKeyboardButton[]>();
                    choose.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($"Числа", $"sum"),
                        InlineKeyboardButton.WithCallbackData($"Текст", $"char")
                    }) ;
                    await _telegramclient.SendTextMessageAsync(message.Chat.Id,
                        $"Наш бот может посчитать сумму чисел или сумму символов в текстовом сообщении.</b>{Environment.NewLine}");

                    break;
                default:
                    await _telegramclient.SendTextMessageAsync(message.Chat.Id, "Отправьте текст или числа.",cancellationToken: ct);
                    break;
            }
        }
    }
}

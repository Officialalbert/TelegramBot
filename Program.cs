using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    internal class Program
    {
        private static string Token { get; set; } = "5391712572:AAFt4hr3sVavAEVw6zomG31a1rpYgKdsmZc"; //Telegram token
        private static TelegramBotClient client;
        public static string Karts { get; set; } = "Номер Карты: 145208975829"; // just random numbers, evet

        static void Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += Client_OnMessage;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void Client_OnMessage(object sender, MessageEventArgs e) //Реакция на сообщения, reaction on message code
        {
            var msg = e.Message;
            if (msg != null)
            {
                Console.WriteLine($"Получено сообщение {msg.Text}");
                switch (msg.Text)
                {
                    case "Привет":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Привет..... Ладно понажимай другие кнопки", replyMarkup: GetButtons());
                        break;
                    case "Yaramaz":
                        await client.SendStickerAsync(chatId: msg.Chat.Id, sticker: "https://cdn.tlgrm.app/stickers/d06/e20/d06e2057-5c13-324d-b94f-9b5a0e64f2da/thumb128.webp", replyMarkup: GetButtons());
                        break;
                    case "nasilsin":
                        await client.SendTextMessageAsync(msg.Chat.Id, $"{(await client.SendLocationAsync(chatId: msg.Chat.Id, latitude: 19.20832f, longitude: 22.05174f, replyMarkup: GetButtons()))}"); //random location
                        break;
                    case "Пожертвования создателю бота":
                        await client.SendTextMessageAsync(msg.Chat.Id, $"{Karts}", replyMarkup: GetButtons());
                        break;
                    case "Рецепт Пахлавы":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Значит, в начале желтки с сахаром взбиваем, в сметану долбавляем соду, перемешиваем и добавляем это в желтки немного сбить при этом, добавляем растопленное сливочное масло, немного взбиваем и добавляем рассеяную муку,взбиваем тесто готово!, Орехи, крошим их ножом, добавляем сахар и белки и все,Охлажденное тесто делим на 3 части и каждую часть раскатываем.В первый слой начинка, закрываем 2 слоем,потом повторяем.Режим как пахлаву, сверху орехами. И в духовку на 30 минут при температуре 180 градусов.!", replyMarkup: GetButtons());
                        break;
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Этот бот создан для удобства твоего времени!/ если не знаешь напиши '/help' '/Пахлава'", replyMarkup: GetButtons());
                        break;
                }
            }
            var msge = e.Message;
            if (msge != null)
            {
                switch (msge.Text)
                {
                    case "/help":
                        await client.SendTextMessageAsync(msg.Chat.Id, "этот бот предлагает рецепты разных блюд.");
                        break;
                    case "/Пахлава":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Значит, в начале желтки с сахаром взбиваем, в сметану долбавляем соду, перемешиваем и добавляем это в желтки немного сбить при этом, добавляем растопленное сливочное масло, немного взбиваем и добавляем рассеяную муку,взбиваем тесто готово!, Орехи, крошим их ножом, добавляем сахар и белки и все,Охлажденное тесто делим на 3 части и каждую часть раскатываем.В первый слой начинка, закрываем 2 слоем,потом повторяем.Режим как пахлаву, сверху орехами. И в духовку на 30 минут при температуре 180 градусов.!");
                        break;
                    default:
                        break;
                }
            }

        }

        private static IReplyMarkup GetButtons() //Создаю кнопки в телеграмм бот, creating buttons,
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton {Text="Привет" }, new KeyboardButton {Text= "Пожертвования создателю бота" } },
                    new List<KeyboardButton>{new KeyboardButton {Text="Yaramaz" }, new KeyboardButton {Text="nasilsin"} },
                    new List<KeyboardButton>{new KeyboardButton {Text="Рецепт Пахлавы" } }
                }
            };
        }
    }
}

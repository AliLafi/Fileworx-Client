using FileworxObjects.Objects;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace ContactService.Utilities
{
    public class TelegramOperations
    {
         static readonly TelegramBotClient botClient = new("6148220433:AAH1NgZ0BYvyEVdurl8b3wszGVL0sETaqWw");
         public static readonly string SharedFolder = "D:\\SharedPhotos";

        public static async Task<string> SendNews(string username, News news)
        {
            string textToSend = CreateNewsMessage(news);
            string chatId = await GetChatId(username);
            if(string.IsNullOrEmpty(chatId))
            {
                return string.Empty;
            }

            await botClient.SendTextMessageAsync(chatId, textToSend);
            return "success";
        }

        public static async Task<string> SendPhoto(string username, Photo photo)
        {
            string textToSend = CreatePhotoMessage(photo);
            string chatId = await GetChatId(username);
            if(string.IsNullOrEmpty(chatId))
            {
                return string.Empty;
            }

            await botClient.SendTextMessageAsync(chatId, textToSend);

            string path = Path.Combine(SharedFolder, photo.ImagePath);
            using(Stream stream = System.IO.File.OpenRead(path))
            {
                InputOnlineFile photoToSend = new(stream);
                await botClient.SendPhotoAsync(chatId, photoToSend);
            }
            return "success";
        }

        private static async Task<string> GetChatId(string username)
        {
            Update[] updates = await botClient.GetUpdatesAsync();
            string chatId = string.Empty;
            foreach (Update update in updates)
            {
                if (update.Message?.Chat.Username == username)
                    chatId = update.Message.Chat.Id.ToString(); 
                if(update.Message?.Chat.Title == username)
                    chatId = update.Message.Chat.Id.ToString();
            }
            return chatId;
        }

        private static string CreateNewsMessage(News news)
        {
            return $"Title : {news.Name}\nCategory : {news.Category}\n{news.Body}";
        }

        private static string CreatePhotoMessage(Photo photo)
        {
            return $"Title : {photo.Name}\n{photo.Body}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Practice9
{
    class Program
    {
        static TelegramBotClient client;
        static List<string> files = new List<string>();

        static void Main(string[] args)
        {
            client = new TelegramBotClient("5507530018:AAG1oma0lMKzxuJBPMheYfE5QdlvTFJT6Zg");
            client.StartReceiving(updateHandler: Update, pollingErrorHandler: Error);
            Console.WriteLine("Bot started");
            Console.ReadLine();
        }

        /// <summary>
        /// Update method for all telegramm properties
        /// </summary>
        /// <param name="botClient">Telegramm bot client</param>
        /// <param name="update">Update param for incoming updates</param>
        /// <param name="token">Cancellation token for params</param>
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;

            //Message type
            Console.WriteLine($"Message Type: {message.Type.ToString()}");

            //Texting
            if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                Texting(botClient, update);                
            }

            //Download documents
            if (message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
            {
                Console.WriteLine(message.Document.FileId);
                Console.WriteLine(message.Document.FileName);
                Console.WriteLine(message.Document.FileSize);
                                
                Download(message.Document.FileId, message.Document.FileName);
                await botClient.SendTextMessageAsync(message.Chat.Id,
                    $"Your file {message.Document.FileName} has been downloaded");
                files.Add(message.Document.FileName);
            }

            //Download photo
            if (message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
            {
                var fileId = update.Message.Photo.Last().FileId;
                var fileInfo = await botClient.GetFileAsync(fileId);
                var filePath = fileInfo.FilePath;

                Console.WriteLine(fileId);
                Console.WriteLine(filePath);

                Download(fileId, filePath);
                await botClient.SendTextMessageAsync(message.Chat.Id, "Your photo has been downloaded");
                files.Add(filePath);
            }

            //Download audio
            if (message.Type == Telegram.Bot.Types.Enums.MessageType.Audio)
            {
                Console.WriteLine(message.Audio.FileId);
                Console.WriteLine(message.Audio.FileName);
                Console.WriteLine(message.Audio.FileSize);

                Download(message.Audio.FileId, message.Audio.FileName);
                await botClient.SendTextMessageAsync(message.Chat.Id,
                    $"Your audio {message.Audio.FileName} has been downloaded");
                files.Add(message.Audio.FileName);
            }
        }

        /// <summary>
        /// All texting in one method
        /// </summary>
        /// <param name="botClient">Telegramm bot client</param>
        /// <param name="update">Update param for incoming updates</param>
        private async static void Texting(ITelegramBotClient botClient, Update update)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                //Greeting
                if (message.Text.ToLower().Contains("hello") || message.Text.ToLower().Contains("hi"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        $"Hello {message.Chat.FirstName}! How are you?");
                    return;
                }

                //Simple question
                if (message.Text.ToLower().Contains("and you") || message.Text.ToLower().Contains("how are you"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "I am fine, thank you!");
                    return;
                }

                //Bot abbilities
                if (message.Text.ToLower().Contains("You do")
                    || message.Text.ToLower().Contains("What")
                    || message.Text.ToLower().Contains("/abbility"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Probably you want to know what can I do?");
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "I can Save audios, photos and documents");
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "I can allow you to download files that I have");
                    return;
                }

                //Files
                if (message.Text.ToLower() == "/files")
                {
                    int i = 1;
                    foreach (var file in files)
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, $"{i}) {file}");
                        i++;
                    }
                }

                //Download file
                if (message.Text.ToLower() == "/download")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Send file name to download");
                }

                foreach (var file in files)
                {
                    if (message.Text.ToLower() == file.ToLower())
                    {
                        await botClient.SendDocumentAsync(
    chatId: message.Chat.Id,
    document: $"_{message.Text}");
                    }
                }
            }
        }

        /// <summary>
        /// Method downloads document from chat
        /// </summary>
        /// <param name="fileId">Personal document id</param>
        /// <param name="path">Document path</param>
        private static async void Download(string fileId, string path)
        {
            var file = await client.GetFileAsync(fileId);
            FileStream stream = System.IO.File.OpenWrite('_' + path);
            await client.DownloadFileAsync(file.FilePath, stream);
            stream.Close();

            stream.Dispose();
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
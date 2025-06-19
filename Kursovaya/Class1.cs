using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kursovaya
{
    public class ImageService
    {
        public static async Task<Image> DownloadImageAsync(string imageUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Отправка GET-запроса
                HttpResponseMessage response = await httpClient.GetAsync(imageUrl);
                response.EnsureSuccessStatusCode(); // Проверка успешности

                // Чтение данных в поток
                Stream imageStream = await response.Content.ReadAsStreamAsync();

                // Создание объекта Image из потока
                return Image.FromStream(imageStream);
            }
        }
    }
}

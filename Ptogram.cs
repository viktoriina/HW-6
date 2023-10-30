
﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace json_books
{
    internal class Program
    {
        public class Book
        {
            public int PublishingHouseId { get; set; }
            public string Title { get; set; }
            public PublishingHouse PublishingHouse { get; set; }
        }

        public class PublishingHouse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
        }
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // let our file be located in this path
            string path = @"D:\books.json";
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.PublishingHouseId} - {book.Title} - {book.PublishingHouse.Id} - {book.PublishingHouse.Name} - {book.PublishingHouse.Adress}");
                }
            }
        }
    }
}

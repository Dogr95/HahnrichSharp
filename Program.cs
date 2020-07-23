using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace HahnrichSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = LoadUsers();
            Console.WriteLine(users[0].Name);
            Console.WriteLine("Please enter your name!");
            var name = Console.ReadLine();
            var time = DateTime.Now;
            User user = new User();
            user.Name = name;
            var options = new JsonSerializerOptions
            {
              WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(user, options);
            File.WriteAllText("test.json", jsonString);
            Console.WriteLine($"{time}: Hallo, {user.Name} mit der ID {user.Id}! snaqBlank");
            Console.Write("Exit\n");
            Console.ReadKey(true);
        }
        static string LoadUsers()
        {
          string users = File.ReadAllText("users.json");
          User [] jsonUsers = JsonSerializer.Deserialize<User[]>(users);
          return jsonUsers;
        }
    }
    [Serializable]
    public class User
    {
      public string Name { get; set; } = "user";
      public long Id { get; } = DateTime.Now.Ticks;
    }
}

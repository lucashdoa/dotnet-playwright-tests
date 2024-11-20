using Newtonsoft.Json;
using System.Collections;

namespace AutomationExercise.NUnit.Utils;

public class UserDataSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        var filePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "Users.json");
        var jsonData = File.ReadAllText(filePath);
        var users = JsonConvert.DeserializeObject<List<User>>(jsonData);

        foreach(var user in users)
        {
            yield return new object[]
            {
                user.name,
                user.email
            };
        }
    }

    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
    }
}
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

        foreach (var user in users)
        {
            yield return new object[]
            {
                user.userData
            };
        }
    }
}

public class User
{
    public UserData userData;
}

public class UserData
{
    public string name { get; set; }
    public string email { get; set; }
    public bool isMale { get; set; }
    public string password { get; set; }
    public string birthDay { get; set; }
    public string birthMonth { get; set; }
    public string birthYear { get; set; }
    public bool isSubscribedNewsletter { get; set; }
    public bool isSubscribedSpecialOffers { get; set; }
    public Address address { get; set; }
}

public class Address
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fullAddress { get; set; }
    public string country { get; set; }
    public string state { get; set; }
    public string city { get; set; }
    public string zipcode { get; set; }
    public string phone { get; set; }
}
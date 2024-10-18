namespace LambdasTask;

internal class Lambdas
{
    static void Main(string[] args)
    {
        var persons = new List<Person>
        {
            new Person("Иван", 13),
            new Person("Мария", 20),
            new Person("Владимир", 33),
            new Person("Иван", 40),
            new Person("Семён", 28),
            new Person("Анна", 15)
        };

        var uniqueNames = persons
            .Select(p => p.Name)
            .Distinct()
            .ToList();

        Console.WriteLine("Имена: " + string.Join(", ", uniqueNames) + ".");

        var personsUnderEighteen = persons
            .Where(p => p.Age < 18)
            .Select(p => p.Name)
            .ToList();

        double? averageAgeUnderEighteen = persons
            .Where(p => p.Age < 18)
            .Average(p => p?.Age);

        if (personsUnderEighteen.Count == 0)
        {
            Console.WriteLine("Нет людей младше 18");
        }
        else
        {
            Console.WriteLine("Имена людей младше 18: " + string.Join(", ", personsUnderEighteen) + ". Средний возраст: " + averageAgeUnderEighteen);
        }

        var averageAgesByNames = persons
            .GroupBy(p => p.Name)
            .ToDictionary(g => g.Key, g => g.Average(p => p.Age))
            .ToList();

        Console.WriteLine("Имена со средним возрастом: " + string.Join(", ", averageAgesByNames));

        var personsBetweenTwentyAndFortyFive = persons
            .Where(p => p.Age >= 20 && p.Age <= 45)
            .OrderByDescending(p => p.Age)
            .Select(p => p.Name)
            .ToList();

        Console.WriteLine("Имена людей, возраст которых от 20 до 45: " + string.Join(", ", personsBetweenTwentyAndFortyFive));

        Console.ReadLine();
    }
}
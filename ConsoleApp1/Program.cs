class Program
{
    static (string name, string surname, int age, bool hasPets, string[] petNames, string[] favoriteColors) GetUserInput()
    {
        Console.WriteLine("Введите имя:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите фамилию:");
        string surname = Console.ReadLine();

        int age = GetPositiveIntInput("Введите возраст:");

        Console.WriteLine("Есть ли у вас питомец? (да/нет)");
        bool hasPets = Console.ReadLine().ToLower() == "да";

        string[] petNames = null;
        if (hasPets)
        {
            int petCount = GetPositiveIntInput("Введите количество питомцев:");
            petNames = GetPetNames(petCount);
        }

        int colorCount = GetPositiveIntInput("Введите количество любимых цветов:");
        string[] favoriteColors = GetColors(colorCount);

        return (name, surname, age, hasPets, petNames, favoriteColors);
    }

    static int GetPositiveIntInput(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                return result;

            Console.WriteLine("Некорректный ввод. Введите положительное целое число.");
        }
    }

    static string[] GetPetNames(int count)
    {
        string[] names = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите кличку питомца {i + 1}:");
            names[i] = Console.ReadLine();
        }
        return names;
    }

    static string[] GetColors(int count)
    {
        string[] colors = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите любимый цвет {i + 1}:");
            colors[i] = Console.ReadLine();
        }
        return colors;
    }

    static void DisplayUserInfo((string name, string surname, int age, bool hasPets, string[] petNames, string[] favoriteColors) userInfo)
    {
        Console.WriteLine($"\nДанные пользователя:");
        Console.WriteLine($"Имя: {userInfo.name}");
        Console.WriteLine($"Фамилия: {userInfo.surname}");
        Console.WriteLine($"Возраст: {userInfo.age}");

        if (userInfo.hasPets)
        {
            Console.WriteLine($"Количество питомцев: {userInfo.petNames.Length}");
            Console.WriteLine("Клички питомцев:");
            foreach (var name in userInfo.petNames)
                Console.WriteLine($" - {name}");
        }
        else
        {
            Console.WriteLine("Питомцев нет");
        }

        Console.WriteLine($"Любимые цвета ({userInfo.favoriteColors.Length} штук):");
        foreach (var color in userInfo.favoriteColors)
            Console.WriteLine($" - {color}");
    }

    static void Main(string[] args)
    {
        var userInfo = GetUserInput();
        DisplayUserInfo(userInfo);

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
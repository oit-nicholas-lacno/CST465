using Lab4.Objects;
//using Random;
public static class ChoreWorkforceExtension
{
    public static void AddLaborer(this ChoreWorkforce cw, string name, int age, int difficulty)
    {
        cw.Laborers.Add(new ChoreLaborer(){Name=name, Age = age, Difficulty=difficulty});
    }

    public static void AddRandomLaborer(this ChoreWorkforce cw)
    {
        string[] names = {"Bob", "Frank", "Joe", "Bill", "George", "Zach", "Matt", "Jill", "Jack", "Nick", "Michael"};
        Random r = new();
        var index = r.Next(names.Length);
        var age = r.Next(1,19);
        var difficulty = r.Next(1,11);
        if (difficulty == 10)
        {
            cw.Laborers.Add(null);
        }
        else
            cw.AddLaborer(names[index], age, difficulty);
    }
}
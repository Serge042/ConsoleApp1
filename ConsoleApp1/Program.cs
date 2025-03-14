class MainClass
{
    static void Echo(string saidworld, int deep)
    {
        var modif = saidworld;

        if (modif.Length > 2)
        {
            modif = modif.Remove(0, 2);

        }

        Console.WriteLine("..." + modif);

        if (deep > 1)
        {
            Echo(modif, deep - 1);
        }
    }
}
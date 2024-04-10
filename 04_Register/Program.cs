using Microsoft.Win32;

internal class Program
{
    private static void Main(string[] args)
    {
        int SelectItem;
        RegistryKey[] regs = new[] {Registry.ClassesRoot, //Містить інформацію про зареєстровані типи файлів та об'єкти COM та ActiveX. Замість повного імені розділу іноді використовується скорочення HKCR.
                                      Registry.CurrentUser, //Містить налаштування поточного користувача. Замість повного імені розділу іноді використовується абревіатура HKCU. Такий розділ у реєстрі створюватиметься для кожного користувача.
                                      Registry.LocalMachine, //Містить параметри конфігурації, які відносяться до даного комп'ютера. Розділ, на відміну від HKCU, один для усіх користувачів. Замість повного імені розділу іноді використовується абревіатура HKLM.
                                      Registry.Users, //Розділ містить усі активні, завантажені профілі користувачів ПК. Замість повного імені розділу іноді використовується абревіатура HKU.
                                      Registry.CurrentConfig}; // Містить інформацію про профіль обладнання, що використовується локальним комп'ютером під час запуску системи. Замість повного імені розділу іноді використовується абревіатура HKCC
        do
        {
            int i = 1;
            Console.WriteLine("Choose the section of the system registry");
            foreach (RegistryKey reg in regs)
                Console.WriteLine("{0}. {1}", i++, reg.Name);
            Console.WriteLine("0. Exit");
            Console.Write(">  ");
            SelectItem = Convert.ToInt32(Console.ReadLine()[0]) - 48;
            Console.WriteLine();
            if (SelectItem > 0 && SelectItem <= regs.GetLength(0))
                PrintRegKeys(regs[SelectItem - 1]);
        } while (SelectItem != 0);
    }
    static void PrintRegKeys(RegistryKey rk)
    {
        string[] names = rk.GetSubKeyNames();
        Console.WriteLine("Subsections {0}:", rk.Name);
        Console.WriteLine("----------------------------------");
        foreach (string s in names)
            Console.WriteLine(s);
        Console.WriteLine("----------------------------------");

        Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\The\Personalize",
                "AppsUseLightTheme", 1);
    }

}

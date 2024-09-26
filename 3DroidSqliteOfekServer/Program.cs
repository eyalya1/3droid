namespace _3DroidSqliteOfekServer;

class Program
{
    static void Main(string[] args)
    {
        bool success = false;
        do
        {
            Console.WriteLine("[s]ign up, [l]og in or [d]elete user");
            string action = Console.ReadLine();
            switch (action.ToLower())
            {
                case "s":
                case "sign":
                case "sign up":
                    signUpTemp();
                    break;
                case "l":
                case "log":
                    loginTemp();
                    break;
                case "d":
                    deleteTemp();
                    break;
                case "list":
                    string[] users = DBContext.GetUsers();
                    foreach (var user in users)
                    {
                        Console.WriteLine(user);
                    }
                    break;
            }
        } while (!success);
    }

    static bool deleteTemp()
    {
        Console.WriteLine("enter username");
        string username = Console.ReadLine();
        Console.WriteLine("enter password");
        string password = Console.ReadLine();
        if (userLogin.Login(username, password))
        {
            DBContext.DeleteUser(username);
            return true;
        }

        Console.WriteLine($"not authorised to delete {username}");
        return false;
    }

    static bool signUpTemp()
    {
        Console.WriteLine("enter username");
        string username = Console.ReadLine();
        Console.WriteLine("enter password");
        string password = Console.ReadLine();
        Console.WriteLine("enter email");
        string email = Console.ReadLine();
        try
        {
            string result = userLogin.SignUp(username, email, password);
            if (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("account made successfully");
                return true;
            }

            Console.WriteLine("failed to create acount");
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    static bool loginTemp()
    {
        Console.WriteLine("enter username");
        string username = Console.ReadLine();
        Console.WriteLine("enter password");
        string password = Console.ReadLine();
        bool result = userLogin.Login(username, password);
        if (result)
        {
            Console.WriteLine("logged in");
            return true;
        }

        Console.WriteLine("authentication failed");
        return false;
    }
}
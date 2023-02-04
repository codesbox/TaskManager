using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace qwe;
public class ConsoleKiller
{
    public void Command()
    {
        Console.Write("<<command>>");
        var inp = Console.ReadLine();
        string[] mass = inp.Split(" ");
        switch (mass[0].ToLower())
        {
            case "help":
                Help();
                break;
            case "tasklist":
                TaskList();
                break;
            case "killbyname":
                KillByName(mass[1]);
                break;
            case "killbyid":
                KillById(Convert.ToInt32(mass[1]));
                break;
            case "exit":
                Exit();
                break;
            case "processid":
                ProcessId(mass[1]);
                break;
            default:
                Console.WriteLine("Данной команды не существует");
                Command();
                break;
        }
    }
    public void Help()
    {
        Console.WriteLine("exit - выход из приложения");
        Console.WriteLine("KillById <id процесса> - завершение процесса по Id");
        Console.WriteLine("KillByName <имя процесса> - завершение процесса по имени");
        Console.WriteLine("TaskList - вывод списка процессов");
        Console.WriteLine("ProcessId <имя процесса> - определение id процесса по его имени или части (без учета регистра)");
        Command();
    }
    public void TaskList()
    {
        var tasks = Process.GetProcesses();
        for (int i = 0; i < tasks.Length; i++)
        {
            Console.WriteLine($"{tasks[i].ProcessName, -40}, {tasks[i].Id}");
        }
        Command();
    }
    public void KillById(int id)
    {
        var tasks = Process.GetProcesses();
        for (int i = 0; i < tasks.Length; i++) {
            if (tasks[i].Id == id)
            {
                tasks[i].Kill();
            }
        }
        Command();
        
    }
    public void KillByName(string name)
    {
        var tasks = Process.GetProcesses();
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].ProcessName.ToLower() == name.ToLower())
            {
                tasks[i].Kill();
            }
        }
        Command();
    }
    public void ProcessId(string name)
    {
        var tasks = Process.GetProcesses();
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].ProcessName.ToLower().Contains(name.ToLower()))
            {
                Console.WriteLine($"{tasks[i].ProcessName,-40}, {tasks[i].Id}");
            }
        }
        Command();
    }
    public void Exit()
    {
        Process.GetCurrentProcess().Kill();
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        var x = new ConsoleKiller();
        x.Command();

    }
}
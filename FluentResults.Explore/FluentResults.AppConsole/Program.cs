namespace FluentResults.AppConsole
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using FluentResults.AppConsole.TestService;
    using Spectre.Console;

    internal class Program
    {
        private static readonly MyTestService _someService = new MyTestService();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        private static void Main(string[] args)
        {
            #region Set up code, please ignore.

            _setOutputEncodingDoNotTouch();
            _startWindowMaximized();

            #endregion


            AnsiConsole.Render(new FigletText("FluentResult Demo").Color(Color.Pink1));
            AnsiConsole.Render(new Rule("[yellow]No object[/] attached these use the [green]Result[/] class"));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            AnsiConsole.MarkupLine("This should return as Successful:");
            Console.WriteLine();

            var noObjectSuccess = _someService.TestSuccessResultWithNoObject();
            AnsiConsole.MarkupLine(
                $"[yellow]Should be successful[/] [cyan]Is Successful:[/] [green]{noObjectSuccess.IsSuccess}[/]");
            Console.WriteLine();
            Console.WriteLine();

            AnsiConsole.MarkupLine("This should return as Fail:");
            Console.WriteLine();

            var noObjectFailing = _someService.TestFailingResultWithNoObject();
            AnsiConsole.MarkupLine(
                $"[yellow]Should be failing[/] [cyan]Is Failing:[/] [green]{noObjectFailing.IsFailed}[/]");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            AnsiConsole.Render(new Rule());
            AnsiConsole.Render(new Rule());
            AnsiConsole.Render(new Rule());

            AnsiConsole.Render(
                new Rule("[yellow]SomeClass.cs[/] attached these use the [green]Result<SomeClass>[/] class"));


            try
            {
                var objectFailing = _someService.TestFailResultWithObject();
                     Console.WriteLine();
                AnsiConsole.MarkupLine(
                    $"[yellow]Should be failing[/] [cyan]Is Failing:[/] [green]{objectFailing.IsFailed}[/] ----- [cyan]Random Generated Title:[/]   [green]{objectFailing.Value.Title}[/]");
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                AnsiConsole.MarkupLine("Whoops! an exception was thrown!");
                AnsiConsole.WriteException(e);
                Console.WriteLine();
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine();

            }
            finally
            {
                var objectSuccess = _someService.TestSuccessResultWithObject();
                AnsiConsole.MarkupLine(
                    $"[yellow]Should be Success[/] [cyan]Is Success:[/] [green]{objectSuccess.IsSuccess}[/] ----- [cyan]Random Generated Title:[/]   [green]{objectSuccess.Value.Title}[/]");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(); 
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                AnsiConsole.Render(new FigletText("Question:").Color(Color.Yellow));
                AnsiConsole.Render(new FigletText("Value vs DefaultValue? What is Difference?").Color(Color.Cyan1));
                var a = AnsiConsole.Confirm("Would you like to exit?");
                while (a == false)
                {
                    a = AnsiConsole.Confirm("Just kidding, that was not a question, please exit now.");
                }


                Environment.Exit(1);
            }

         
        }

        private static void _setOutputEncodingDoNotTouch()
        {
            // This is for Spectre Console on windows machines... unrelated to FluentResult
            Console.OutputEncoding = Encoding.UTF8;
        }

        private static void _startWindowMaximized()
        {
            var p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
    }
}
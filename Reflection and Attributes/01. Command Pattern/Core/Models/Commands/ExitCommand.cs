namespace CommandPattern.Core.Models.Commands
{
    using System;
    using Contracts;
    public class ExitCommand : ICommand
    {

        //It should exit the program and return null
        public string Execute(string[] args)
        {
            //Environment.Exit(0);
            return null;
        }
    }
}

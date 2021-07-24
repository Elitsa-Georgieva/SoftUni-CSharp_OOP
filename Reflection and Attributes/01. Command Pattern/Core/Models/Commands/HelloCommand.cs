namespace CommandPattern.Core.Models.Commands
{
    using System;
    using Contracts;

    public class HelloCommand : ICommand
    {
        //The result from its execution should be: $"Hello, {args[0]}".
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}

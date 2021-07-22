using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;

namespace CommandPattern.Core.Models
{
    using System;
    using Contracts;
    using Commands;
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];

            //ICommand command = default;
            //if (commandName == "Hello")
            //{
            //    //правим инстанция на класа HelloCommand
            //    // създаваме си командата 
            //    command = new HelloCommand();
                
            //}
            //else if (commandName == "Exit")
            //{
            //    command = new ExitCommand();
                
            //}

            //ObjectTyp-а ни е ICommand
            //Искаме да създадем инстанция на CommandName

            Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{commandName}Command");

            ICommand command = (ICommand) Activator.CreateInstance(commandType);
            //TOD: Check for null?????
            //(екзекютваме си командата)
            string result = command.Execute(commandArgs);

            // връщаме резултата от екзекютването на нещото, което извиква нашия командинтерпретатор
            // а това е в Engine = string result = this.commandInterpreter.Read(command);
            return result;
        }
    }
}

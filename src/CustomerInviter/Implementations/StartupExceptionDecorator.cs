using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System;

namespace CustomerInviter.Implementations
{
    public class StartupExceptionDecorator : IStartup
    {
        private readonly IStartup startup;

        public StartupExceptionDecorator(IStartup startup) {
            this.startup = startup;
        }

        public void Start() {
            try {
                startup.Start();
            } catch (CustomException ex) {
                WriteError(ex.Message);
            } catch (Exception ex) {
                WriteError("Opps! Something went wrong.", ex.Message);
            }
        }

        private void WriteError(params string[] messages) {
            Console.BackgroundColor = ConsoleColor.Red;
            foreach (var messageItem in messages) {
                Console.WriteLine(messageItem);
            }
        }
    }
}
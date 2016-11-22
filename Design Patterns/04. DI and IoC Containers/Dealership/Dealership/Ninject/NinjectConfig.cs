using Dealership.Common.IOProvider;
using Dealership.Contracts;
using Dealership.Models;
using Ninject.Modules;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Factories;
using Dealership.CommandHandlers;
using Dealership.Engine;

namespace Dealership.Ninject
{
    public class NinjectConfig : NinjectModule
    {
        private const string RegisterUserCommandHandlerName = "RegisterUserCommandHandler";
        private const string LoginCommandHandlerName = "LoginUserCommandHandler";
        private const string LogoutCommandHandlerName = "LogoutUserCommandHandler";
        private const string AddVehicleCommandHandlerName = "AddVehicleCommandHandler";
        private const string RemoveVehicleCommandHandlerName = "RemoveVehicleCommandHandler";
        private const string AddCommentCommandHandlerName = "AddCommentCommandHandler";
        private const string RemoveCommentCommandHandlerName = "RemoveCommentCommandHandler";
        private const string ShowUsersCommandHandlerName = "ShowUsersCommandHandler";
        private const string ShowVehiclesCommandHandlerName = "ShowVehiclesCommandHandler";

        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";

        public override void Load()
        {

            //Default interface in this scenario means that if your interface is named ICar, then the class named Car will be binded to it
            Kernel.Bind(x =>
                 x.FromThisAssembly()
                 .SelectAllClasses()
                 .BindDefaultInterface()
             );

            this.Bind<Func<string>>().ToMethod(ctx => () =>
            {
                return Console.ReadLine();
            });

            this.Bind<Action<string>>().ToMethod(ctx => (param) =>
            {
                Console.Write(param);
            });

            this.Bind<IIOProvider>().To<GenericIOProvider>();

            this.Bind<IVehicle>().To<Car>().Named(CarName);
            this.Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);
            this.Bind<IVehicle>().To<Truck>().Named(TruckName);
            this.Bind<IDealershipFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandHandler>().To<RegisterUserCommandHandler>().Named(RegisterUserCommandHandlerName);
            this.Bind<ICommandHandler>().To<LoginUserCommandHandler>().Named(LoginCommandHandlerName);
            this.Bind<ICommandHandler>().To<LogoutUserCommandHandler>().Named(LogoutCommandHandlerName);
            this.Bind<ICommandHandler>().To<AddVehicleCommandHandler>().Named(AddVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveVehicleCommandHandler>().Named(RemoveVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<AddCommentCommandHandler>().Named(AddCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveCommentCommandHandler>().Named(RemoveCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowUsersCommandHandler>().Named(ShowUsersCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowVehiclesCommandHandler>().Named(ShowVehiclesCommandHandlerName);


            this.Bind<ICommandHandler>().ToMethod(ctx =>
            {
                var registerUserHandler = ctx.Kernel.Get<ICommandHandler>(RegisterUserCommandHandlerName);
                var loginHandler = ctx.Kernel.Get<ICommandHandler>(LoginCommandHandlerName);
                var logoutHandler = ctx.Kernel.Get<ICommandHandler>(LogoutCommandHandlerName);
                var addVehicleHandler = ctx.Kernel.Get<ICommandHandler>(AddVehicleCommandHandlerName);
                var removeVehicleHandler = ctx.Kernel.Get<ICommandHandler>(RemoveVehicleCommandHandlerName);
                var addCommnentHandler = ctx.Kernel.Get<ICommandHandler>(AddCommentCommandHandlerName);
                var removeCommentHandler = ctx.Kernel.Get<ICommandHandler>(RemoveCommentCommandHandlerName);
                var showUsersHandler = ctx.Kernel.Get<ICommandHandler>(ShowUsersCommandHandlerName);
                var showVehiclesHandler = ctx.Kernel.Get<ICommandHandler>(ShowVehiclesCommandHandlerName);

                registerUserHandler.SetSuccessor(loginHandler);
                loginHandler.SetSuccessor(logoutHandler);
                logoutHandler.SetSuccessor(addVehicleHandler);
                addVehicleHandler.SetSuccessor(removeVehicleHandler);
                removeVehicleHandler.SetSuccessor(addCommnentHandler);
                addCommnentHandler.SetSuccessor(removeCommentHandler);
                removeCommentHandler.SetSuccessor(showUsersHandler);
                showUsersHandler.SetSuccessor(showVehiclesHandler);

                return registerUserHandler;
            })
           .WhenInjectedInto<DealershipEngine>()
           .InSingletonScope();

            this.Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
        }
    }
}

// ***********************************************************************
// Solution         : VsTemplate
// Project          : DemoActor
// File             : Program.cs
// Updated          : 2017-11-02 15:38
// ***********************************************************************
// <copyright>
//     Copyright © 2016 - 2017 Kolibre Credit Team. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Threading;
using KC.Foundation.SF.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace DemoActor
{
    internal static class Program
    {
        /// <summary>
        ///     This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                // This line registers an Actor Service to host your actor class with the Service Fabric runtime.
                // The contents of your ServiceManifest.xml and ApplicationManifest.xml files
                // are automatically populated when you build this project.
                // For more information, see https://aka.ms/servicefabricactorsplatform

                ActorRuntime.RegisterActorAsync<DemoActor>(
                    (context, actorType) => new ActorServiceBuilder(context, actorType).UseStartup<Startup>().Build<DemoActor, DemoActorState, DemoActorReminder>(
                        (service, id, provider) => new DemoActor(service, id, provider))
                ).GetAwaiter().GetResult();

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
#if DEBUG
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
#endif
                Trace.TraceError(e.Message);
                throw;
            }
        }
    }
}
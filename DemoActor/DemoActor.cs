// ***********************************************************************
// Solution         : VsTemplate
// Project          : DemoActor
// File             : DemoActor.cs
// Updated          : 2017-11-02 15:32
// ***********************************************************************
// <copyright>
//     Copyright © 2016 - 2017 Kolibre Credit Team. All rights reserved.
// </copyright>
// ***********************************************************************


using System;
using System.Threading.Tasks;
using KC.Foundation.SF.Actors;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace DemoActor
{
    [ActorService(Name = "DemoActorService")]
    internal class DemoActor : KolibreActorBase<DemoActorState>, IDemoActor
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="DemoActor" />
        /// </summary>
        /// <param name="actorService">
        ///     The <see cref="ActorService" /> that will host this actor instance.
        /// </param>
        /// <param name="actorId">
        ///     The <see cref="ActorId" /> for this actor instance.
        /// </param>
        /// <param name="serviceProvider">
        ///     The <see cref="IServiceProvider" /> for this actor service.
        /// </param>
        public DemoActor(ActorService actorService, ActorId actorId, IServiceProvider serviceProvider) 
            : base(actorService, actorId, serviceProvider)
        {
        }

        /// <summary>
        ///     This method is called whenever an actor is activated.
        ///     An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            return Task.FromResult(0);
        }
    }
}
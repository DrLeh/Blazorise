﻿#region Using directives
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace Blazorise.Bootstrap5
{
    public static class Config
    {
        /// <summary>
        /// Adds a bootstrap providers and component mappings.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddBootstrapProviders( this IServiceCollection serviceCollection, Action<IClassProvider> configureClassProvider = null )
        {
            var classProvider = new BootstrapClassProvider();

            configureClassProvider?.Invoke( classProvider );

            serviceCollection.AddSingleton<IClassProvider>( classProvider );
            serviceCollection.AddSingleton<IStyleProvider, Bootstrap5StyleProvider>();
            serviceCollection.AddScoped<IJSRunner, BootstrapJSRunner>();
            serviceCollection.AddScoped<IThemeGenerator, BootstrapThemeGenerator>();

            serviceCollection.AddBootstrapComponents();

            return serviceCollection;
        }

        public static IServiceCollection AddBootstrapComponents( this IServiceCollection serviceCollection )
        {
            foreach ( var mapping in ComponentMap )
            {
                serviceCollection.AddTransient( mapping.Key, mapping.Value );
            }

            return serviceCollection;
        }

        public static IDictionary<Type, Type> ComponentMap => new Dictionary<Type, Type>
        {
            { typeof( Blazorise.Addon ), typeof( Bootstrap5.Addon ) },
            { typeof( Blazorise.BarToggler ), typeof( Bootstrap5.BarToggler ) },
            { typeof( Blazorise.BarDropdown ), typeof( Bootstrap5.BarDropdown ) },
            { typeof( Blazorise.BarDropdownMenu ), typeof( Bootstrap5.BarDropdownMenu ) },
            { typeof( Blazorise.BarDropdownToggle ), typeof( Bootstrap5.BarDropdownToggle ) },
            { typeof( Blazorise.Button ), typeof( Bootstrap5.Button ) },
            { typeof( Blazorise.Card ), typeof( Bootstrap5.Card ) },
            { typeof( Blazorise.CardTitle ), typeof( Bootstrap5.CardTitle ) },
            { typeof( Blazorise.CardSubtitle ), typeof( Bootstrap5.CardSubtitle ) },
            { typeof( Blazorise.Carousel ), typeof( Bootstrap5.Carousel ) },
            { typeof( Blazorise.CloseButton ), typeof( Bootstrap5.CloseButton ) },
            { typeof( Blazorise.Check<> ), typeof( Bootstrap5.Check<> ) },
            { typeof( Blazorise.DropdownToggle ), typeof( Bootstrap5.DropdownToggle ) },
            { typeof( Blazorise.Field ), typeof( Bootstrap5.Field ) },
            { typeof( Blazorise.FieldBody ), typeof( Bootstrap5.FieldBody ) },
            { typeof( Blazorise.FileEdit ), typeof( Bootstrap5.FileEdit ) },
            { typeof( Blazorise.Modal ), typeof( Bootstrap5.Modal ) },
            { typeof( Blazorise.ModalContent ), typeof( Bootstrap5.ModalContent) },
            { typeof( Blazorise.NumericEdit<> ), typeof( Bootstrap5.NumericEdit<> ) },
            { typeof( Blazorise.Radio<> ), typeof( Bootstrap5.Radio<> ) },
            { typeof( Blazorise.Switch<> ), typeof( Bootstrap5.Switch<> ) },
            { typeof( Blazorise.Step ), typeof( Bootstrap5.Step ) },
        };
    }
}
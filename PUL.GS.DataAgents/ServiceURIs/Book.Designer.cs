﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PUL.GS.DataAgents.ServiceURIs {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Book {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Book() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PUL.GS.DataAgents.ServiceURIs.Book", typeof(Book).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a book.
        /// </summary>
        internal static string CreateBook {
            get {
                return ResourceManager.GetString("CreateBook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a book.
        /// </summary>
        internal static string GeneralReportStatusBooks {
            get {
                return ResourceManager.GetString("GeneralReportStatusBooks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a book.
        /// </summary>
        internal static string GetAllBooks {
            get {
                return ResourceManager.GetString("GetAllBooks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a book.
        /// </summary>
        internal static string GetBookById {
            get {
                return ResourceManager.GetString("GetBookById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a book.
        /// </summary>
        internal static string GetListBooksByBookState {
            get {
                return ResourceManager.GetString("GetListBooksByBookState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a book.
        /// </summary>
        internal static string UpdateBook {
            get {
                return ResourceManager.GetString("UpdateBook", resourceCulture);
            }
        }
    }
}

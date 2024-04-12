namespace ApiGateway.Mobile.Module.Cors
{
    /// <summary>
    /// Cors Settings
    /// </summary>
    public class CorsSettings
    {
        /// <summary>
        /// lista de origenes
        /// </summary>
        public List<OriginSettings>? Origins { get; set; }
    }

    /// <summary>
    /// Settings origin
    /// </summary>
    public class OriginSettings
    {
        /// <summary>
        /// origin
        /// </summary>
        public string? Origin { get; set; }
        /// <summary>
        /// Metodos permitidos 
        /// </summary>
        public List<string>? AllowedMethods { get; set; }
        /// <summary>
        /// Politicas de cors
        /// </summary>
        public string? CorsPolicy { get; set; }
    }
}
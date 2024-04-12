using System.Collections;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ApiGateway.Mobile.Module.Yarp
{
    /// <summary>
    /// Swagger Endpoint Enumerator
    /// </summary>
    public class SwaggerEndpointEnumerator : IEnumerable<UrlDescriptor>
    {
        /// <summary>
        /// Obtener enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<UrlDescriptor> GetEnumerator()
        {
            yield return new UrlDescriptor
            {
                Name = "Super admin",
                Url = "https://inteia-as-dev-backend-management-appimotionplus.azurewebsites.net/swagger/index.html"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
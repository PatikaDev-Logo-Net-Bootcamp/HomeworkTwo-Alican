using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkTwo.Functions
{
    public class HideEndpoint : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var removeEndpoint = swaggerDoc.Paths.SingleOrDefault(x => x.Key.Contains("api/[controller]/hidden"));

            swaggerDoc.Paths.Remove(removeEndpoint.Key);
        }
    }
}

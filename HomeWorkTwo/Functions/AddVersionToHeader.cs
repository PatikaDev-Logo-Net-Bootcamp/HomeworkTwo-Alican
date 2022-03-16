using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkTwo.Functions
{
    public class AddVersionToHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "app-version",
                In = ParameterLocation.Header,
                Description = "Application Version",
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("3.0.0")
                }
            });
        }
    }
}

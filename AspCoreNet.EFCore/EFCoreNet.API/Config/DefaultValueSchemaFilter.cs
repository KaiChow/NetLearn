using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;

namespace EFCoreNet.API.Config
{
    public class DefaultValueSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema == null)
            {
                return;
            }
            var objSchema = schema;
            foreach (var property in objSchema.Properties)
            {
                //1, 配置字符串默认返回
                if (property.Value.Type == "string" && property.Value.Default == null)
                {
                    property.Value.Default = new OpenApiString("");
                }
                //2，通过属性名--- 配置特殊的默认属性初始值
                if (property.Key == "PageIndex")
                {
                    property.Value.Default = new OpenApiInteger(1);
                }
                else if (property.Key == "PageSize")
                {
                    property.Value.Default = new OpenApiInteger(50);
                }

                //3，通过特性来设置参数的默认值
                DefaultValueAttribute defaultValueAttribute = context.ParameterInfo?.GetCustomAttribute<DefaultValueAttribute>();
                if (defaultValueAttribute != null)
                {
                    property.Value.Example = (IOpenApiAny)defaultValueAttribute.Value;
                }
            }
        }
    }
}

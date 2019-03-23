using NJsonSchema;
using NJsonSchema.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSonSchemaCodeGenerator
{
    class EnumNameGenerator : IEnumNameGenerator
    {
        public string Generate(int index, string name, object value, JsonSchema4 schema)
        {
            return name;
        }
    }
}

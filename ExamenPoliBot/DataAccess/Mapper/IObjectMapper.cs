using System.Collections.Generic;
using Entities_POJO;

namespace DataAccess.Mapper
{
    internal interface IObjectMapper
    {
        List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows);
        BaseEntity BuildObject(Dictionary<string, object> row);
    }
}

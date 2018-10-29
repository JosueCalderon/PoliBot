namespace Entities_POJO
{
    public class BaseEntity
    {
        public string GetEntityInformation()
        {
            var dump = ObjectDumper.Dump(this);
            return dump;
        }
    }
}

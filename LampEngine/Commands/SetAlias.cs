namespace LampEngine
{
    public class SetAlias : BulbCommand
    {
         private static string AliasEndpoint = "{\"smartlife.iot.common.system\":{\"set_dev_alias\":{\"alias\":\"{alias}\"}}}";

         public string Alias { get; set;}

         public SetAlias(string newAlias) : base()
         {
            Alias = newAlias;
            var parameters = GetParameters(AliasEndpoint, this);
            CommandString = CreateCommandWithParameters(parameters, AliasEndpoint);
         }
    }
}
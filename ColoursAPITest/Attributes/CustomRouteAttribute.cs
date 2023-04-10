using AttributeRouting;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ColoursAPITest.Attributes
{
    public class CustomRouteAttribute : Attribute, IRouteTemplateProvider
    {
        public string Template => "custom-api/[controller]";
        public int? Order => 2;
        public string Name { get; set; } = string.Empty;
    }
}

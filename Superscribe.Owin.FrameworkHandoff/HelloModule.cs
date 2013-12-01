namespace Superscribe.Owin.FrameworkHandoff
{
    using Nancy;

    public class HelloModule : NancyModule
    {
        public HelloModule()
            : base("api/nancy")
        {
            this.Get["/"] = _ => "Hello from nancy";
        }
    }
}
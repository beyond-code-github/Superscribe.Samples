namespace Superscribe.WebApiOnOwin
{
    using Superscribe.Models;

    public class MessageWrapper
    {
        public string Message { get; set; }
    }

    public class HelloWorldModule : SuperscribeModule
    {
        public HelloWorldModule()
        {
            this.Get["/"] = o => new { Message = "Hello World" };

            this.Get["Hello" / (String)"Name"] = o => new { Message = "Hello, " + o.Parameters.Name };

            this.Post["Save"] = o =>
            {
                var wrapper = o.Bind<MessageWrapper>();
                return new { Message = "You entered - " + wrapper.Message };
            };
        }
    }
}